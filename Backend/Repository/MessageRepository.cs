using Backend.Contexts;
using Backend.Models.Dtos;
using Backend.Models.Entities;

namespace Backend.Repository
{
	public class MessageRepository
	{
		private readonly DataContext _context;

		public MessageRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<MessageEntity>SendMessageAsync(MessageRequest message)
		{
			_context.Messages.Add(message);
			await _context.SaveChangesAsync();
			return message;
		}
	}
}
