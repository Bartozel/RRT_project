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
using System.Windows.Shapes;
using System.Windows.Media;

namespace DUI.Program
{
    public class AppLogic
    {
        //test properties
        IAgent agent;
        Mapa canvasMap;
        public IPosition StartPosition { get; internal set; }
        public IPosition GoalPosition { get; internal set; }
        SearchType searchType;
        SearchState appState;


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

            var disp = agent.GetNewNodeObs(150);
            disp.ObserveOnDispatcher()
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
