using Data.Data;
using Data.Enum;
using DiplomkaBartozel.Interfaces;
using DiplomkaBartozel.RRT;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Base
{
    class SearchFactory
    {
        public static ISearchEngine Create(SearchType sp, Position start, Position goal)
        {
            ISearchEngine search;
            switch (sp)
            {
                case SearchType.RRT:
                    search = new RRT(start, goal);
                    break;
                case SearchType.RRT_STAR:
                    search = new RRT_STAR(start, goal);
                    break;
                case SearchType.Informed_RRT_Star:
                    search = new Informed_RRT_Star(start, goal);
                    break;
                default:
                    throw new Exception($"Invalid SearchType token. SearchType={sp}");
            }
            return search;
        }
    }
}
