using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Store
{
    internal class CurrencyItemView : ItemView
    {
        [SerializeField] private TMP_Text _amount;
        [SerializeField] private Image _img;

        public override void Init(ItemModel data)
        {
            var specialData = data as CurrencyItem;
            _price.text = specialData.price.ToString();
            _currency.text = specialData.currency.ToString();
            _amount.text = specialData.amount.ToString();
            _img.sprite = Resources.Load<Sprite>(data.key);
            _key = data.key;
        }
    }
}
