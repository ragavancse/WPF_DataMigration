﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.Core.Services;

namespace Northwind.Service.Interfaces
{
	public interface IMetaDataService : IService<mapSourceDest>
	{
		List<mapSourceDest> GetALL();

	}
}
