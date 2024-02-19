using CSharpFunctionalExtensions;
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class KeyPoint : BaseEntity
    {
        #region Fields

        public string Name { get; private set; }
        public string Description { get; private set; }
        public long ResumeId { get; private set; }
        public Resume Resume { get; private set; }

        #endregion

        #region Builder

        private KeyPoint(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion

        #region Public methods

        public static Result<KeyPoint, Error> Create(string name, string description)
        {
            return new KeyPoint(name, description);
        }

        #endregion

        #region Private

        #endregion
    }
}

