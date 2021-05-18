using System;
using Data.Data;
using Data.Enum;
using BL.Base.Interfaces;
using BL.Agent;
using Data;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;

namespace DUI.Program
{
    public class AppLogic
    {
        //test properties
        private IAgent agent;

        public Position StartPosition { get; internal set; }
        public Position GoalPosition { get; internal set; }
        SearchType searchType;
        SearchStatus appState;


        public AppLogic() { }

        public void Stop()
        {
            appState = SearchStatus.Stopped;
            agent.StopSearch();
        }

        public IObservable<Node> Start()
        {
            searchType = GetSearchType();
            if (appState != SearchStatus.Paused)
                agent = new Agent_RRT(this.StartPosition, this.GoalPosition, 5, searchType);

            var disp = agent.GetNewNodeObs(150);
            appState = SearchStatus.Started;
            return disp;
        }

        private SearchType GetSearchType()
        {
            SearchType searchType = SearchType.RRT;

            return searchType;
        }

        public void Pause()
        {
            agent.StopSearch();
            appState = SearchStatus.Paused;
        }

    }

    public enum SearchStatus
    {
        Started,
        Paused,
        Stopped
    }
}
