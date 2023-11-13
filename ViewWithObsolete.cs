using System;

namespace ObsoletesBug;

public class ViewWithObsolete : Label {
    [Obsolete($"Use {nameof(TextWithoutObsoleteProperty)} instead.", true)]
    public static readonly BindableProperty TextWithObsoleteProperty;
    [Obsolete($"Use {nameof(TextWithoutObsolete)} instead.", true)]
    public string TextWithObsolete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public static readonly BindableProperty TextWithoutObsoleteProperty = BindableProperty.Create(nameof(TextWithoutObsolete), typeof(string), typeof(ViewWithObsolete), propertyChanged: (s, _, _) => ((ViewWithObsolete)s).TextChanged?.Invoke(s, EventArgs.Empty));
    public string TextWithoutObsolete { get => (string)GetValue(TextWithoutObsoleteProperty); set => SetValue(TextWithoutObsoleteProperty, value); }

    [Obsolete($"Use {nameof(TextChanged)} instead.", true)]
    public event EventHandler TextChangedObsolete {
        add => throw new NotImplementedException();
        remove => throw new NotImplementedException();
    }

    public event EventHandler TextChanged;
}

