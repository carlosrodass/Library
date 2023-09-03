﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Common
{
    public class CustomErrors
    {

        public static class Book
        {
            private const string Code = "Book";
            public static Error NotFound() =>
                new Error(Code, "Book Not found");
        }

    }
}
