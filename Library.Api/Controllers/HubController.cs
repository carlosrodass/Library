﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Hub;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Application.Features.HubFeature.Commands.AddBookToHub;
using MyLibrary.Application.Features.HubFeature.Commands.CreateHub;
using MyLibrary.Application.Features.HubFeature.Queries.GetAllHubs;
using MyLibrary.Application.Features.HubFeature.Queries.GetHubDetails;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security.Claims;
using MyLibrary.Application.Models.Identity;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HubController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllHubsDto>>> GetAllAsync()
        {
            //createHubCommand.UserId = GetUserClaims();

            var result = await _mediator.Send(new GetAllHubsQuery());
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpGet("ById/{HubId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetHubDetailsDto>> GetByIdAsync(long HubId)
        {
            //createHubCommand.UserId = GetUserClaims();

            var result = await _mediator.Send(new GetHubDetailsQuery(HubId));
            if (result.IsFailure) { return BadRequest(result); }
            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync(CreateHubCommand createHubCommand)
        {
            createHubCommand.UserId = GetUserClaims();

            var result = await _mediator.Send(createHubCommand);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpPut("AddBookToHub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddBookToHubAsync(AddBookToHubCommand addBookToHubCommand)
        {

            var result = await _mediator.Send(addBookToHubCommand);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }


        #region Private

        private string? GetUserClaims()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "uid");
            return userIdClaim?.Value;

        }

        #endregion
    }
}
