using Microsoft.UI.Xaml;
using RealCost.Helpers;

namespace RealCost.ActiveWindow
{
    public class ActiveWindowWatcher
    {
        private DispatcherTimer stateTimer;




        private ActiveWindowModel currentActiveWindow = ActiveWindowModel.CreateEmpty();
        public event EventHandler<ActiveWindowChangedEventArgs> ActiveWindowChanged;

        public ActiveWindowWatcher(TimeSpan interval)
        {
            stateTimer = new DispatcherTimer();
            stateTimer.Interval = interval;
            stateTimer.Tick += StateTimer_Tick;


        }

        private void StateTimer_Tick(object sender, object e)
        {
            GetActiveWindow();
        }

        public void Start() => stateTimer.Start();
        public void Stop() => stateTimer.Stop();

        private void GetActiveWindow() =>
            WindowAPI
                .GetActiveWindowTitle()
                .Do(activeWindow =>
                    activeWindow.IsDifferentThan(currentActiveWindow, () =>
                    {
                        currentActiveWindow = ActiveWindowModel.CreateFrom(activeWindow);
                        ActiveWindowChanged?.Invoke(this, ActiveWindowChangedEventArgs.Create(activeWindow.WindowTitle));
                    }));
    }
}
