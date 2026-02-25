namespace IMD.UI.Ui
{
    internal sealed class UiDispatcher
    {
        private readonly Control _control;

        public UiDispatcher(Control control)
        {
            _control = control;
        }

        public void Invoke(Action action)
        {
            if (!_control.IsHandleCreated)
            {
                action();
                return;
            }

            if (_control.InvokeRequired)
                _control.Invoke(action);
            else
                action();
        }
    }
}