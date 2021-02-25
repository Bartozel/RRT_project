using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUI
{
    class Program: IProgram
    {
        private Task process;

        public Program() 
        {
            LoadSetting();
        }

        private void LoadSetting()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync()
        {
            throw new NotImplementedException();
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
