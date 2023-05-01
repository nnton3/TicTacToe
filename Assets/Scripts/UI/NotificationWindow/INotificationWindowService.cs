namespace Assets.Scripts.UI.NotificationWindow
{
    public interface INotificationWindowService
    {
        void ShowNotification(INotificationWindowElementBuilder[] elements);
        void HideNotification();
    }
}
