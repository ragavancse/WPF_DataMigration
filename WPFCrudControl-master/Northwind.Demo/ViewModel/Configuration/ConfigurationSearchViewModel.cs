using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConfigurationData.Data;
using GenericCodes.Core.Repositories;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.DAL.Models;
using PropertyChanged;

namespace Northwind.Demo.ViewModel.Configurations
{

	public class ConfigurationsSearchViewModel : SearchCriteriaBase<Configuration>
	{
		public ConfigurationsSearchViewModel() : base()
		{

		}
		//public ConfigurationsSearchViewModel(IRepository<Configuration> categoryRepo, IRepository<ConfigurationUser> suppierRepo)
		//{
		//	Categories = categoryRepo.Queryable().ToList();
		//	Suppliers = suppierRepo.Queryable().ToList();
		//}

		private string _description;
		public string Description
		{
			get { return _description; }
			set
			{
				if (_description != value)
				{
					_description = value;
					RaisePropertyChanged(() => Description);
				}
			}
		}

		private int? _supplierIDSearchCriteria;
		public int? SupplierIDSearchCriteria
		{
			get { return _supplierIDSearchCriteria; }
			set
			{
				if (_supplierIDSearchCriteria != value)
				{
					_supplierIDSearchCriteria = value;
					RaisePropertyChanged(() => SupplierIDSearchCriteria);
				}
			}
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

		//private List<Category> _categories;
		//public List<Category> Categories
		//{
		//	get { return _categories; }
		//	set
		//	{
		//		_categories = value;
		//		RaisePropertyChanged(() => Categories);
		//	}
		//}
		//private List<Supplier> _suppliers;
		//public List<Supplier> Suppliers
		//{
		//	get { return _suppliers; }
		//	set
		//	{
		//		_suppliers = value;
		//		RaisePropertyChanged(() => Suppliers);
		//	}
		//}
		//public override Expression<Func<Product, bool>> GetSearchCriteria()
		//{
		//	return
		//		product =>
		//			(string.IsNullOrEmpty(ProductNameSearchCriteria) ||
		//			 product.ProductName.Contains(ProductNameSearchCriteria)) &&
		//			(SupplierIDSearchCriteria == null || product.SupplierID == SupplierIDSearchCriteria) &&
		//			(CategoryIDSearchCriteria == null || product.CategoryID == CategoryIDSearchCriteria);
		//}

		public override void ResetSearchCriteria()
		{
			Description = string.Empty;
		}

		public override Expression<Func<Configuration, bool>> GetSearchCriteria()
		{
			return
				product =>
					(string.IsNullOrEmpty(Description) ||
					 product.ConfigurationDescription.Contains(Description));
		}
	}
}
