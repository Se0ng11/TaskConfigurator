﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskConfigurator.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TaskConfigurator.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Action;Status;.
        /// </summary>
        internal static string actionstatus {
            get {
                return ResourceManager.GetString("actionstatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to id:Label;Wicode:Label;TaskStatus:Text;TaskAction:Text;WiStatus:Text;wiSubStatus:Text;oiStatus:Text;oiSubStatus:Text;noteType:Text;noteText:Text;.
        /// </summary>
        internal static string actionstatusmappingAIB {
            get {
                return ResourceManager.GetString("actionstatusmappingAIB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ;id;lobid;taskcodeid;ein;modifydate;attributeid;.
        /// </summary>
        internal static string constant {
            get {
                return ResourceManager.GetString("constant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DropDown;TextBox;Date;.
        /// </summary>
        internal static string control {
            get {
                return ResourceManager.GetString("control", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to control;systemname;defaulttaskpriority;ordernotificationflag;attribute;.
        /// </summary>
        internal static string dropdown {
            get {
                return ResourceManager.GetString("dropdown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to N;Y;.
        /// </summary>
        internal static string flag {
            get {
                return ResourceManager.GetString("flag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to id;taskcodeid;AttributeName;.
        /// </summary>
        internal static string freeze {
            get {
                return ResourceManager.GetString("freeze", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wicode;taskcodeid;AttributeId;lobid;ein;modifydate;.
        /// </summary>
        internal static string include {
            get {
                return ResourceManager.GetString("include", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ;wicode;attributename;Value;lobid;taskcodeid;systemname;attribute;taskstatus;taskaction;attributeid;attributevalue;attributetext;wistatus;wisubstatus;oistatus;oisubstatus;attribute;.
        /// </summary>
        internal static string mandatory {
            get {
                return ResourceManager.GetString("mandatory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AVAYA L2C;AIB WBMC L2C;NEO HE L2C;AIB HE L2C;AVAYA BTO L2C;TSO L2C;BTO L2C;.
        /// </summary>
        internal static string systemname {
            get {
                return ResourceManager.GetString("systemname", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Low;Normal;High;Urgent;.
        /// </summary>
        internal static string taskpriority {
            get {
                return ResourceManager.GetString("taskpriority", resourceCulture);
            }
        }
    }
}
