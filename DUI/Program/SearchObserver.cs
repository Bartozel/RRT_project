using Data.Data;
using System;
using System.Collections.Generic;
using BL.Base.Interfaces;
using System.Reactive;

namespace DUI.Program
{
    class SearchObserver : IObserver_RRT
    {
        public void Add(TreeLine treeLine)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(TreeLine value)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IEnumerable<TreeLine> value)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TreeLine> treeLines)
        {
            throw new NotImplementedException();
        }
    }
}
