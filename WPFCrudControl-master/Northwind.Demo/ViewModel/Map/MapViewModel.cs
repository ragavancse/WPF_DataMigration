using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GenericCodes.CRUD.WPF.ViewModel.CRUDBases;
using Northwind.Service.Interfaces;
using ConfigurationData.Data;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using ExcelDataReader;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;

namespace Northwind.Demo.ViewModel.Map
{

	public class MapViewModel : GenericCrudBase<sourceTableColumn>
	{
		Dictionary<string, int> PropertyNames = new Dictionary<string, int>();

		private readonly ICommand _filePickerCommand;

		private ISourceTableColumnService _sourceTableColumnService;

		private List<sourceTableColumn> sourceTableColumns;

		public MapViewModel(
			MapSearchViewModel MapViewModel,
			MapAddEditViewModel MapAddEditViewModel,
			IFileReferenceService fileReferenceService,
			ISourceTableColumnService sourceTableColumnService)
			: base(MapViewModel, MapAddEditViewModel)
		{

			_fileReferenceId = -1;
			_sourceTableColumnService = sourceTableColumnService;
			PropertyNames.Add("mapSourceDestId", 1);
			PropertyNames.Add("sourceServerId", 2);
			PropertyNames.Add("sourceSchema", 3);
			PropertyNames.Add("sourceTable", 4);
			PropertyNames.Add("sourceColumn", 5);
			PropertyNames.Add("sourceDataType", 6);
			PropertyNames.Add("sourceColumnLen", 7);
			PropertyNames.Add("destTableId", 8);
			PropertyNames.Add("destServerId", 9);
			PropertyNames.Add("destTable", 10);
			PropertyNames.Add("destColumn", 11);
			PropertyNames.Add("destDataType", 12);
			PropertyNames.Add("destColumnLen", 13);
			PropertyNames.Add("destRequired", 14);
			PropertyNames.Add("created", 15);
			PropertyNames.Add("displayColName", 16);
			PropertyNames.Add("defaultValue", 17);
			PropertyNames.Add("baseTable", 18);
			PropertyNames.Add("requiredDataType", 19);
			PropertyNames.Add("fileReferenceId", 20);
			PropertyNames.Add("information", 21);
			PropertyNames.Add("sourceDatabase", 22);
			PropertyNames.Add("fileName", 23);
			PropertyNames.Add("groupBy", 24);


			FilePickerCommand = new RelayCommand(OnFilePicker);

			SaveAllCommand = new RelayCommand(OnSaveAll);

			//ListingIncludes = new Expression<Func<Map, object>>[]
			//{
			//	p => p.MapUser
			//};


			var files = new List<FileReference>();
			files.Add(new FileReference { fileName = "--Select_AllFiles--", fileReferenceId = -1 });
			var _files = fileReferenceService.GetALL();
			foreach (var item in _files)
			{
				files.Add(item);
			}

			FileReferences = files;

			PostDataRetrievalDelegate = (list) =>
			{
				sourceTableColumns = list;

			};

			PostAddEditDelegate = (PopupType) =>
			 {
				 if (PopupType == GenericCodes.CRUD.WPF.Core.PopupTypeEnum.Add)
				 {
					 DataList.Insert(0, AddEditEntityViewModel.Entity);
				 }
				 else
				 {
					 int index = DataList.IndexOf(AddEditEntityViewModel.Entity);
					 if (index != -1)
					 {
						 DataList.Remove(AddEditEntityViewModel.Entity);
						 DataList.Insert(index, AddEditEntityViewModel.Entity);
					 }
				 }
			 };


			EnableSortingPaging = false;
			PreAddEditDelegate = (type) =>
			{
				//MapAddEditViewModel.MapUsers = Mapervice.GetALL();
				//MapViewModel.MapUsers = Mapervice.GetALL();
			};

		}

		private int? _fileReferenceId;
		private List<FileReference> _fileReferences;

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

		public int? fileReferenceId
		{
			get { return _fileReferenceId; }
			set
			{
				if (_fileReferenceId != value)
				{
					_fileReferenceId = value;

					if (_fileReferenceId != null)
					{
						if (DataList == null)
						{
							DataList = new System.Collections.ObjectModel.ObservableCollection<sourceTableColumn>();
						}
						DataList.Clear();
						if (fileReferenceId == -1)
						{
							foreach (var item in sourceTableColumns)
							{
								DataList.Add(item);
							}
						}
						else
						{
							var list = _sourceTableColumnService.GetAll(
								_fileReferenceId.Value,
								 FileReferences.FirstOrDefault(f => f.fileReferenceId == _fileReferenceId).fileName,
								 "");
							foreach (var item in list)
							{
								//DataList.Add(item);
							}
						}
					}
					RaisePropertyChanged(() => fileReferenceId);
				}
			}
		}

