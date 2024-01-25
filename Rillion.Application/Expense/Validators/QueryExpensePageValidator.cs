using FluentValidation;
using Rillion.Application.Expense.Queries;
using Rillion.Application.Validation;

namespace Rillion.Application.Expense.Validators;

public class QueryExpensePageValidator : AbstractValidator<QueryExpensePage>
{
    public QueryExpensePageValidator()
    {
        RuleFor(n => n.UserId).MustBeCurrentUser();
        RuleFor(n => n.Page).GreaterThanOrEqualTo(0);
        RuleFor(n => n.PageSize).GreaterThan(0);
    }
}