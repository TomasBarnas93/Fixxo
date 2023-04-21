using Backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Dtos
{
	public class MessageRequest
	{
		public string Message { get; set; } = null!;
		public string Email { get; set; } = null!;


		public static implicit operator MessageEntity(MessageRequest req)
		{
			return new MessageEntity
			{
				Message = req.Message,
				Email = req.Email,
			};
		}
	}
}