		private void OnSaveAll(object obj)
		{
			try
			{
				DataTable table = ToDataTable(DataList.ToList());

				//string constring = "Data Source=.;Initial Catalog=dataMigration;Integrated Security=True;";
				using (SqlConnection con = new SqlConnection(App.ConnectionString))
				{
					using (SqlCommand cmd = new SqlCommand("[api].[mapSourceDest_Set]", con))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add("@data", SqlDbType.Structured).Value = table;
						cmd.Parameters.Add("@fileName", SqlDbType.VarChar).Value = Path.GetFileName(openFileDlg.FileName);
						cmd.Parameters.Add("@directory", SqlDbType.VarChar).Value = Path.GetDirectoryName(openFileDlg.FileName);
						cmd.Parameters.Add("@fileType", SqlDbType.VarChar).Value = "CSV";
						con.Open();
						cmd.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{

			}
		}

		public DataTable ToDataTable<T>(List<T> items)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);
			//Get all the properties by using reflection   
			var Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => PropertyNames.Select(a => a.Key).Contains(p.Name))
				.OrderBy(p => PropertyNames[p.Name]).ToArray();

			foreach (var prop in Props)
			{
				//Setting column names as Property names  
				dataTable.Columns.Add(prop.Name);
			}

			foreach (T item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}

			return dataTable;
		}

		private bool ConvertBooleanParseData(int i, string propertyName)
		{
			try
			{
				return !string.IsNullOrEmpty(dataTable.Rows[i][propertyName].ToString()) ? Convert.ToBoolean(dataTable.Rows[i]["sourceRequired"].ToString()) : false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}


		private string ConvertStringParseData(int i, string propertyName)
		{
			try
			{
				return dataTable.Rows[i][propertyName].ToString();
			}
			catch (Exception ex)
			{
				return "";
			}
		}

		private DataTable dataTable;

		Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

		private void OnFilePicker(object obj)
		{
			openFileDlg.DefaultExt = ".xls";
			openFileDlg.Filter = "EXCEL (.xls)|*.xls";
			// Launch OpenFileDialog by calling ShowDialog method
			Nullable<bool> hasResult = openFileDlg.ShowDialog();
			if (hasResult != null)
			{
				using (var reader = ExcelReaderFactory.CreateReader(openFileDlg.OpenFile()))
				{

					// 2. Use the AsDataSet extension method
					var result = reader.AsDataSet(new ExcelDataSetConfiguration()
					{
						// Gets or sets a value indicating whether to set the DataColumn.DataType 
						// property in a second pass.
						UseColumnDataType = true,

						// Gets or sets a callback to determine whether to include the current sheet
						// in the DataSet. Called once per sheet before ConfigureDataTable.
						FilterSheet = (tableReader, sheetIndex) => true,

						// Gets or sets a callback to obtain configuration options for a DataTable. 
						ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
						{
							// Gets or sets a value indicating the prefix of generated column names.
							EmptyColumnNamePrefix = "Column",

							// Gets or sets a value indicating whether to use a row from the 
							// data as column names.
							UseHeaderRow = true,

							// Gets or sets a callback to determine which row is the header row. 
							// Only called when UseHeaderRow = true.
							ReadHeaderRow = (rowReader) =>
							{
								// F.ex skip the first row and use the 2nd row as column headers:
								rowReader.Read();
							},

							// Gets or sets a callback to determine whether to include the 
							// current row in the DataTable.
							FilterRow = (rowReader) =>
							{
								return true;
							},

							// Gets or sets a callback to determine whether to include the specific
							// column in the DataTable. Called once per column after reading the 
							// headers.
							FilterColumn = (rowReader, columnIndex) =>
							{
								if (rowReader.IsDBNull(columnIndex))
								{
									return false;
								}
								return true;
							}
						}
					});


					try
					{
						dataTable = result.Tables[0].Rows[0].Table;
					}
					catch (Exception ex)
					{

					}
				}
				// The result of each spreadsheet is in result.Tables
			}
		}


		public RelayCommand FilePickerCommand { get; }

		public RelayCommand SaveAllCommand { get; }
	}

}
