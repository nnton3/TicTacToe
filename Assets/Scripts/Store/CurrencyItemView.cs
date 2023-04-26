using TMPro;
using UnityEngine;

namespace Assets.Scripts.Store
{
    internal class CurrencyItemView : ItemView
    {
        [SerializeField] private TMP_Text _amount;

        public override void Init(ItemModel data)
        {
            var specialData = data as CurrencyItem;
            _price.text = specialData.price.ToString();
            _currency.text = specialData.currency.ToString();
            _amount.text = specialData.amount.ToString();
        }
    }
}
