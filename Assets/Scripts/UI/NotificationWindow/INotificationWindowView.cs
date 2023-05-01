using UnityEngine;

namespace Assets.Scripts.UI.NotificationWindow
{
    public interface INotificationWindowView
    {
        void AddElement(GameObject element);
        void Show();
        void Hide();
        void Clear();
    }
}
