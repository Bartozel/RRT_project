using Communication;
using Logging;
using System;
using System.Threading;

namespace PathFindingSimulator
{
    internal class SynchroClock : BaseLogger
    {
        private TimeSpan _tickFrequency;
        private DateTime _lastTickTime;
        private Timer _timer;

        public event ReadOnlyStructDelegate<TimeSpan> OnTimerElapsed;

        public SynchroClock(TimeSpan tickFrequency, ICommunicationProvider communicationProvider, ILogger logger) : base(logger)
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
