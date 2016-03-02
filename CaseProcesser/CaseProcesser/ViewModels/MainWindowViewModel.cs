using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using CaseProcesser.BusinessLayer;
using CaseProcesser.BusinessLayer.Interfaces;
using CaseProcesser.Common;
using CaseProcesser.Models;
using CaseProcesser.ViewModels.DialogWindows;
using Microsoft.Win32;
using Newtonsoft.Json;
using Supeng.Common.IOs;
using Supeng.Office;
using Supeng.Wpf.Common.DialogWindows;

namespace CaseProcesser.ViewModels
{
    public class MainWindowViewModel : ModelBase
    {
        private readonly ICaseMgr _caseMgr;
        private ObservableCollection<Case> _collection;
        private Case _currentItem;
        private bool _fromLoadFile;

        public MainWindowViewModel()
        {
            _caseMgr = new CaseMgr();
            Collection = _caseMgr.GetCases();
        }

        public MainWindowViewModel(ICaseMgr caseMgr)
        {
            _caseMgr = caseMgr;
        }

        #region Main Menu

        public void Open()
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = "*.json",
                Filter = "Json files|*.json"
            };
            var showDialog = dialog.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                var data = File.ReadAllText(dialog.FileName);
                Collection = JsonConvert.DeserializeObject<ObservableCollection<Case>>(data);
                _fromLoadFile = true;
            }
        }

        public void Save()
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "*.json",
                Filter = "Json files|*.json"
            };
            var showDialog = dialog.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                var data = JsonConvert.SerializeObject(Collection);
                File.WriteAllText(dialog.FileName, data);
            }
        }
        #endregion

        #region Other Menu Operations
        public void OpenWebsite()
        {
            if (CurrentItem == null)
                return;
            Process.Start(CurrentItem.CaseUrl);
        }

        public void ExportToExcel()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel files|*.xlsx";
            var showDialog = saveFileDialog.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                using (var excel = new ExcelOperationBase())
                {
                    var workSheet = excel.CreateSheet("Cases");
                    excel.CreateTable(workSheet, new CaseTableInfo(Collection));
                    excel.Save(saveFileDialog.FileName);
                }
            }
        }

        public void OpenAttachmentFolder()
        {
            if (CurrentItem == null)
                return;
            Process.Start(Path.Combine(DirectoryHelper.CurrentDirectory, "Attachments", CurrentItem.CRNumber));
        }

        public void OpenAttachment(string fileName)
        {
            if (CurrentItem == null)
                return;
            Process.Start(fileName);
        }

        public void EditEnvironment()
        {
            if (CurrentItem == null)
                return;
            var viewModel = new EnvironmentEditViewModel(CurrentItem.Environment);
            if (viewModel.ShowDialogWindowWithReturn())
            {
                CurrentItem.Environment = viewModel.Data;
                SaveCase();
            }
        }

        public void EditTag()
        {
            if (CurrentItem == null)
                return;
            var viewModel = new TagEditViewModel(CurrentItem.Tag);
            if (viewModel.ShowDialogWindowWithReturn())
            {
                CurrentItem.Tag = viewModel.Data;
                SaveCase();
            }
        }

        public void AddActivity()
        {
            if (CurrentItem == null)
                return;
            var viewModel = new ActivityEditViewModel(new Activity());
            if (viewModel.ShowDialogWindowWithReturn())
            {
                CurrentItem.Activities.Add(viewModel.Data);
                SaveCase();
            }
        }
        #endregion

        #region Case Edit

        public void AddCase()
        {
            if (_fromLoadFile)
                return;
            CaseEdit(new Case(), _caseMgr.Storage.Insert);
        }

        public void UpdateCase()
        {
            if (CurrentItem == null || _fromLoadFile)
                return;
            CaseEdit(CurrentItem, _caseMgr.Storage.Update);
        }

        public void DeleteCase()
        {
            if (CurrentItem == null || _fromLoadFile)
                return;
            if (MessageBox.Show("Are you sure delete this case?", "Delete case", MessageBoxButton.OKCancel) ==
                MessageBoxResult.OK)
            {
                _caseMgr.Storage.Delete(CurrentItem.CaseId);
                Collection = _caseMgr.GetCases();
            }
        }

        public void UpdateInternalStatus(string internalStatus)
        {
            if (CurrentItem == null || _fromLoadFile)
                return;
            int status;
            int.TryParse(internalStatus, out status);
            CurrentItem.InternalStatus = (InternalStatus)status;
            SaveCase();
        }

        public void SaveCase()
        {
            if (CurrentItem == null || _fromLoadFile)
                return;
            _caseMgr.Storage.Update(CurrentItem);
            Collection = _caseMgr.GetCases();
        }

        private void CaseEdit(Case c, Action<Case> action)
        {
            var viewModel = new CaseEditViewModel(c);
            if (viewModel.ShowDialogWindowWithReturn())
            {
                action(viewModel.Data);
                Collection = _caseMgr.GetCases();
            }
        }

        #endregion

        #region Properties

        public Case CurrentItem
        {
            get { return _currentItem; }
            set
            {
                if (Equals(value, _currentItem)) return;
                _currentItem = value;
                NotifyOfPropertyChange(() => CurrentItem);
            }
        }

        public ObservableCollection<Case> Collection
        {
            get { return _collection; }
            set
            {
                if (Equals(value, _collection)) return;
                _collection = value;
                NotifyOfPropertyChange(() => Collection);
            }
        }

        #endregion
    }


    //todo: change the menu to collection that bingding to main window
    public class MenuModel
    {
        public MenuModel(string header, string methodName)
        {
            Header = header;
            MethodName = methodName;
        }

        public string Header { get; set; }

        public string MethodName { get; set; }
    }
}