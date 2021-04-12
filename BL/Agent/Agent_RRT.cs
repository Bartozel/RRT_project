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
        private List<IObserver<TreeLine>> createObserver;
        private List<IObserver<TreeLine>> updateObserver;
        private List<IObserver<SearchArea>> moveObserver;


        public Agent_RRT(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity, sp)
        {
            this.searchEngine = SearchFactory.CreateRrtEngine(sp, rootCoordinates, goalCoordinates);

            this.createObserver = new List<IObserver<TreeLine>>();
            this.updateObserver = new List<IObserver<TreeLine>>();
            this.moveObserver = new List<IObserver<SearchArea>>();
        }

        public void SubscribeSearchCreate(IObserver<TreeLine> observer)
        {
            this.createObserver.Add(observer);
        }

        public void SubscribeSearchUpdate(IObserver<TreeLine> observer)
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

        public override IObservable<TreeLine> StartSearch()
        {
            var co = NewLineObservable();
            this.createObserver.ForEach(x => co.Subscribe(x));

            var uo = UpdateObservable();
            this.updateObserver.ForEach(x => uo.Subscribe(x));

            return co;
        }

        private IObservable<TreeLine> NewLineObservable()
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
                        searchEngine.GenerateNextStep(amount);
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

        private IObservable<TreeLine> UpdateObservable()
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
