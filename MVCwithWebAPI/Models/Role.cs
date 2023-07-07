using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Models
{
    public class Role
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string RoleName { get; set; }
        
    }
}