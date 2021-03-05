using System;
using BL.Agent;
using System.Threading.Tasks;
using Data.Data;
using DiplomkaBartozel.Interfaces;
using Data.Enum;

namespace DUI.Program
{
    class Program: IProgram
    {
        private Position testStart;
        private Position testGoal;
        private SearchType testSP;
        private int testVelocity = 5;

        public Program() 
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

        public void StartAsync()
        {
            var agent = new Agent(testStart, testGoal, testVelocity, testSP);
            var observer = new SearchObserver();
            agent.SubscribeSearch(observer);
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
