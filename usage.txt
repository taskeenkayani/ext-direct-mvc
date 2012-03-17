CONFIGURING AND USING
=====================

* By default no configuration is required.
* In your web project add a reference to Ext.Direct.Mvc and the included Newtonsoft.Json (it's important, because Ext.Direct.Mvc is compiled with it).
* Controllers participating in Ext.Direct must derive from DirectController class and the actions in these controllers must return an instance of DirectResult object.
* Json methods are overriden in DirectController.
* Actions that handle form posts must be marked with [FormHandler] attribute.
* Actions that expect named arguments to be passed must be marked with [NamedArguments] attribute.
* Actions that will be used to return server side events should be marked with [DirectEvent] attribute and given a name, for example [DirectEvent("message")]

Quick start:

1. Add a script tag to the head of your page and set its scr attribute to "/DirectApi" relative to the root of your application:
<script type="text/javascript" src="@Url.Content("~/DirectApi")"></script>

2. Add the following line to your JavaScript code before everything:
Ext.direct.Manager.addProvider(Ext.app.REMOTING_API);
If you rely on dynamic loading of Sencha Touch files, then you will have to load the files in Ext.direct namespace before you can add the provider.

3. Make you controllers which you want to participate in Ext Direct inherit DirectController. Call Json methods from your actions to return data.

That's it! Now you can start executing your remote methods by simply calling them if they were ordinary JavaScript objects and functions. For example, if you have a controller UserController and it contains an action called List, that returns a list of users, to call it from your JavaScript code just write User.List();

Custom configuration in web.config:

<configSections>
    <section name="ext.direct" type="Ext.Direct.Mvc.ProviderConfiguration, Ext.Direct.Mvc"/>
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

* name - If contains dots, the namespace will be defined automatically.
* buffer - milliseconds
* timeout - milliseconds
* dateFormat - js (or javascript) and iso. Case insensitive.