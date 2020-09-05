﻿using System;
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
	public class MetaDataService : Service<mapSourceDest>, IMetaDataService
	{
		public MetaDataService(IRepository<mapSourceDest> repository) : base(repository)
		{

		}
		public List<mapSourceDest> GetALL()
		{
			using (var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>())
			{
				var configurations = unitOfWork.Repository<mapSourceDest>().List().ToList();
				return configurations;
			}
		}
	}
}
