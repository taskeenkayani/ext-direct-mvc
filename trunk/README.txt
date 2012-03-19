In this file:

- About
- Requirements
- Quick start
- Advanced configuration and usage
- Upgrading from earlier versions


ABOUT
===============================================================================

Ext.Direct.Mvc
Copyright (c) 2012 Eugene Lishnevsky. All Rights Reserved.

Ext.Direct.Mvc is an implementation of Ext Direct server-side stack for
ASP.NET MVC. Ext Direct is a platform and language agnostic technology to
remote server-side methods to the client-side. Ext Direct allows for seamless
communication between the client-side of an Ext JS application and all popular
server platforms. For more information about Ext Direct visit
http://www.sencha.com/products/extjs/extdirect.

Official thread on Sencha forums:
http://www.sencha.com/forum/showthread.php?72245-Ext.Direct-for-ASP.NET-MVC

License:
Ext.Direct.Mvc is licensed under the terms of the GNU Lesser General Public
License version 3. A copy of the license can be found in the copying.txt and
copying_lesser.txt files included in this distribution.

Author:
Eugene Lishnevsky
mailto:elishnevsky@gmail.com


REQUIREMENTS
===============================================================================

Ext.Direct.Mvc is currently built to work with ASP.NET MVC 2 and 3.
To compile the binaries yourself you need:

Microsoft Visual Studio 2010 SP1
http://www.microsoft.com/web/gallery/install.aspx?appsxml=&appid=VS2010SP1Pack

ASP.NET MVC 3 Tools Update
http://www.microsoft.com/web/gallery/install.aspx?appid=MVC3

To run the test app you also need:

Microsoft SQL Server Compact 4
http://www.microsoft.com/web/gallery/install.aspx?appid=SQLCE

Microsoft Visual Studio 2010 SP1 Tools for SQL Server Compact 4.0
http://www.microsoft.com/web/gallery/install.aspx?appid=SQLCEVSTools


QUICK START
===============================================================================

Here's how to quickly start using Ext.Direct.Mvc in your project:

1. In you ASP.NET MVC project add a reference to the right Ext.Direct.Mvc dll
   and Newtonsoft.Json dll that comes with it. It is important because
   Ext.Direct.Mvc is compiled with it.

2. Add a script tag to your main view and set its scr attribute to "/DirectApi"
   relative to the root of your application. It outputs the method
   configurations for Ext Direct to create client-side stubs. In ASP.NET MVC 3
   application it will look like this:

   <script type="text/javascript" src="@Url.Content("~/DirectApi")"></script>

3. Add an Ext.Direct Provider to creates the proxy or stub methods to execute
   server-side methods. Because most of the time you will need stub methods
   before defining custom components, this should be done early in your code:

   // in Ext JS 4 or Sencha Touch 2
   Ext.direct.Manager.addProvider(Ext.app.REMOTING_API);

   // or in Ext JS 3
   Ext.Direct.addProvider(Ext.app.REMOTING_API);

4. Make controllers inherit DirectController as opposed to just Controller.

5. Return data from controller actions by calling one of the overriden Json
   methods. Actions that process form posts must be marked with [FormHandler]
   attribute.

That's it! Now you can call your controller actions directly from your
JavaScript code through the created stub methods.


ADVANCED CONFIGURATION AND USAGE
===============================================================================

Configuration
-------------------------------------------------------------------------------
By default no configuration is required at all to use Ext.Direct.Mvc. However,
you can customize certain things in web.config of your project. What you need
to do is create ext.direct section. Here is an example:

<configuration>
    <configSections>
        <section name="ext.direct" type="Ext.Direct.Mvc.ProviderConfiguration,
          Ext.Direct.Mvc"/>
    </configSections>
    <ext.direct
        name="MyApp.direct.API"
        namespace="Demo"
        buffer="10"
        maxRetries="1"
        timeout="5000"
        dateFormat="js"
        debug="true"
    />
    ...
</configuration>

The following settings can be changed and all of them are optional:
* name - Custom name for the remoting API (default: Ext.app.REMOTING_API)
* namespace - Namespace for generated proxy methods. Default is no namespace.
* buffer - Number that specifies the amount of time in milliseconds to wait
    before sending a batched request. If not specified then the default
    value, configured by Ext JS will be used, which is 10.
