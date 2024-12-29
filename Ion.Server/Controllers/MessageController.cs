using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.Hubs;
using Ion.Server.RequestEntities.Message;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(IMessageService messageService, IMapper mapper, IHubContext<AnnouncementChatHub> chatHub) : Controller
{
    [HttpGet("{messageId:int}", Name = nameof(GetMessageById))]
    public ActionResult<MessageToGet> GetMessageById(int messageId)
    {
        var messageViewModel = messageService.GetById(messageId);
        if (messageViewModel is null)
            return NotFound();

        var message = mapper.Map<MessageToGet>(messageViewModel);

        return Ok(message);
    }

    [HttpGet(Name = nameof(GetAllMessages))]
    public ActionResult<IEnumerable<MessageToGet>> GetAllMessages()
    {
        var messageViewModels = messageService.GetAll();

        return Ok(messageViewModels);
    }

    [HttpPost(Name = nameof(CreateMessage))]
    public async Task<IActionResult> CreateMessage([FromBody] MessageToPost messageToPost)
    {
        if (messageToPost is null)
            return BadRequest("Message is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();

        await chatHub.Clients
            .Groups(messageToPost.SenderId.ToString(), messageToPost.ReceiverId.ToString())
            .SendAsync("Receive", messageToPost);

        var messageViewModel = mapper.Map<MessageViewModel>(messageToPost);
        var createdMessage = await messageService.AddAsync(messageViewModel);

        return CreatedAtRoute(nameof(GetMessageById), new {messageId = createdMessage.Id}, createdMessage.Id);
    }

    [HttpPatch("{messageId:int}", Name = nameof(UpdateMessage))]
    public async Task<IActionResult> UpdateMessage(int messageId, [FromBody] MessageToPatch carToPatch)
    {
        var messageViewModel = mapper.Map<MessageViewModel>(carToPatch);
        messageViewModel.Id = messageId;
        await messageService.UpdateAsync(messageViewModel);

        return Ok();
    }

    [HttpDelete("{messageId:int}", Name = nameof(DeleteMessage))]
    public async Task<IActionResult> DeleteMessage(int messageId)
    {
        await messageService.DeleteAsync(new MessageViewModel {Id = messageId});

        return Ok();
    }
}