using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class KeyPoint : BaseEntity
    {
        #region Fields

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Resume Resume { get; private set; }
        public long ResumeId { get; private set; }

        #endregion

        #region Builder

        private KeyPoint()
        {

        }

        #endregion

        #region Public methods

        public static KeyPoint Create()
        {
            return new KeyPoint();
        }

        #endregion

        #region Private

        #endregion
    }
}

