using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseProcesser.BusinessLayer.Interfaces;
using CaseProcesser.BusinessLayer.Storages;
using CaseProcesser.Common;
using CaseProcesser.Models;
using Supeng.Common.IOs;

namespace CaseProcesser.BusinessLayer
{
    public class CaseMgr : ICaseMgr
    {
        private readonly CaseContext db;
        public CaseMgr()
        {
            db = new CaseContext();
        }

        public IStorage<Case, int> Storage
        {
            get
            {
                return new CaseStorage(db);
            }
        }

        public ObservableCollection<Case> GetCases()
        {
            var collection = new ObservableCollection<Case>();
            foreach (var c in db.Cases.Include(i => i.Activities))
            {

                var directory = Path.Combine(DirectoryHelper.CurrentDirectory, "Attachments", c.CRNumber);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                c.Attachments.Clear();
                foreach (var file in Directory.GetFiles(directory, "*", SearchOption.AllDirectories))
                {
                    c.Attachments.Add(new Attachment
                    {
                        Name = Path.GetFileName(file),
                        FileName = file
                    });
                }
                collection.Add(c);
            }
            return collection;
        }

        public void AddActivity(int caseId, Activity activity)
        {
            var item = Storage.Select(caseId);
            if (item == null)
                throw new KeyNotFoundException(string.Format("Cannot found case id:{0}", caseId));
            item.Activities.Add(activity);
            db.SaveChanges();
        }

    }
}
