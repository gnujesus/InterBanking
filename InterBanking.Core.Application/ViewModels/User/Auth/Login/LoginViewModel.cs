﻿using InterBanking.Core.Application.ViewModels.Shared;

namespace InterBanking.Core.Application.ViewModels.User.Auth.Login;

public class LoginViewModel
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; }
}