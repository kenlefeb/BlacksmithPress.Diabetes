using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BlacksmithPress.Diabetes.Core.Common
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        private PropertyChangedEventHandler _propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                PropertyChangedEventHandler changedEventHandler = this._propertyChanged;
                PropertyChangedEventHandler comparand;
                do
                {
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChanged, comparand + value, comparand);
                }
                while (changedEventHandler != comparand);
            }
            remove
            {
                PropertyChangedEventHandler changedEventHandler = this._propertyChanged;
                PropertyChangedEventHandler comparand;
                do
                {
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChanged, comparand - value, comparand);
                }
                while (changedEventHandler != comparand);
            }
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals((object)storage, (object)value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler changedEventHandler = this._propertyChanged;
            if (changedEventHandler == null)
                return;
            changedEventHandler((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
