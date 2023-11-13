using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApplication.Shared.Models.InputModels
{
    public class JobInputModel
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Company { get;  set; }
        public string Location { get;  set; }
        public decimal Salary { get;  set; }
    }
}
