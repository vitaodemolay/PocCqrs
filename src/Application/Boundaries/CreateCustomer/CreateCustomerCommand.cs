using Application.Boundaries.CreateCustomer.Validators;
using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Implementations;
using Infrastructure.CommandHandlerBase.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Boundaries.CreateCustomer
{
    public class CreateCustomerCommand : Command
    {
        public CreateCustomerCommand(string name, Guid? id = null, IList<ContactInput> contacts = null) 
            : base()
        {
            Name = name;
            Id = id ?? Guid.NewGuid();
            Contacts = contacts;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IList<ContactInput> Contacts { get; private set; }


        public override IValidationResult Validate()
        {
            var validatorResult = new CreateCustomerCommandValidador().Validate(this);
            if (validatorResult.IsValid)
                return CreateValidationResultForSuccess();

            return CreateValidationResultForFail(validatorResult.Errors.Select(f => f.ErrorMessage));
        }

        private IValidationResult CreateValidationResultForSuccess()
        {
            return new ValidationResult();
        }

        private IValidationResult CreateValidationResultForFail(IEnumerable<string> errors)
        {
            return new ValidationResult(errors.ToArray());
        }
    }
}
