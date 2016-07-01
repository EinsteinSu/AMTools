namespace TroubleShooting.Commons.Interfaces
{
    internal interface IProgress
    {
        void ShowProgress(string text);
        void HideProgress();
    }
}