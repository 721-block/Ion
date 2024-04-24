﻿using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

public class MessageService(IMapper mapper, IMessageRepository repository)
    : IMessageService
{
    public async Task<MessageViewModel> AddAsync(MessageViewModel model)
    {
        var message = await repository.AddAsync(mapper.Map<Message>(model));
        await repository.SaveChangesAsync();
        return mapper.Map<MessageViewModel>(message);
    }

    public async Task DeleteAsync(MessageViewModel model)
    {
        repository.Delete(mapper.Map<Message>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<MessageViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.Map<MessageViewModel>);
    }

    public IEnumerable<MessageViewModel> GetByAnnouncementId(int id)
    {
        return repository.GetByAnnouncementIdAsync(id).Select(mapper.Map<MessageViewModel>);
    }

    public MessageViewModel GetById(int id)
    {
        return mapper.Map<MessageViewModel>(repository.GetByID(id));
    }

    public async Task UpdateAsync(MessageViewModel model)
    {
        repository.Update(mapper.Map<Message>(model));
        await repository.SaveChangesAsync();
    }
}