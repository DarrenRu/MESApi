using System;
using System.Collections.Generic;
using System.Text;

namespace ITRI.ViewModels
{
    public class DatatablesOneVM<T> where T : class
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public T data { get; set; }
        public string error { get; set; }
    }
}
