using System.Collections.ObjectModel;
using CaseProcesser.Models;

namespace CaseProcesser.BusinessLayer.Interfaces
{
    public interface ICaseMgr
    {
        IStorage<Case, int> Storage { get; }

        ObservableCollection<Case> GetCases();

        void AddActivity(int caseId, Activity activity);
    }
}