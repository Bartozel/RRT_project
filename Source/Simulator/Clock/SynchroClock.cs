using System;
using System.Threading;

namespace PathFindingSimulatorAgregator
{
    internal class SynchroClock
    {
        private TimeSpan _tickFrequency;
        private DateTime _lastTickTime;
        private Timer _timer;

        public event ReadOnlyStructDelegate<TimeSpan> OnTimerElapsed;

        public SynchroClock(TimeSpan tickFrequency) 
        {
            _tickFrequency = tickFrequency;
            _timer = new Timer(OnTimerEllapsed, null, TimeSpan.Zero, tickFrequency);
        }

        private void OnTimerEllapsed(object state)
        {
            var delta = DateTime.Now - _lastTickTime;
            OnTimerElapsed?.Invoke(in delta);
        }

        internal void Start()
        {
            throw new NotImplementedException();
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
