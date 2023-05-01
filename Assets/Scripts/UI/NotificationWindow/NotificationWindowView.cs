using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.NotificationWindow
{
    public class NotificationWindowView : MonoBehaviour, INotificationWindowView
    {
        [SerializeField] private Transform _elementsParent;
        private List<GameObject> _elements;
        private List<GameObject> _elementsProperty
        {
            get
            {
                if (_elements == null)
                    _elements = new ();
                return _elements;
            }
        }

        public void AddElement(GameObject element)
        {
            _elementsProperty.Add(element);
            element.transform.SetParent(_elementsParent);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Clear()
        {
            foreach (var element in _elementsProperty)
                Destroy(element);

            _elementsProperty.Clear();
        }
    }
}
