using System.Collections.Generic;
using Assets.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Store
{
    public class Store : MonoBehaviour
    {
        [SerializeField] private GameObject _view;
        [SerializeField] private Button _openBtn, _closeBtn;
        private IStoreItemsProvider _itemsProvider;
        private IScreenBlockerService _screenBlocker;
        private IItemCreator _itemCreator;
        private List<ItemView> _itemViews;

        private void Awake()
        {
            _itemViews = new();

            _openBtn.onClick.AddListener(OpenBtnHandler);
            _closeBtn.onClick.AddListener(CloseBtnHandler);
        }

        public void Inject(IStoreItemsProvider itemsProvider, IScreenBlockerService screenBlocker, IItemCreator itemCreator)
        {
            _itemsProvider = itemsProvider;
            _screenBlocker = screenBlocker;
            _itemCreator = itemCreator;
        }

        public void Init()
        {
            _itemsProvider.GetItems(GetItemsCompleteHandler, GetItemsFailHandler);
        }

        private void GetItemsCompleteHandler(StoreModel model)
        {
            Debug.Log($"Store model was loaded");
            _screenBlocker.Hide();
            _view.SetActive(true);
            foreach (var item in model.shopItems)
                _itemViews.Add(
                    _itemCreator
                    .CreateItem(item)
                    .GetComponent<ItemView>());
        }

        private void GetItemsFailHandler()
        {
            Debug.Log($"Store model load failed");
            _screenBlocker.Hide();
        }

        private void OpenBtnHandler()
        {
            _screenBlocker.Show();
            Init();
        }

        private void CloseBtnHandler()
        {
            _view.SetActive(false);
        }
    }
}
