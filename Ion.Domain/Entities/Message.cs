﻿using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class Message : BaseEntity
{
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
    public int AnnouncementId { get; set; }
    public Announcement Announcement { get; set; } 
        
    public string Text { get; set; }
    public DateTimeOffset CreationTime { get; set; }
}