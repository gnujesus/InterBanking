using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.Services;
using InterBanking.Core.Application.ViewModels.Transaction;
using InterBanking.Core.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.InterBanking.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    // NOTE: if Identity is set up, the default authentication schema will be cookies, meaning, the app will try to 
    // authenticate via cookies. To override this (use Identity and JWT) you have to specify the AutheticationScheme for each 
    // route you want authenticated.
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("Transactions")]
    public async Task<IActionResult> GetAll()
    {
        // TODO: I must return a ViewModel, not a transaction directly
        var transactions = await _transactionService.GetAll();

        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var transaction = await _transactionService.GetById(id);

        return Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveTransactionViewModel vm)
    {
        var transaction = await _transactionService.Add(vm);

        return Ok();
    }
}