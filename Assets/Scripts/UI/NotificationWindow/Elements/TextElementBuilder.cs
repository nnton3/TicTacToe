using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.NotificationWindow.Elements
{
    public class TextElementBuilder : INotificationWindowElementBuilder
    {
        private string _text;

        public TextElementBuilder(string text)
        {
            _text = text;
        }

        public GameObject Build()
        {
            var pref = Resources.Load<GameObject>("TextElement");
            var instance = Object.Instantiate(pref);
            instance.GetComponent<TMP_Text>().text = _text;
            return instance;
        }
    }
}
