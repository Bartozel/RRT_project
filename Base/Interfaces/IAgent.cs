using DiplomkaBartozel.Base;
using DiplomkaBartozel.Base.Enum;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Interfaces
{
    interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }
        int Velocity { get; set; }

        void GenerateSearch();
        void Move();
    }
}
