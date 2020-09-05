using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.Core.Services;
using WpfApp2;

namespace Northwind.Service.Interfaces
{

	public interface ISourceTableColumnService : IService<sourceTableColumn>
	{
		List<sourceTableColumn> GetALL();

		List<mapSourceDestBuild_Get_Result> GetAll(int fileReferenceId, string fileName, string groupBy);
	}

}
