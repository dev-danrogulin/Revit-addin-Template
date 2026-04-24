// Base MVVM infrastructure used by all ViewModels in the plugin UI.
using System.Collections.Generic;
// Provides INotifyPropertyChanged and related event args for WPF bindings.
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RevitAddin.Plugin.Infrastructure.Mvvm;

public abstract class ViewModelBase : INotifyPropertyChanged {
    // WPF subscribes to this event to refresh bound UI controls.
    public event PropertyChangedEventHandler? PropertyChanged;

    // Notifies WPF that a property changed.
    // CallerMemberName auto-fills the calling property name when omitted.
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Reusable setter helper:
    // 1) compare old/new values
    // 2) update field only when value changed
    // 3) raise PropertyChanged for WPF
    // Returns true only when the value was actually changed.
    protected bool SetProperty<T>(
        ref T field,
        T value,
        [CallerMemberName] string? propertyName = null
    ) {
        if (EqualityComparer<T>.Default.Equals(field, value)) {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}