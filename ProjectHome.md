# Ext.Direct for ASP.NET MVC #

## ATTENTION ##

### The project has moved to GitHub: https://github.com/elishnevsky/ext-direct-mvc ###

Ext.Direct.Mvc is an implementation of Ext Direct server-side stack for
ASP.NET MVC. Ext Direct is a platform and language agnostic technology to
remote server-side methods to the client-side. Ext Direct allows for seamless
communication between the client-side of an Ext JS application and all popular
server platforms. For more information about Ext Direct visit
http://www.sencha.com/products/extjs/extdirect.

## Key features ##

  * Easy setup
  * Support for different types of parameters - simple types, complex types and arrays
  * Form post values can be bound to multiple simple type parameters, a single complex type parameter (object) or a mix of both on the server
  * Support for method aliases
  * Exceptions with full stack trace and additional user-defined data for easy debugging
  * Support for custom server-side events
  * Support for named arguments (Ext JS 4.x)

## Latest version: v3.0.0 ##

New in this version:

  * New major version with **no backward compatibility (sorry)**
  * No configuration is required by default
  * Dropped assembly and descriptorGeneration configuration settings
  * Added support for named arguments
  * Dropped controller extension methods (Direct and DirectEvent)
  * Controllers now must derive from DirectController
  * Overrode Json controller methods that now must be called to return data from controller actions
  * Dropped DirectInclude attribute
  * Added DirectEvent action attribute that replaces DirectEvent extension method
  * Default date format is now ISO as opposed to the ugly M$
  * Added support for ASP.NET MVC 3
  * Dropped support for ASP.NET MVC 1 (too obsolete)

Please read the Wiki on this site about how to set up and use Ext.Direct.Mvc.