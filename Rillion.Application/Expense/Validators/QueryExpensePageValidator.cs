using FluentValidation;
using Rillion.Application.Expense.Queries;

namespace Rillion.Application.Expense.Validators;

public class QueryExpensePageValidator : AbstractValidator<QueryExpensePage>
{
    public QueryExpensePageValidator()
    {
        RuleFor(n => n.UserId).GreaterThan(0);
        RuleFor(n => n.Page).GreaterThanOrEqualTo(0);
        RuleFor(n => n.PageSize).GreaterThan(0);
    }
}