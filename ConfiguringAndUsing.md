UPDATE: ONLY RELEVANT TO VERSION 2.2.0 AND EARLIER.

## Introduction ##

To start using Ext.Direct.Mvc [download](http://code.google.com/p/ext-direct-mvc/downloads/list) the binaries, extract the files from the archive, and add references to Newtonsoft.Json.dll and the right version of Ext.Direct.Mvc.dll (depending on what version of ASP.NET MVC you chose) in you ASP.NET MVC project. I recommend that you read everything on this page to avoid any potential problems you may run into.

Here is a quick explanation of how Ext.Direct.Mvc works. Once you have configured everything correctly in Web.config file as described below in the Configuration section, and included API via a script tag, the API component of Ext.Direct.Mvc will generate client-side stubs (descriptors) for your controller actions based on the generation method. Then you can seamlessly call your server-side methods as if they were client-side methods.
Read further for details.

## Requirements ##

  * .NET 3.5
  * [ASP.NET MVC](http://www.asp.net/mvc/)
  * Json.NET 3.5 Release 8 (included)
  * Visual Studio 2010 (if you want to run the demo app)

## Configuration ##

In your Web.config file add `ext.direct` section as follows:
```
<configuration>
    <configSections>
        <section name="ext.direct" type="Ext.Direct.Mvc.Configuration.DirectSection, Ext.Direct.Mvc"/>
    </configSections>
    <ext.direct
        providerName="Ext.app.REMOTING_API"
        assembly="AssemblyName"
    />
    ...
</configuration>
```
Available options for `ext.direct` section are:

  * `providerName` - **Required**. Name for the generated API provider config.
  * `assembly` - **Required**. Name of the assembly that contains the controllers to generate API, usually the name of your MVC web project assembly. Multiple assembly names can be separated by commas.
  * `namespace` - Optional. Namespace for the provider.
  * `descriptorGeneration` - Optional. Specifies client-side descriptors generation method. The value is case-sensitive and can be one of the following:
    * `OptOut` - Default. Client-side descriptors are generated for all controller actions. Undesired controllers or actions can be excluded by marking them with `[DirectIgnore]` attribute.
    * `OptIn` - Client-side descriptors are generated only for controllers and actions that are marked with the `[DirectInclude]` attribute.
  * `buffer` - Optional. Amount of time in milliseconds to wait before sending a batched request. Default to 10.
  * `dateFormat` - Optional. Format to use by default when serializing dates. Supported values are "Iso" and "JavaScript". If not set or has value other than supported, then M$ format is used by default.
  * `debug` - Optional. Boolean that indicates whether to include full stack trace in the exception response when an intercepted server exception is returned to the client. Default to false. This option should never be set to true in production environment because of security concerns. Read about handling exceptions in the "Server-side Exceptions" section below.

## Usage ##

1. Include the API component via a script tag in the head of your main application page. The server-side will dynamically generate JavaScript code to be executed on the client-side. It is recommended to specify API path relative to the root of your app:
```
<script type="text/javascript" src="<%= Url.Content("~/Direct/Api") %>"></script>
```

2. The API component outputs an object literal of method configurations with the name that you used for `providerName` option in your Web.config (in this example Ext.app.REMOTING\_API), so to register the provider you add the following code in your application's initialization function:
```
Ext.Direct.addProvider(Ext.app.REMOTING_API);
```

3. Write controller and actions as usual, but make sure the actions return an instance of `DirectResult` class. For your convenience I have created a few overloaded helper extension methods called `Direct()` for Controller class, so to return data from a controller action you can use the following syntax:
```
using Ext.Direct.Mvc;

namespace MyMvcApplication {
    public class EmployeesController : Controller {
        public ActionResult Get(int id) {
            // Method logic here
            // var employee = ...
            return this.Direct(employee);
        }
    }
}
```
The return value is serialized to json by Newtonsoft Json.NET library, which is included in the downloaded archive.

4. By default Ext.Direct.Mvc generates client-side descriptors using OptOut method (read about this in the Configuration section above). If you chose this method, then mark controllers and actions, for which you don't want client-side descriptors to be generated, with `[DirectIgnore]` attribute. You can change the descriptor generation method to OptIn in your configuration file. This way client-side descriptors will be generated only for controllers or actions marked with `[DirectInclude]` attribute.

**IMPORTANT:** If you created your MVC project from an MVC Web Application template, it will contain two default controllers - HomeController and AccountController. In most cases you will not want client-side proxy methods to be generated for these controllers, so if you keep them in your project and you use the default OptOut descriptor generation method, DO NOT FORGET to mark them with `[DirectIgnore]` attribute to avoid problems. At the very least the AccountController, since it contains duplicate action names.

5. To call a server-side method from your Ext JS code use syntax similar to this:
```
Employees.Get(1234, function(result, response) {
    // process the result
});
```
Where `Employees` maps to `EmployeesController` class and `Get` to the action in that controller.
And if you specified a value for the `namespace` option in the Web.config, then your call will look something like this:
```
YourNamespace.Employees.Get(...);
```

6. `[FormHandler]` attribute _must_ be used to mark controller actions, that will be called to process form submits. If you fail to do so, Ext.Direct will send a regular POST request (as opposed to Form POST) to this action, and you can have hard time trying to figure out why it is doing it. Please keep it in mind.

7. `[ActionName]` attribute can be used to assign an alias to an action. It instructs Ext.Direct.Mvc to use the specified alias instead of action name when creating client-side stub for an action marked with this attribute. It is useful if you want to have overloaded actions in a controller. If you mark an action with this attribute, make sure you use the specified name when calling the method from your JS code.

## Server-side exceptions ##

By default no server-side exception are intercepted except the special `DirectException`. When a `DirectException` is thrown on the server, a direct response of type "exception" is returned to the client.
It is possible, however, to intercept all server-side exceptions in a controller or a single action and return them to the client as exception response. To do this you need to mark either the whole controller or individual actions with `[DirectHandleError]` attribute. Like this:
```
[DirectHandleError]
public ActionResult MyAction() {
    // ...
    throw new Exception("Something bad happened!");
    // ...
}
```
Exception response on the client can contain the following members:

  * `type` - "exception"
  * `tid` - The transaction id
  * `action` - The action that has been called
  * `method` - The method that has been called
  * `message` - The error message
  * `where` - The full stack trace from the server only if `debug` configuration option is `true`
  * `result` - Simple object with only "success" boolean property for form posts only
  * `errorData` - User-defined information about the exception only if provided

The `errorData` is copied from Exception.Data. To read about Exception.Data and how to set it see http://msdn.microsoft.com/en-us/library/system.exception.data.aspx

You can handle a server-side exception on the client either in an individual callback function
```
Employees.Get(1234, function(result, response) {
    if (response.type == "exception") {
        // process the exception here
    }
    // process the result
});
```
or globally
```
Ext.Direct.on('exception', function(e) {
    alert(e.message);
});
```

## Server-side events ##

Ext.Direct supports custom server-side events. You can return a custom event object from the server by calling one of the DirectEvent() extension methods of Controller class and handle it on the client as described in the documentation to Ext.Direct class in "Server side events" section: http://dev.sencha.com/deploy/dev/docs/?class=Ext.Direct