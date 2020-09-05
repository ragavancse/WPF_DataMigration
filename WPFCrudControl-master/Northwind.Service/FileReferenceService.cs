using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.Core.Repositories;
using GenericCodes.Core.Services;
using GenericCodes.Core.UnitOfWork;
using Microsoft.Practices.ServiceLocation;
using Northwind.Service.Interfaces;

namespace Northwind.Service
{

	public class FileReferenceService : Service<FileReference>, IFileReferenceService
	{
		public FileReferenceService(IRepository<FileReference> repository) : base(repository)
		{

		}
		public List<FileReference> GetALL()
		{
			using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
			{
				var fileReferences = unitOfWork.Repository<FileReference>().List().ToList();
				return fileReferences;
			}
		}
	}
}
