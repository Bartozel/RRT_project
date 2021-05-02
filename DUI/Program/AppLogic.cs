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
        public Position GoalPosition { get; internal set; }
        SearchType searchType;

        public AppLogic() { }

        public void Stop()
        {
            agent.StopSearch();
        }

        public IObservable<Node> Start()
        {
            searchType = GetSearchType();
            agent = new Agent_RRT(this.StartPosition, this.GoalPosition, 5, searchType);
            var disp = agent.GetNewNodeObs(1500);
            return disp;
        }

        private SearchType GetSearchType()
        {
            SearchType searchType = SearchType.RRT;

            return searchType;
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
