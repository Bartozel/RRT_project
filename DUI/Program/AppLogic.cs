using System;
using Data.Data;
using Data.Enum;
using BL.Agent;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Threading;
using Data.Data.Interfaces;

namespace DUI.Program
{
    public class AppLogic
    {
        IAgent agent;
        private Mapa canvasMap;
        SearchType searchType;
        SearchState appState;
        public IPosition StartPosition { get; internal set; }
        public IPosition GoalPosition { get; internal set; }

        public AppLogic(Mapa canvasMap)
        {
            this.canvasMap = canvasMap;
            this.StartPosition = new Position(35, 35);
            this.GoalPosition = new Position((int)this.canvasMap.ActualWidth - 35, (int)this.canvasMap.ActualHeight - 35);

            canvasMap.StartChanged += StartChanged;
            canvasMap.GoalChanged += GoalChanged;

        }

        private void GoalChanged(object sender, IPosition e)
        {
            if (e != null)
                this.GoalPosition = e;
        }

        private void StartChanged(object sender, IPosition e)
        {
            if (e != null)
                this.StartPosition = e;
        }

        private void SetSearchBoundaries()
        {
            canvasMap.SetStartPosition(this.StartPosition);
            canvasMap.SetGoalPosition(this.GoalPosition);
        }

        public void Stop() =>
            appState = agent.StopSearch();

        public IObservable<ITreeNode> Start()
        {
            searchType = GetSearchType();
            if (appState != SearchState.Paused)
                agent = new Agent_RRT(this.StartPosition, this.GoalPosition, 5, searchType);

            appState = SearchState.Running;

            var observer = Observer.Create<ITreeNode>(
                            x => this.canvasMap.AddLine(x),
                            OnError,
                            OnCompleted
                        );

            var disp = agent.GetNewNodesObservable(150);

            disp.ObserveOn(new DispatcherSynchronizationContext())
                .Subscribe(observer);
            return disp;
        }

        private void OnCompleted()
        {

        }
        private void OnError(Exception ex)
        {

        }

        private SearchType GetSearchType()
        {
            SearchType searchType = SearchType.RRT;

            return searchType;
        }

        public void Pause() =>
            appState = agent.Pause();

    }
}
