﻿using Ion.Domain.Entities;
using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class MessageViewModel : BaseViewModel
{
    public string SenderFirstName { get; set; }
    public string SenderLastName { get; set; }
    public string ReceiverFirstName { get; set; }
    public string ReceiverLastName { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreationTime { get; set; }
}
