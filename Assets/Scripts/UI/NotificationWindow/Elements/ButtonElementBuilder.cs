using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.NotificationWindow.Elements
{
    public class ButtonElementBuilder : INotificationWindowElementBuilder
    {
        private Action _onClick;
        private string _text;

        public ButtonElementBuilder(Action onClick, string text)
        {
            _onClick = onClick;
            _text = text;
        }

        public GameObject Build()
        {
            var pref = Resources.Load<GameObject>("ButtonElement");
            var instance = UnityEngine.Object.Instantiate(pref);
            instance.GetComponent<Button>().onClick.AddListener(_onClick.Invoke);
            instance.GetComponentInChildren<TMP_Text>().text = _text;
            return instance;
        }
    }
}
