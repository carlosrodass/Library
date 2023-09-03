using MediatR;
using MyLibrary.Application.Dtos.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.LibraryFeature.Queries.GetAllLibraries;

public record GetAllLibrariesQuery : IRequest<List<GetAllLibrariesDto>>;
