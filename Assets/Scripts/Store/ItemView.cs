using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Store
{
    public abstract class ItemView : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _price, _currency;
        [SerializeField] private Button _buyBtn;

        public abstract void Init(ItemModel model);
    }
}
