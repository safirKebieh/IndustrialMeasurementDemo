namespace IMD.UI.Ui
{
    internal sealed class UiLogger
    {
        private readonly ListBox _listBox;
        private readonly int _maxItems;

        public UiLogger(ListBox listBox, int maxItems = 300)
        {
            _listBox = listBox;
            _maxItems = maxItems;
        }

        public void Log(string message)
        {
            void write()
            {
                _listBox.Items.Insert(0, $"{DateTimeOffset.Now:HH:mm:ss} | {message}");
                while (_listBox.Items.Count > _maxItems)
                    _listBox.Items.RemoveAt(_listBox.Items.Count - 1);
            }

            if (!_listBox.IsHandleCreated)
            {
                write();
                return;
            }

            if (_listBox.InvokeRequired) _listBox.Invoke(write);
            else write();
        }
    }
}