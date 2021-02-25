using Data.Data;
using DiplomkaBartozel.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Interfaces
{
    interface ISearchEngine_RRT
    {
        List<Node> SpanningTree { get; }
    }
}
