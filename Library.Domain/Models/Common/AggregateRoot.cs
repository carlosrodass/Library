using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Models.Common
{
    public abstract class AggregateRoot : BaseEntity
    {
        protected AggregateRoot()
        {

        }
        protected AggregateRoot(long id)
            : base(id)
        {
        }
    }
}
