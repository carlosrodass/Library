using CSharpFunctionalExtensions;
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class KeyPoint : BaseEntity
    {
        public long KeyPointId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ResumeId { get; set; }
        public Resume Resume { get; set; }

        //public override long GetEntityId()
        //{
        //    return KeyPointId;
        //}
    }
}

