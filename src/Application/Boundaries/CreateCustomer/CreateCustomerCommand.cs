using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Messages;
using System;
using System.Collections.Generic;

namespace Application.Boundaries.CreateCustomer
{
    public class CreateCustomerCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ContactInput> Contacts { get; set; }


        public override IValidationResult Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
