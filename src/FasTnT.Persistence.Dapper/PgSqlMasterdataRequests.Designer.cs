﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FasTnT.Persistence.Dapper {
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
    internal class PgSqlMasterdataRequests {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PgSqlMasterdataRequests() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FasTnT.Persistence.Dapper.PgSqlMasterdataRequests", typeof(PgSqlMasterdataRequests).Assembly);
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
        ///   Looks up a localized string similar to SELECT masterdata_type AS parent_type, masterdata_id AS parent_id, id, value FROM cbv.attribute WHERE masterdata_id = ANY(@ids).
        /// </summary>
        internal static string AllAttributeQuery {
            get {
                return ResourceManager.GetString("AllAttributeQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO cbv.attribute_field(internal_id, internal_parent_id, masterdata_id, masterdata_type, parent_id, name, namespace, value) VALUES(@id, @internalparentid, @masterdataid, @masterdatatype, @parentid, @name, @namespace, @value);.
        /// </summary>
        internal static string AttributeFieldInsert {
            get {
                return ResourceManager.GetString("AttributeFieldInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO cbv.attribute(masterdata_id, masterdata_type, id, value) VALUES(@parentid, @parenttype, @id, @value) ON CONFLICT ON CONSTRAINT pk_cbv_masterdata_attribute DO UPDATE SET value = @value;.
        /// </summary>
        internal static string AttributeInsert {
            get {
                return ResourceManager.GetString("AttributeInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT masterdata_type AS parent_type, masterdata_id AS parent_id, id, value FROM cbv.attribute WHERE masterdata_id = ANY(@ids) AND id = ANY(@attributes).
        /// </summary>
        internal static string AttributeQuery {
            get {
                return ResourceManager.GetString("AttributeQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM cbv.attribute_field WHERE masterdata_type = @type AND masterdata_id = @id; DELETE FROM cbv.hierarchy WHERE type = @type AND (parent_id = @id OR children_id = @id); DELETE FROM cbv.attribute WHERE masterdata_id = @id AND masterdata_type = @type; DELETE FROM cbv.masterdata WHERE id = @id AND type = @type;.
        /// </summary>
        internal static string Delete {
            get {
                return ResourceManager.GetString("Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO cbv.hierarchy(type, parent_id, children_id) VALUES(@type, @parentid, @childrenid) ...;.
        /// </summary>
        internal static string HierarchyInsert {
            get {
                return ResourceManager.GetString("HierarchyInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO cbv.masterdata(id, type, created_on, last_update) VALUES(@id, @type, NOW(), NOW()) ON CONFLICT ON CONSTRAINT pk_cbv_masterdata DO UPDATE SET last_update = NOW();.
        /// </summary>
        internal static string Insert {
            get {
                return ResourceManager.GetString("Insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT md.type, md.id FROM cbv.masterdata md /**where**/ ORDER BY md.last_update DESC LIMIT @limit.
        /// </summary>
        internal static string Query {
            get {
                return ResourceManager.GetString("Query", resourceCulture);
            }
        }
    }
}
