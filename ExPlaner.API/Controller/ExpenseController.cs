using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExPlaner.API.DAL.EF;
using ExPlaner.API.DAL.Repository;
using ExPlaner.API.Service;
using ExPlaner.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExPlaner.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly IUserDependentUnitOfWork<Expense> _unitOfWork;
        private readonly IRepository<Currency> _currency;

        public ExpenseController(AccountService accountService, IUserDependentUnitOfWork<Expense> unitOfWork, IRepository<Currency> currency)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
            _currency = currency;
        }

        // GET: api/Expense
        [HttpGet]
        public IActionResult GetExpense()
        {
            return Ok(
                _unitOfWork
                    .GetUserDependentRepository()
                    .GetAllByUser(_accountService.GetCurrentUser())
                    .Select(ex => CreateExpenseViewModel(ex)));
        }

        // GET: api/Expense/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetExpense(Guid id)
        {
            var expense = _unitOfWork
                .GetUserDependentRepository()
                .GetAllByUser(_accountService.GetCurrentUser())
                .Where(e => e.Id == id)
                .Select(ex => CreateExpenseViewModel(ex))
                .FirstOrDefault();

            if (expense is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(expense);
            }
        }

        private static ExpenseViewModel CreateExpenseViewModel(Expense ex)
        {
            return new ExpenseViewModel
            {
                Id = ex.Id,
                Name = ex.Name,
                NetValue = ex.NetValue,
                GrossValue = ex.GrossValue,
                OperationDate = ex.OperationDate,
                Currency = ex.Currency.CurrencyCode,
                CurrencyDate = ex.CurrencyDate,
                CurrencyRate = ex.CurrencyRate,
                OperationType = ex.OperationType
            };
        }

        // POST: api/Expense
        [HttpPost]
        public IActionResult PostExpense([FromBody] ExpenseViewModel expense)
        {
            if (ModelState.IsValid)
            {
                var currencyCode = expense.Currency;
                if (string.IsNullOrEmpty(expense.Currency))
                {
                    currencyCode = "PLN"; //TODO: Move to config or const
                }

                var currency = _currency.GetAll().FirstOrDefault(cur => cur.CurrencyCode == currencyCode);

                if (currency is null)
                {
                    ModelState.AddModelError(nameof(expense.Currency), "Unknown currency code");
                    return BadRequest(ModelState);
                }


                var exp = new Expense
                {
                    Name = expense.Name,
                    NetValue = expense.NetValue.Value,
                    GrossValue = expense.GrossValue.Value,
                    OperationDate = expense.OperationDate ?? DateTime.Now,
                    Currency = currency,
                    CurrencyDate = expense.CurrencyDate ?? DateTime.Now,
                    CurrencyRate = expense.CurrencyRate ?? 1M,
                    OperationType = expense.OperationType ?? OperationType.Company,
                    User = _accountService.GetCurrentUser()
                };

                _unitOfWork.GetUserDependentRepository().Insert(exp);
                _unitOfWork.Save();

                return CreatedAtAction("GetExpense", new { id = exp.Id }, CreateExpenseViewModel(exp));

            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var expense = _unitOfWork.GetUserDependentRepository().GetAllByUser(_accountService.GetCurrentUser()).FirstOrDefault(ex => ex.Id == id);
            if (expense is null)
            {
                return NotFound();
            }

            _unitOfWork.GetUserDependentRepository().Remove(expense);
            _unitOfWork.Save();

            return Ok(expense);
        }

        private bool ExpenseExists(Guid id)
        {
            return _unitOfWork
                .GetUserDependentRepository()
                .GetAllByUser(_accountService.GetCurrentUser())
                .Any(e => e.Id == id);
        }
    }
}
