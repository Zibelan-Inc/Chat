using System;

namespace LanChat
{
    public sealed class DelegateCommand
    {
        public Predicate<object> OnCanExecute { get; set; }
        public Action<object> OnExecute { get; set; }
        public DelegateCommand(Predicate<object> onCanExecute, Action<object> onExecute)
        {
            OnExecute = onExecute;
            OnCanExecute = onCanExecute;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        public event EventHandler CanExecuteChanged;
    }
}
