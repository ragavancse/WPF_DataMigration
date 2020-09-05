using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.Core.Services;
using Northwind.DAL.Models;

namespace Northwind.Service.Interfaces
{
	public interface IFileReferenceService : IService<FileReference>
	{
		List<FileReference> GetALL();
	}
}
