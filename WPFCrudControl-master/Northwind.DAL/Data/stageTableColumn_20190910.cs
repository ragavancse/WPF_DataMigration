//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConfigurationData.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class stageTableColumn_20190910
    {
        public int stageTableColumnId { get; set; }
        public Nullable<int> stageTableId { get; set; }
        public int sourceServerId { get; set; }
        public string sourceSchema { get; set; }
        public string sourceTable { get; set; }
        public int step { get; set; }
        public string sourceColumn { get; set; }
        public string sourceDataType { get; set; }
        public string sourceColumnLen { get; set; }
        public Nullable<bool> required { get; set; }
        public Nullable<System.DateTime> createdDateTime { get; set; }
        public Nullable<bool> src { get; set; }
        public Nullable<bool> load { get; set; }
        public Nullable<bool> persist { get; set; }
        public Nullable<bool> consolidate { get; set; }
        public Nullable<bool> validate { get; set; }
        public Nullable<bool> lookup { get; set; }
        public Nullable<bool> trim_l { get; set; }
        public Nullable<bool> trim_r { get; set; }
        public string displayColName { get; set; }
        public Nullable<int> seq { get; set; }
        public Nullable<bool> defaultValueBit { get; set; }
        public Nullable<bool> touched { get; set; }
        public string defaultValue { get; set; }
        public string baseTable { get; set; }
    }
}
