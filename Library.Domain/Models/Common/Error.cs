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
        public static readonly Error None = new(string.Empty, string.Empty);

        public static readonly Error NotFound = new Error
            ("NotFound", "Not found");

        public static readonly Error RequiredField = new Error
            ("RequiredField", "Required field");

        public static readonly Error AlreadyExist = new Error
            ("AlreadyExist", "Already Exist");

        public static readonly Error ResumeFailed = new Error
             ("ResumeFailed", "Can not add resume because its already created");

    }



}
