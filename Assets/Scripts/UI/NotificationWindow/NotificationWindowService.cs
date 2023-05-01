namespace Assets.Scripts.UI.NotificationWindow
{
    public class NotificationWindowService : INotificationWindowService
    {
        private INotificationWindowView _view;

        public void Inject(INotificationWindowView view)
        {
            _view = view;
        }

        public void ShowNotification(INotificationWindowElementBuilder[] elements)
        {
            foreach (var element in elements)
                _view.AddElement(element.Build());

            _view.Show();
        }

        public void HideNotification()
        {
            _view.Hide();
            _view.Clear();
        }
    }
}