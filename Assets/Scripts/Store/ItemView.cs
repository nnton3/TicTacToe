using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Store
{
    public abstract class ItemView : MonoBehaviour
    {
        public event EventHandler<string> OnClickPurchase;
        [SerializeField] protected TMP_Text _price, _currency;
        [SerializeField] private Button _buyBtn;
        protected string _key;

        private void Awake()
        {
            _buyBtn.onClick.AddListener(() => OnClickPurchase?.Invoke(this, _key));
        }

        public abstract void Init(ItemModel model);
    }
}
