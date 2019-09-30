using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Pocos
{
    public class ViewModalDepartment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        [Display(Name ="Users")]
        public int TotalUsers { get; set; }
    }
}