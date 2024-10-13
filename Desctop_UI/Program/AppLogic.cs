//using Data;
//using System;
//using System.Reactive;
//using System.Reactive.Linq;
//using System.Windows.Threading;

//namespace PathFindingVisualizer
//{
//    public class AppLogic
//    {
//        IAgent agent;
//        private Mapa canvasMap;
//        SearchType searchType;
//        SearchState appState;
//        public IPosition StartPosition { get; internal set; }
//        public IPosition GoalPosition { get; internal set; }

//        public AppLogic(Mapa canvasMap)
//        {
//            _canvasMap = canvasMap;
//            _StartPosition = new Position(35, 35);
//            _GoalPosition = new Position((int)_canvasMap.ActualWidth - 35, (int)_canvasMap.ActualHeight - 35);

//            canvasMap.StartChanged += StartChanged;
//            canvasMap.GoalChanged += GoalChanged;

//        }

//        private void GoalChanged(object sender, IPosition e)
//        {
//            if (e != null)
//                _GoalPosition = e;
//        }

//        private void StartChanged(object sender, IPosition e)
//        {
//            if (e != null)
//                _StartPosition = e;
//        }

//        private void SetSearchBoundaries()
//        {
//            canvasMap.SetStartPosition(_StartPosition);
//            canvasMap.SetGoalPosition(_GoalPosition);
//        }

//        public void Stop() =>
//            appState = agent.StopSearch();

//        public IObservable<ITreeNode> Start()
//        {
//            searchType = GetSearchType();
//            if (appState != SearchState.Paused)
//                agent = new Agent_RRT(_StartPosition, _GoalPosition, 5, searchType);

//            appState = SearchState.Running;

//            var observer = Observer.Create<ITreeNode>(
//                            x => _canvasMap.AddLine(x),
//                            OnError,
//                            OnCompleted
//                        );

//            var disp = agent.GetNewNodesObservable(150);

//            disp.ObserveOn(new DispatcherSynchronizationContext())
//                .Subscribe(observer);
//            return disp;
//        }

//        private void OnCompleted()
//        {

//        }
//        private void OnError(Exception ex)
//        {

//        }

//        private SearchType GetSearchType()
//        {
//            SearchType searchType = SearchType.RRT;

//            return searchType;
//        }

//        public void Pause() =>
//            appState = agent.Pause();

//    }
//}
