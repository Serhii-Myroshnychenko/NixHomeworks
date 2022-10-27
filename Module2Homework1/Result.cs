using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Homework1
{
    public class Result
    {
        public Result(bool status, string? message)
        {
            Status = status;
            Message = message;
        }

        public bool Status { get; set; }
        public string? Message { get; set; }
    }
}
