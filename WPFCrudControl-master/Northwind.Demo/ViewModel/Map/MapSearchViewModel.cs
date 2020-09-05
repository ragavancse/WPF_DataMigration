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

namespace Northwind.Demo.ViewModel.Map
{

	public class MapSearchViewModel : SearchCriteriaBase<sourceTableColumn>
	{
		public MapSearchViewModel() : base()
		{

		}
		//public MapSearchViewModel(IRepository<FileReference> repository)
		//{
		//	FileReferences = repository.Queryable().ToList();
		//}

		public List<FileReference> FileReferences
		{
			get => _fileReferences;
			set
			{
				if (_fileReferences != value)
				{
					_fileReferences = value;
					RaisePropertyChanged(() => FileReferences);
				}
			}
		}

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

		private int? _fileReferenceId;
		private List<FileReference> _fileReferences;

		public int? fileReferenceId
		{
			get { return _fileReferenceId; }
			set
			{
				if (_fileReferenceId != value)
				{
					_fileReferenceId = value;
					RaisePropertyChanged(() => fileReferenceId);
				}
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
			fileReferenceId = null;
			Description = string.Empty;
		}

		public override Expression<Func<sourceTableColumn, bool>> GetSearchCriteria()
		{
			return
				sourceTableColumn =>
					fileReferenceId != null ||
					 sourceTableColumn.fileReferenceId == fileReferenceId;
		}
	}
}
