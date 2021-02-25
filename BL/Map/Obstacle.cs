using Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Base
{
    public class Obstacle : SearchArea
    {
        public Obstacle(int xCoordinate, int width, int yCoordinate, int height) : base(xCoordinate, width, yCoordinate, height)
        {
        }
    }
}
