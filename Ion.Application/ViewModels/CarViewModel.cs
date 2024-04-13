﻿using Ion.Domain.Enums;

namespace Ion.Application.ViewModels;

public class CarViewModel : BaseViewModel
{
    public GearboxType GearboxType { get; set; }
    public required string Name { get; set; }
    public BodyType BodyType { get; set; }
    public bool IsAnnounced { get; set; }
}