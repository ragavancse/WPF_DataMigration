using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using ConfigurationData.Data;

namespace Northwind.Demo.ViewModel.Imports
{

	public class ImportAddEditViewModel : AddEditEntityBase<mapSourceDest>
	{
		public ImportAddEditViewModel()
		{

		}

		public override void Save()
		{
			//base.Save();
			IsSavedSuccessfully = true;
			this.CloseAssociatedWindow();
		}
	}
}
