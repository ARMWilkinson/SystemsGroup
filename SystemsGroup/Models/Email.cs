using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemsGroup.Models
{
    public class Email
    {
        public string to { get; set; }

        [Key]
        public string subject { get; set; }
        public string body { get; set; }
    }
}