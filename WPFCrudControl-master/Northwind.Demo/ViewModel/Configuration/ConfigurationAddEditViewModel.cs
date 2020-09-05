using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;

namespace Northwind.Demo.ViewModel.Configurations
{

	public class ConfigurationAddEditViewModel : AddEditEntityBase<Configuration>
	{
		public ConfigurationAddEditViewModel()
		{

		}

		private List<ConfigurationUser> _configurationUsers;
		public List<ConfigurationUser> ConfigurationUsers
		{
			get
			{
				return _configurationUsers;
			}
			set
			{
				_configurationUsers = value;
				RaisePropertyChanged(() => ConfigurationUsers);
			}
		}

	}
}
