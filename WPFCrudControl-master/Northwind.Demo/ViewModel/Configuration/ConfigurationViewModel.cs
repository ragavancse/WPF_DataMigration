using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.Service.Interfaces;

namespace Northwind.Demo.ViewModel.Configurations
{

	public class ConfigurationViewModel : GenericCrudBase<Configuration>
	{
		public ConfigurationViewModel(ConfigurationsSearchViewModel configurationViewModel,
			ConfigurationAddEditViewModel configurationAddEditViewModel, IConfigurationUsersService configurationService)
			: base(configurationViewModel, configurationAddEditViewModel)
		{

			//ListingIncludes = new Expression<Func<Configuration, object>>[]
			//{
			//	p => p.ConfigurationUser
			//};

			PostDataRetrievalDelegate = (list) =>
			{


			};
			EnableSortingPaging = false;
			PreAddEditDelegate = (type) =>
			{
				configurationAddEditViewModel.ConfigurationUsers = configurationService.GetALL();
				configurationViewModel.ConfigurationUsers = configurationService.GetALL();
			};

		}
	}

}
