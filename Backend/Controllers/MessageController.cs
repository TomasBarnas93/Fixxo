using Backend.Filters;
using Backend.Models.Dtos;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiKey]
	[Route("api/")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly MessageRepository _repository;

		public MessageController(MessageRepository repository)
		{
			_repository = repository;
		}

		[HttpPost]
        [Route("Contact/Send")]
        public async Task<IActionResult>SendMessage(MessageRequest message)
		{
			if(ModelState.IsValid)
			{
				if(message != null)
				{
					await _repository.SendMessageAsync(message);
					return Created("", null);
				}
			}
			return BadRequest();
		}
	}
}
