﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ext.Direct.Mvc.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DirectResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DirectResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ext.Direct.Mvc.Resources.DirectResources", typeof(DirectResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DirectRequest is null. Check that POST parameters were passed..
        /// </summary>
        internal static string Common_DirectRequestIsNull {
            get {
                return ResourceManager.GetString("Common_DirectRequestIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value cannot be null or empty..
        /// </summary>
        internal static string Common_NullOrEmpty {
            get {
                return ResourceManager.GetString("Common_NullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method {0} has already been configured for action {1}..
        /// </summary>
        internal static string DirectAction_MethodExists {
            get {
                return ResourceManager.GetString("DirectAction_MethodExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find section &apos;ext.direct&apos; in the configuration file..
        /// </summary>
        internal static string DirectConfig_NoExtDirectSectionFound {
            get {
                return ResourceManager.GetString("DirectConfig_NoExtDirectSectionFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Action {0} has already been configured..
        /// </summary>
        internal static string DirectProvider_ActionExists {
            get {
                return ResourceManager.GetString("DirectProvider_ActionExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find action {0}..
        /// </summary>
        internal static string DirectProvider_ActionNotFound {
            get {
                return ResourceManager.GetString("DirectProvider_ActionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find method {0} in action {1}..
        /// </summary>
        internal static string DirectProvider_MethodNotFound {
            get {
                return ResourceManager.GetString("DirectProvider_MethodNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number of arguments does not match the definition method {0} in action {1}..
        /// </summary>
        internal static string DirectProvider_WrongNumberOfArguments {
            get {
                return ResourceManager.GetString("DirectProvider_WrongNumberOfArguments", resourceCulture);
            }
        }
    }
}
