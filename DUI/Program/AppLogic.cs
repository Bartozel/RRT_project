using System;
using Data.Data;
using Data.Enum;
using BL.Base.Interfaces;
using BL.Agent;
using Data;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace DUI.Program
{
    public class AppLogic
    {
        //test properties
        private IAgent agent;

        public Position StartPosition { get; internal set; }

        public AppLogic() { }

        public AppLogic(Position start, Position goal, SearchType st) : base()
        {
            agent = new Agent_RRT(start, goal, 5, st);
        }

        public void Stop()
        {
            agent.StopSearch();
        }

        public IObservable<Node> Start()
        {
            var disp = agent.GetNewNodeObs(500);
            return disp;
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }
    }
}
