using CommunityToolkit.Mvvm.ComponentModel;
using RealCost.ActiveWindow;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RealCost
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    [ObservableObject]
    public sealed partial class MainWindow : WindowEx
    {
        [ObservableProperty]
        public string currentActiveWindowString;

        public MainWindow()
        {
            var watcher = new ActiveWindowWatcher(TimeSpan.FromMilliseconds(500));
            this.InitializeComponent();
            Title = "DiptyDoh";
            this.ExtendsContentIntoTitleBar = true;
            IsTitleBarVisible = false;
            IsMinimizable = false;
            IsMaximizable = false;
            IsAlwaysOnTop = true;

            watcher.ActiveWindowChanged += (o, e) => CurrentActiveWindowString = $"{e.ActiveWindow}";
            watcher.Start();










        }

    }
}
