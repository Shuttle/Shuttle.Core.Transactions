﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shuttle.Core.Transactions {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Shuttle.Core.Transactions.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to TransactionScope (&apos;{0}&apos;) using ambient transaction..
        /// </summary>
        internal static string VerboseTransactionScopeAmbient {
            get {
                return ResourceManager.GetString("VerboseTransactionScopeAmbient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TransactionScope (&apos;{0}&apos;) using ambient transaction has completed..
        /// </summary>
        internal static string VerboseTransactionScopeAmbientCompleted {
            get {
                return ResourceManager.GetString("VerboseTransactionScopeAmbientCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TransactionScope (&apos;{0}&apos;) has completed..
        /// </summary>
        internal static string VerboseTransactionScopeCompleted {
            get {
                return ResourceManager.GetString("VerboseTransactionScopeCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TransactionScope (&apos;{0}&apos;) created with isolation level &apos;{1}&apos; and timeout of &apos;{2}&apos;..
        /// </summary>
        internal static string VerboseTransactionScopeCreated {
            get {
                return ResourceManager.GetString("VerboseTransactionScopeCreated", resourceCulture);
            }
        }
    }
}
