using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.Core.DbContext;

namespace Northwind.DAL
{
	public partial class DataMigrationContext : ApplicationDbContext//, GenericCodes.Core.IDisposable
	{
		//public bool IsDisposed { get; private set; }
		public DataMigrationContext()
			: base("name=DataMigrationContext")
		{
		}


		public DbSet<Configuration> Configurations { get; set; }
		public DbSet<ConfigurationUser> ConfigurationUsers { get; set; }
		public DbSet<FileReference> FileReferences { get; set; }
		public DbSet<mapSourceDest> MapSourceDests { get; set; }
		public DbSet<sourceTableColumn> SourceTableColumns { get; set; }

	}

}
