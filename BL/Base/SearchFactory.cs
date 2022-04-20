using Data.Data;
using Data.Enum;
using System;
using Data.Data.Interfaces;

namespace BL.Base
{
    class SearchFactory
    {
        public static ISearchEngine_RRT CreateRrtEngine(SearchType searchType, IPosition start, IPosition goal)
        {
            ISearchEngine_RRT searchEngine = null;
            var searchEngineType = Type.GetType($"SearchEngine.{searchType}");
            if (searchEngineType != null)
            {
                var parameters = new object[] {start, goal};
                var search = Activator.CreateInstance(searchEngineType, parameters);
                searchEngine = search as ISearchEngine_RRT;
            }
            return searchEngine;
        }
    }
}
