using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Common
{
    public sealed record Error(string Code, string? Messsage = null)
    {
        public static readonly Error None = new Error(string.Empty);
    }

    //public string Code { get; set; }
    //public string Message { get; set; }

    //public Error(string code, string message)
    //{
    //    Code = code;
    //    Message = message;
    //}


}
