using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ConfigurationData.Data
{
	[Table("configuration")]
	public partial class Configuration : GenericCodes.Core.Entities.Entity
	{
		private ConfigurationUser _configurationUser;

		[Column("configurationId")]
		public int ConfigurationId { get; set; }

		[Column("configurationValue")]
		public string ConfigurationValue { get; set; }
		[Column("configurationDescription")]
		public string ConfigurationDescription { get; set; }
		[Column("configurationVariable")]
		public string ConfigurationVariable { get; set; }
		public Nullable<bool> required { get; set; }
		public Nullable<System.DateTime> created { get; set; }
	}
}
