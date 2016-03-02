using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CaseProcesser.BusinessLayer.Interfaces;
using CaseProcesser.Common;
using CaseProcesser.Models;

namespace CaseProcesser.BusinessLayer.Storages
{
    public class CaseStorage : IStorage<Case, int>
    {
        private readonly CaseContext _db;

        public CaseStorage(CaseContext db)
        {
            _db = db;
        }

        public Case Select(int id)
        {
            return _db.Cases.FirstOrDefault(f => f.CaseId == id);
        }

        public void Insert(Case data)
        {
            _db.Cases.Add(data);
            _db.SaveChanges();
        }

        public void Update(Case data)
        {
            _db.Entry(data).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Select(id);
            if (item == null)
                throw new KeyNotFoundException(string.Format("Cannot found case id:{0}", id));
            _db.Cases.Remove(item);
            _db.SaveChanges();
        }
    }
}