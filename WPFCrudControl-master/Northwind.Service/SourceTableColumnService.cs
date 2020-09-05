using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.Core.Repositories;
using Northwind.DAL.Models;
using Northwind.Service.Interfaces;
using GenericCodes.Core.Services;
using GenericCodes.Core.UnitOfWork;
using Microsoft.Practices.ServiceLocation;
using ConfigurationData.Data;
using System.Data.SqlClient;
using WpfApp2;

namespace Northwind.Service
{
	public class SourceTableColumnService : Service<sourceTableColumn>, ISourceTableColumnService
	{
		public SourceTableColumnService(IRepository<sourceTableColumn> repository) : base(repository)
		{

		}
		public List<sourceTableColumn> GetALL()
		{
			using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
			{
				var categories = unitOfWork.Repository<sourceTableColumn>().List().ToList();
				return categories;
			}
		}

		public List<mapSourceDestBuild_Get_Result> GetAll(int fileReferenceId, string fileName, string groupBy)
		{
			try
			{
				string spName = "exec [api].[mapSourceDestBuild_Get] @fileReferenceId,@fileName,@groupBy";
				List<SqlParameter> sqlParameters = new List<SqlParameter> {
				new SqlParameter("fileReferenceId", fileReferenceId),
				new SqlParameter("fileName", fileName),
				new SqlParameter("groupBy", groupBy),
			};
				using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
				{
					var categories = unitOfWork.Repository<mapSourceDestBuild_Get_Result>().List(spName,
						new SqlParameter("fileReferenceId", fileReferenceId),
						new SqlParameter("fileName", fileName),
						new SqlParameter("groupBy", groupBy));
					return categories.ToList();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