* maxRetries - Number of times to re-attempt delivery on failure of a call.
    If not specified then the default value, configured by Ext JS will be used,
    which is 1.
* timeout - The timeout to use for each request. If not specified then the
    default value defined by Ext JS will be used, which I don't remember :)
* dateFormat - The format in which DateTime objects should be returned. Valid
    values are "ISO", "JS" or "JavaScript", case insensitive. Anything else
    will format the dates using the ugly M$ format. Default is "ISO".
* debug - Boolean. Set to true to include full stack trace in the exception
    response when an intercepted server exception is returned to the client.
    Default is false. Generally you don't need to set it, because stack trace
    is always included when you run your project in Debug mode. However, this
    can be helpful when an obscure server-side exception occurs only on
    production environment and cannot be reproduced locally, so temporary
    setting this option can help find the exact location of the problem.
    But it should NEVER be left set to true on production environment because
    of security concerns!!!

Excluding controllers or action from Ext Direct
-------------------------------------------------------------------------------
By default client-side stub methods are generated for all public actions in any
controller that derives from DirectController. Most of the time it is what you
want, but sometimes it is needed to exclude entire controller or individual
actions from Ext Direct, so that stub methods will not be generated. This can
be done by marking the actions or the controller with [DirectIgnore] attrubute,
it will instruct Ext.Direct.Mvc to ignore them when creating the API object.

Handling server-side exceptions on the client
-------------------------------------------------------------------------------
By default no server-side exception are intercepted except the special
DirectException. When a DirectException is thrown on the server, a direct
response of type "exception" is returned to the client. It is also possible to
intercept any server-side exceptions in an entire controller or a single action
and return it to the client as exception response. To do this you need to mark
either the controller or individual actions with [DirectHandleError] attribute.

[DirectHandleError]
public ActionResult MyAction() {
    // ...
    throw new Exception("Something bad happened!");
    // ...
}

Exception response on the client can contain the following members:

* type - "exception"
* tid - The transaction id
* action - The action that has been called
* method - The method that has been called
* message - The error message
* where - The full stack trace from the server, available during debugging
* result - Simple object with only "success" boolean property for form posts
* errorData - User-defined information about the exception only if provided

The errorData is copied from Exception.Data. To read about Exception.Data and
how to set it visit this page:
http://msdn.microsoft.com/en-us/library/system.exception.data.aspx

You can handle a server-side exception on the client either in an individual
callback function:

Employees.Get(1234, function(result, event) {
   if (event.type == "exception") {
      // display or log the error
      return;
   }
   // process the result
});

or globally

// in Ext JS 4 or Sencha Touch 2
Ext.direct.Manager.on('exception', function(error) {
    console.error(String.format('{0}\n{1}', error.message, error.where));
});

// or in Ext JS 3
Ext.Direct.on('exception', function(error) {
    console.error(String.format('{0}\n{1}', error.message, error.where));
});

Server-side events
-------------------------------------------------------------------------------
Ext.Direct supports custom server-side events. Mark an acton that should return
an event with [DirectEvent] attribute to wrap its returned value in a special
event response object and handle it on the client as described in the
documentation for Direct manager.


UPGRADING FROM EARLIER VERSIONS
===============================================================================

Although Ext.Direct.Mvc v3.0.0 is written to be extremely easy to use when you
start a new project or want to convert existing one from using regular AJAX
requests to Ext Direct, upgrading from earlier versions of Ext.Direct.Mvc can
be a little time consuming and frankly not very necessary. If for whatever
reason you convinced yourself to upgrade here is a list of things that you need
to know:

* No configuration is required if you are happy with the defaults
* Default date format changed from the ugly M$ to the universal ISO
* Controllers that participate in Ext Direct must derive from DirectController.
  It's a new class in v3.0.0 and it contains overriden Json methods.
* Descriptor generation method has been dropped (OptIn and OptOut)
* DirectInclude attribute has been dropped
* Controller extension methods (Direct and DirectEvent) have been dropper. Now
  one of the overridden Json methods must be called to return data.

  Good luck!