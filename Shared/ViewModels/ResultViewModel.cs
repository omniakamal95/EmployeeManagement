using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object ReturnObject { get; set; }
      

    }

    public class ResultListViewModel<T> : ResultViewModel where T : class
    {
        public List<T> ReturnObjectList { get; set; }

    }
}
