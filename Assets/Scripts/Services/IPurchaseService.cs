using System;

namespace Assets.Scripts.Services
{
    public interface IPurchaseService
    {
        void PurchaseItem(string key, Action onComplete, Action onFail);
    }
}
