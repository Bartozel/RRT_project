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
    public static class AppLogic
    {
        private static Position testStart;
        private static Position testGoal;
        private static SearchType testSP;
        private static int testVelocity = 5;

        static AppLogic()
        {
            LoadSetting();
            testStart = new Position(20, 20);
            testGoal = new Position(150, 150);
            testSP = SearchType.RRT;
        }

        private static void LoadSetting()
        {
            //TODO
        }

        public static void Stop()
        {
            throw new NotImplementedException();
        }

        public static IObservable<Node> Start(IObserver<Node> observer)
        {
            var agent = new Agent_RRT(testStart, testGoal, testVelocity, testSP);
            var disp = agent.GetNewNodeObs;
            disp.ObserveOn(DispatcherScheduler.Current)
                .Subscribe(observer);

            return disp;
        }

        public static void Pause()
        {
            throw new NotImplementedException();
        }

        public static void Restart()
        {
            throw new NotImplementedException();
        }
    }
}
