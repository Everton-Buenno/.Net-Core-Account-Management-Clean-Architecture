using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ResultResponse
    {
        public bool Error { get; set; } = false;
        public string Message { get; set; }
    }
}
