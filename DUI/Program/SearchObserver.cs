using Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DUI.Program
{
    class SearchObserver : IObserver<TreeLine>
    {
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
    }
}
