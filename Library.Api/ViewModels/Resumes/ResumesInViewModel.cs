using MyLibrary.Application.Dtos.Common;

namespace MyLibrary.Api.ViewModels.Resumes
{
    public class ResumesInViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ResumeTypeId { get; set; }
        public long? BookId { get; set; }
    }

    public class ResumesUpdateViewModel : ResumesInViewModel
    {
        public long ResumeId { get; set; }
    }

    public class ResumesViewModel : ResumesUpdateViewModel
    {

    }
}
