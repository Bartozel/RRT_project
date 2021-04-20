using Data.Data;
using Data.Enum;
using BL.Base;
using System;
using BL.Base.Interfaces;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Data;
using System.Collections.Generic;
using System.Reactive.Concurrency;

namespace BL.Agent
{
    public class Agent_RRT : Agent
    {
        private ISearchEngine_RRT searchEngine;
        private List<IObserver<Node>> createObserver;
        private List<IObserver<Node>> updateObserver;
        private List<IObserver<SearchArea>> moveObserver;


        public Agent_RRT(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity, sp)
        {
            this.searchEngine = SearchFactory.CreateRrtEngine(sp, rootCoordinates, goalCoordinates);

            this.createObserver = new List<IObserver<Node>>();
            this.updateObserver = new List<IObserver<Node>>();
            this.moveObserver = new List<IObserver<SearchArea>>();
        }

        public void SubscribeSearchCreate(IObserver<Node> observer)
        {
            this.createObserver.Add(observer);
        }

        public void SubscribeSearchUpdate(IObserver<Node> observer)
        {
            this.updateObserver.Add(observer);
        }

        public void SubscribeAgentMove(IObserver<SearchArea> observer)
        {
            this.moveObserver.Add(observer);
        }

        public override void StopSearch()
        {
            throw new NotImplementedException();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Restart()
        {
            throw new NotImplementedException();
        }

        public override IObservable<Node> StartSearch()
        {
            var co = NewLineObservable();
            this.createObserver.ForEach(x => co.Subscribe(x));

            //var uo = UpdateObservable();
            //this.updateObserver.ForEach(x => uo.Subscribe(x));

            return co;
        }

        private IObservable<Node> NewLineObservable()
        {
            IScheduler scheduler = DefaultScheduler.Instance;
            int amount = 20000;
            return Observable.Create<Node>(o =>
            {
                var cancellation = new CancellationDisposable();
                var scheduledWork = scheduler.Schedule(() =>
                {
                    try
                    {
                        searchEngine.CreateNewNodeObs(amount);
                        o.OnCompleted();
                    }
                    catch (Exception ex)
                    {
                        o.OnError(ex);
                    }
                });
                return new CompositeDisposable(scheduledWork, cancellation);
            });
        }

        private IObservable<Node> UpdateObservable()
        {
            IScheduler scheduler = DefaultScheduler.Instance;
            int amount = 20000;
            return Observable.Create<TreeLine>(o =>
            {
                var cancellation = new CancellationDisposable();
                var scheduledWork = scheduler.Schedule(() =>
                {
                    try
                    {

                        for (int x = 0; x < amount; x++)
                        {
                            //cancellation.Token.ThrowIfCancellationRequested();

                            //var line = searchEngine.GenerateNextStep(amount);
                            //o.OnNext(line);
                        }

                        o.OnCompleted();
                    }
                    catch (Exception ex)
                    {
                        o.OnError(ex);
                    }
                });
                return new CompositeDisposable(scheduledWork, cancellation);
            });
        }
    }
}
