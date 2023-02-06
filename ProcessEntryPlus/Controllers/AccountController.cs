﻿using Microsoft.AspNetCore.Mvc;
using ProcessEntryPlus.Services;

namespace ProcessEntryPlus.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
      _accountService = accountService;
    }

    // [HttpGet]
    // [Authorize]
    // public Task<ActionResult<Account>> Get()
    // {
    //   try
    //   {
    //     // Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     // return Ok(_accountService.GetOrCreateProfile(userInfo));
    //   }
    //   catch (Exception)
    //   {
    //     // return Task.FromResult(BadRequest(e.Message));
    //   }
    // }

  }


}
