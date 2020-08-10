using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Implementations;
using Microsoft.Extensions.DependencyInjection;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Commands;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Events;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Handlers;

namespace UnitTests.Infrastructure.CommandHandlerBase.DependencyInjection
{
    internal static class CommandHandlerBaseDependencyInjection
    {
        internal static IBus GetIBusObjectForSum(ICommandHandlerDatabaseTests database)
        {
            var serviceCollection = new ServiceCollection();
            var busObjet = new InMemoryBus(serviceCollection);

            serviceCollection.AddSingleton<IBus>(busObjet);
            serviceCollection.AddSingleton<ICommandHandlerDatabaseTests>(database);

      
            busObjet.RegisterHandler<SumTwoNumbersCommand, SumTwoNumbersCommandHandler>();
            busObjet.RegisterHandler<CalculationResultEvent, CalculationResultEventHandler>();

            return busObjet;
        }

    }
}