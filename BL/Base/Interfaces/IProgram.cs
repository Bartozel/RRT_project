using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Base.Interfaces
{
    public interface IProgram
    {
        void Start();
        void Stop();
        void Pause();
        void Restart();
    }
}
