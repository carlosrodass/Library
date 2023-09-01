using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Common
{
    public abstract class Enum : IComparable
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        protected Enum(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
