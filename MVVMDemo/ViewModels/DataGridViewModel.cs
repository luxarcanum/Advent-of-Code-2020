using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MVVMDemo.Models;
using MVVMDemo.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{

    class DataGridViewModel : BindableBase
    {
        #region Properties
        private List<ResourceModel> _plannedResourceList;
        public List<ResourceModel> PlannedResourceList { get => _plannedResourceList; set => SetProperty(ref _plannedResourceList, value); }

        private ResourceModel _selectedResource;
        public ResourceModel SelectedResource { get => _selectedResource; set => SetProperty(ref _selectedResource, value); }

        public string RnDInputPathName = @"D:\Users\U.6074887\Outputs\RnD_InputFile.xlsx";

        private string _importPath;
        private string _importFile;
        private string _exportPath;
        private string _exportFile;
       
        public string ImportPath { get => _importPath; set => SetProperty(ref _importPath, value); }
        public string ImportFile { get => _importFile; set => SetProperty(ref _importFile, value); }
        public string ExportPath { get => _exportPath; set => SetProperty(ref _exportPath, value); }
        public string ExportFile { get => _exportFile; set => SetProperty(ref _exportFile, value); }

        private DateTime _timeImportStarted;
        private DateTime _timeImportEnded;
        private DateTime _timeExportStarted;
        private DateTime _timeExportEnded;
        private int _importRecordCount;

        public DateTime TimeImportStarted { get => _timeImportStarted; set => SetProperty(ref _timeImportStarted, value); }  
        public DateTime TimeImportEnded { get => _timeImportEnded; set => SetProperty(ref _timeImportEnded, value); }        
        public DateTime TimeExportStarted { get => _timeExportStarted; set => SetProperty(ref _timeExportStarted, value); }   
        public DateTime TimeExportEnded { get => _timeExportEnded; set => SetProperty(ref _timeExportEnded, value); }
        public int ImportRecordCount { get => _importRecordCount; set => SetProperty(ref _importRecordCount, value); }


        private DataTable _excelImportedTable;
        public DataTable ExcelImportedTable { get => _excelImportedTable; set => SetProperty(ref _excelImportedTable, value); }

        private DataTable _originalImportTable;
        public DataTable OriginalImportTable { get => _originalImportTable; set => SetProperty(ref _originalImportTable, value); }

        private DataTable _matchedTable;
        public DataTable MatchedTable { get => _matchedTable; set => SetProperty(ref _matchedTable, value); }
        #endregion

        #region Command Properties
        public RelayCommand ChooseFileCommand { get; set; }
        public RelayCommand ImportFileCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }

        public RelayCommand FullThingCommand { get; set; }
        public RelayCommand ExportJsonCommand { get; set; }
        #endregion

        #region Constructor
        public DataGridViewModel()
        {
            LoadCommands();

            bool isD4D = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName == "columbus.local" ? true : false;

            ImportPath = isD4D ? @"D:\Users\U.6074887\Outputs" : @"\\p161wcsstoccg01.file.core.windows.net\isbc-wmbc-bdapps-resolver-group\Active BDApps\CTRP (CbCr, R&D, PB)\RnD Data";
            ImportFile = @"RnD_InputFile.xlsx";
            ExportPath = isD4D ? @"D:\Users\U.6074887\Outputs" : @"\\p161wcsstoccg01.file.core.windows.net\isbc-wmbc-bdapps-resolver-group\Active BDApps\CTRP (CbCr, R&D, PB)\RnD Data";
            ExportFile = @"RnD_InputFile.json";


        }
        #endregion

        #region Methods
        public void LoadCommands()
        {
            ChooseFileCommand = new RelayCommand(ExecuteImportOpenXMLCommand, CanExecuteImportOpenXMLCommand);
            ImportFileCommand = new RelayCommand(ExecuteImportFileCommand, CanExecuteImportFileCommand);
            ClearCommand = new RelayCommand(ExecuteClearCommand);
            FullThingCommand = new RelayCommand(ExecuteFullThingCommand, CanExecuteFullThingCommand);
            ExportJsonCommand = new RelayCommand(ExecuteExportJsonCommand, CanExecuteExportJsonCommand);
        }

       
        #endregion

        #region Command Methods

        #region Open Excel File Commands
        private bool CanExecuteImportOpenXMLCommand()
        {
            return true;
        }

        private void ExecuteImportOpenXMLCommand()
        {
            try
            {
                // find file
                FileUtilities fileUtils = new FileUtilities();
                string fileName;
                fileName = fileUtils.OpenFile(null, "xlsx");

                // Open File
                ExcelImportedTable = Read(fileName);
                OriginalImportTable = ExcelImportedTable.Copy();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Unable to retrieve import data." + Environment.NewLine + Environment.NewLine
                    + "Error: " + ex.Message
                    , "Error Testing", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve import data." + Environment.NewLine + Environment.NewLine
                    + "Error: " + e.Message
                    , "Error Testing", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            
        }
        #endregion

        #region Path from string with file name Commands
        private bool CanExecuteImportFileCommand()
        {
            if (ImportPath == "" || ImportFile == "") return false;
            return true;
        }

        private void ExecuteImportFileCommand()
        {
            try
            {
                TimeImportStarted = DateTime.Now;
                // Open File
                ExcelImportedTable = Read(ImportPath + "\\" + ImportFile);
                TimeImportEnded = DateTime.Now;
                OriginalImportTable = ExcelImportedTable.Copy();
                ImportRecordCount = OriginalImportTable.Rows.Count;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to retrieve import data." + Environment.NewLine + Environment.NewLine
                    + "Error: " + e.Message
                    , "Error Testing", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        #endregion

        #region Do Lookups Commands
        private bool CanExecuteDoLookupsCommand()
        {
            return true;
        }

        private void ExecuteDoLookupsCommand()
        {
            #region Attempt lookups

            #endregion
        }
        #endregion

        #region Clear DataTable
        private void ExecuteClearCommand()
        {
            OriginalImportTable = new DataTable();
        }
        #endregion

        #region Export DataTable as Json
        private bool CanExecuteExportJsonCommand()
        {
            if (ExportPath == "" || ExportFile == "") return false;
            return true;
        }

        private void ExecuteExportJsonCommand()
        {
            TimeExportStarted = DateTime.Now;

            string serializedData = JsonConvert.SerializeObject(OriginalImportTable);
            System.IO.File.WriteAllText(ExportPath + "\\" + ExportFile, serializedData);
            TimeExportEnded = DateTime.Now;
        }
        #endregion

        #region Import Excel > Export DataTable as Json
        private bool CanExecuteFullThingCommand()
        {
            return true;
        }

        private void ExecuteFullThingCommand()
        {
            TimeImportStarted = DateTime.Now;
            OriginalImportTable = Read(ImportPath + "\\" + ImportFile);
            TimeImportEnded = DateTime.Now;
            ImportRecordCount = OriginalImportTable.Rows.Count;
            TimeExportStarted = DateTime.Now;
            string serializedData = JsonConvert.SerializeObject(OriginalImportTable);
            System.IO.File.WriteAllText(ExportPath + "\\" + ExportFile, serializedData);
            TimeExportEnded = DateTime.Now;
        }
        #endregion

        #endregion

        #region Other Methods
        public static DataTable Read(string path)
        {
            DataTable dt = new DataTable();

            using (SpreadsheetDocument ssDoc = SpreadsheetDocument.Open(path, false))
            {
                var sheets = ssDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)ssDoc.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                List<Row> rows = sheetData.Descendants<Row>().ToList();

                // Add Headers from Row 0
                foreach (Cell cell in rows.ElementAt(0))
                {
                    dt.Columns.Add(GetCellValue(ssDoc, cell));
                }

                foreach (Row row in rows) // This includes header row
                {
                    DataRow tempRow = dt.NewRow();

                    int colCount = row.Descendants<Cell>().Count();
                    foreach (Cell cell in row.Descendants<Cell>())
                    {
                        int index = GetIndex(cell.CellReference);

                        // Add Columns
                        for (int i = dt.Columns.Count; i <= index; i++)
                            dt.Columns.Add();

                        tempRow[index] = GetCellValue(ssDoc, cell);
                    }
                    dt.Rows.Add(tempRow);
                }
                dt.Rows.RemoveAt(0); // Remove Header row from Data rows
            }
            return dt;
        }

        private static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                return stringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;

            return value;
        }

        public static int GetIndex(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return -1;

            int index = 0;
            foreach (var ch in name)
            {
                if (char.IsLetter(ch))
                {
                    int value = ch - 'A' + 1;
                    index = value + index * 26;
                }
                else
                {
                    break;
                }
            }
            return index - 1;
        }
        #endregion
    }
}
