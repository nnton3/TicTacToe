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
        [SerializeField] private Transform _itemsParent;
        private IStoreItemsProvider _itemsProvider;
        private IScreenBlockerService _screenBlocker;
        private IItemCreator _itemCreator;
        private List<ItemView> _itemViews;
        private bool _storeInited;

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
            _itemsProvider.LoadItems(LoadItemsCompleteHandler, LoadItemsFailHandler);
        }

        private void LoadItemsCompleteHandler(StoreModel model)
        {
            Debug.Log($"Store model was loaded");
            _screenBlocker.Hide();
            _view.SetActive(true);
            foreach (var item in model.shopItems)
            {
                var itemView = _itemCreator.CreateItem(item, _itemsParent);
                itemView.OnClickPurchase += PurchaseHandler;
                _itemViews.Add(itemView);
            }

            _storeInited = true;
        }

        private void LoadItemsFailHandler()
        {
            Debug.Log($"Store model load failed");
            _screenBlocker.Hide();
        }

        private void OpenBtnHandler()
        {
            if (_storeInited)
            {
                _view.SetActive(true);
            }
            else
            {
                _screenBlocker.Show();
                Init();
            }
        }

        private void CloseBtnHandler()
        {
            _view.SetActive(false);
        }

        private void PurchaseHandler(object view, string itemKey)
        {
            Debug.Log($"You purchased {itemKey}");
            //Save purchased items here
            Destroy((view as MonoBehaviour).gameObject);
        }
    }
}
