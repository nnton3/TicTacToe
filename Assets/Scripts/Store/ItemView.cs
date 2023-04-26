using TMPro;
using UnityEngine;

namespace Assets.Scripts.Store
{
    public abstract class ItemView : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _price, _currency;

        public abstract void Init(ItemModel json);
    }
}
