using UnityEngine;

namespace Assets.Scripts.Store
{
    public class ItemsPackCreator : MonoBehaviour, IItemCreator
    {
        [SerializeField] private ItemCreator _creator;
        [SerializeField] private GameObject _pref;

        public ItemView CreateItem(ItemModel itemData, Transform parent)
        {
            var specialData = itemData as ItemsPack;
            var packContainer = Instantiate(_pref, parent).transform;
            var view = packContainer.GetComponent<ItemsPackView>();
            foreach (var item in specialData.items)
                _creator.CreateItem(item, view.ItemsParent);

            view.Init(itemData);
            return view;
        }
    }
}
