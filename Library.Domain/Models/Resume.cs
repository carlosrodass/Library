using CSharpFunctionalExtensions;
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{

    public class Resume : BaseEntity
    {
        #region Fields

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Content { get; private set; }
        public int ResumeTypeId { get; private set; }
        public ResumeType ResumeType { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }

        public readonly List<KeyPoint> _keyPoints;
        public IReadOnlyCollection<KeyPoint> KeyPoints => _keyPoints;

        #endregion

        #region Builder

        protected Resume()
        {
            _keyPoints = new List<KeyPoint>();
        }

        private Resume(string title, string description, string content, int resumeTypeId, long bookId)
        {
            Title = title;
            Description = description;
            Content = content;
            ResumeTypeId = resumeTypeId;
            BookId = bookId;
        }

        #endregion

        #region Public methods

        public static Result<Resume, Error> Create(string title, string description, string content, int resumeTypeId, long bookId)
        {
            var result = CheckCreateRequiredFields(title, resumeTypeId, bookId);

            if (result.IsFailure) { return result.Error; }

            return new Resume(title, description, content, resumeTypeId, bookId);
        }

        public Result<Resume, Error> Update(string title, string description, string content)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content)) { return Error.RequiredField; }

            Title = title;
            Description = description;
            Content = content;

            return this;
        }

        #endregion

        #region Private methods

        private static Result<bool, Error> CheckCreateRequiredFields(string title, int resumeTypeId, long bookId)
        {
            if (string.IsNullOrEmpty(title))
            {
                return false; //TODO: Change to RESULT Pattern
            }

            if (resumeTypeId <= 0)
            {
                return false; //TODO: Change to RESULT Pattern
            }

            if (bookId <= 0)
            {
                return false; //TODO: Change to RESULT Pattern
            }

            return true;
        }


        #endregion

    }




}
