using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVCApp.Models.ViewModels
{
    public class ResponsiveViewModels
    {
        public int Number { get; set; }
        public bool IsTrue { get; set; }

        public List<TimePerson> myModel = new List<TimePerson>();
    }
}
