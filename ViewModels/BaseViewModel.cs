using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DotNetProjectScaffold.ViewModels
{
    public abstract class BaseViewModel : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public string Title { get; }

        public ICommand LoadCommand { get; }

        public BaseViewModel(string title = "")
        {
            Title = title;
            LoadCommand = new RelayCommand(Load);
        }

        public virtual void Load() { }

        // INotifyDataErrorInfo Logic
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => false;

        public IEnumerable GetErrors(string? propertyName)
        {
            return new List<string>();
        }

        // INotifyPropertyChanged Logic 
        private Dictionary<string, object> _values = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Set<T>(T value, [CallerMemberName] string memberName = null)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return;
            }

            _values[memberName] = value;

            NotifyChanged(memberName);
        }

        public T Get<T>([CallerMemberName] string? memberName = null)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                throw new ArgumentOutOfRangeException(nameof(memberName));
            }

            if (!_values.ContainsKey(memberName))
            {
                _values.Add(memberName, default(T));
            }

            return (T)_values[memberName];
        }

        protected void NotifyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}