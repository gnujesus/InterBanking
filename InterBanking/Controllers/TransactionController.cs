using InterBanking.Core.Application.Interfaces.Services;
using InterBanking.Core.Application.Services;
using InterBanking.Core.Application.ViewModels.Transaction;
using InterBanking.Core.Domain.Entities;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // TODO: I must return a ViewModel, not a transaction directly
        List<TransactionViewModel> transactions = await _transactionService.GetAll();

        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        TransactionViewModel transaction = await _transactionService.GetById(id);

        return Ok(transaction);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(SaveTransactionViewModel vm)
    {
        // TransactionViewModel transaction = await _transactionService.GetById(vm);
        return Ok();
    }
    
    
}