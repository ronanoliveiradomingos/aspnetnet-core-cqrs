using Solution.Commands;
using FluentValidation;

namespace Solution.Validation
{
    public class CreateCustomerOrderCommandValidator : AbstractValidator<CreateCustomerOrderCommand>
    {
        public CreateCustomerOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();
            
            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}