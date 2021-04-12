using System;
using Data.Data;
using Data.Enum;
using BL.Base.Interfaces;

namespace DUI.Program
{
    public class AppLogic: IProgram
    {
        private Position testStart;
        private Position testGoal;
        private SearchType testSP;
        private int testVelocity = 5;

        public AppLogic() 
        {
            LoadSetting();
            testStart = new Position(20, 20);
            testGoal = new Position(150, 150);
            testSP = SearchType.RRT_STAR;
        }

        private void LoadSetting()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            //var agent = new Agent(testStart, testGoal, testVelocity, testSP);
            //IObserver_RRT observer = new SearchObserver();
            //agent.SubscribeSearch(observer);
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
