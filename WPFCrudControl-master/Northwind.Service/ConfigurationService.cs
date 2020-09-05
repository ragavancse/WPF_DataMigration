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

	public class ConfigurationService : Service<Configuration>, IConfigurationService
	{
		public ConfigurationService(IRepository<Configuration> repository) : base(repository)
		{

		}
		public List<Configuration> GetALL()
		{
			using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
			{
				var configurations = unitOfWork.Repository<Configuration>().List().ToList();
				return configurations;
			}
		}
	}
}
