

using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{

    public class Resume : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public ResumeType ResumeType { get; set; }
        public int ResumeTypeId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public IEnumerable<KeyPoint> KeyPoints { get; set; }


        public async Task<Resume> Update(string title, string description, string content)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content)) { throw new Exception("Data not provided"); }

            Title = title;
            Description = description;
            Content = content;

            return this;
        }

    }




}
