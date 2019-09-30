using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Pocos
{
    public class UserPocos
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public bool Active { get; set; }
        
    }
}