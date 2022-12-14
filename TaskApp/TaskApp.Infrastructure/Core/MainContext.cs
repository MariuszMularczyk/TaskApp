
using System;
using System.Collections.Generic;

namespace TaskApp.Infrastructure
{
    public class MainContext
    {
        public int PersonId { get; set; }

        private string _id;
        public MainContext()
        {
            _id = Guid.NewGuid().ToString();
            //_kernel = kernel;
        }
    }
}
