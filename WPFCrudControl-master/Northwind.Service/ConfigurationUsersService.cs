using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
	public class ConfigurationUsersService : Service<ConfigurationUser>, IConfigurationUsersService
	{
		public ConfigurationUsersService(IRepository<ConfigurationUser> repository) : base(repository)
		{

		}
		public List<ConfigurationUser> GetALL()
		{
			using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
			{
				var configurations = unitOfWork.Repository<ConfigurationUser>().List().ToList();
				return configurations;
			}
		}
	}
}
