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
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("mapSourceDest", Schema = "meta")]
	public partial class mapSourceDest : GenericCodes.Core.Entities.Entity
	{
		public int mapSourceDestId { get; set; }
		public int sourceServerId { get; set; }
		public string sourceDatabase { get; set; }
		public string sourceSchema { get; set; }
		public string sourceTable { get; set; }
		public int step { get; set; }
		public string sourceColumn { get; set; }
		public string sourceDataType { get; set; }
		public string sourceColumnLen { get; set; }
		public Nullable<bool> sourceRequired { get; set; }
		public int destTableId { get; set; }
		public int destServerId { get; set; }
		public string destTable { get; set; }
		public string destColumn { get; set; }
		public string destDataType { get; set; }
		public string destColumnLen { get; set; }
		public Nullable<bool> destRequired { get; set; }
		public Nullable<System.DateTime> created { get; set; }
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
		public string requiredDataType { get; set; }
		public Nullable<bool> convertFlag { get; set; }
		public string sourceColumnOrig { get; set; }
		public int fileReferenceId { get; set; }
		public string information { get; set; }
		public string fileName { get; set; }
		public string groupBy { get; set; }
	}
}
