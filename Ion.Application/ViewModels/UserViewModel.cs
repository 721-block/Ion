﻿namespace Ion.Application.ViewModels;

public class UserViewModel : BaseViewModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public LicenseViewModel? License { get; set; }
    public string PathToPhoto { get; set; }
}