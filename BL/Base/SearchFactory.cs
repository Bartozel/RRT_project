using BL.Base.Interfaces;
using Data.Data;
using Data.Enum;
using DiplomkaBartozel.RRT;
using System;

namespace BL.Base
{
    class SearchFactory
    {
        public static ISearchEngine_RRT CreateRrtEngine(SearchType sp, IPosition start, IPosition goal)
        {
            ISearchEngine_RRT search;
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
