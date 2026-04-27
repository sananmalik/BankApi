using BankApi.DTOs;
using BankApi.Exceptions;
using BankApi.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private AccountServices _services;

    public AccountController(AccountServices services)
    {
        _services = services;
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] DepositRequest request)
    {
        try
        {
            _services.Deposit(request.AccountNumber, request.Amount);

            return Ok(new
            {
                message = "Deposit successful"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }
    
    [HttpGet("{accountNo}")]
    public IActionResult GetAccount(string accountNo)
    {
        try
        {
            var account = _services.GetAccount(accountNo);

            return Ok(new
            {
                accountNumber = account.AccountNumber,
                balance = account.Balance
            });
        }
        catch (Exception ex)
        {
            return NotFound(new
            {
                error = ex.Message
            });
        }
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromBody] WithdrawRequest request)
    {
        try
        {
            _services.Withdraw(request.AccountNumber, request.Amount);

            return Ok(new
            {
                message = "Withdraw successful"
            });
        }
        catch (AccountNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (InvalidAmountException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InsufficientAmountException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("transfer")]
    public IActionResult Transfer([FromBody] TransferRequest request)
    {
        try
        {
            _services.Transfer(request.FromAccount, request.ToAccount, request.Amount);

            return Ok(new
            {
                message = "Transfer successful"
            });
        }
        catch (AccountNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (InvalidAmountException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InsufficientAmountException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}