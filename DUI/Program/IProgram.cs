using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUI.Program
{
    interface IProgram
    {
        Task StartAsync();
        void Stop();
        void Pause();
        void Restart();
    }
}
