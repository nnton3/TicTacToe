using UnityEngine;

namespace Assets.Scripts.Store
{
    public interface IItemCreator
    {
        ItemView CreateItem(ItemModel itemData, Transform parent);
    }
}
