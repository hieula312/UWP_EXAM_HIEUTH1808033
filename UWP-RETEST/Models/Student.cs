using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_RETEST.Models
{
    public class Student
    {
        public int RollNumber { get; set; }
        public String Name { get; set; }
        public int Status { get; set; }

        public Dictionary<String, String> checkValidate()
        {
            var errors = new Dictionary<String, String>();
            if (string.IsNullOrEmpty(this.Name))
            {
                errors.Add("nameErr", "Name must be filled");
            }
            return errors;
        }
    }

}
