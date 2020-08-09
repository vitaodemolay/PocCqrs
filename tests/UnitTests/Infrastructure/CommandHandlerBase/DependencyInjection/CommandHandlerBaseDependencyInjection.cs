using Infrastructure.CommandHandlerBase.Contracts;
using Infrastructure.CommandHandlerBase.Implementations;
using Microsoft.Extensions.DependencyInjection;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Data;
using UnitTests.Infrastructure.CommandHandlerBase.Fakers.Handlers;

namespace UnitTests.Infrastructure.CommandHandlerBase.DependencyInjection
{
    internal static class CommandHandlerBaseDependencyInjection
    {
        internal static IBus GetIBusObjectForSum(ICommandHandlerDatabaseTests database)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICommandHandlerDatabaseTests>(database);
            var dependencyResolver = new DependencyResolver(serviceCollection);

            var busObjet = new InMemoryBus(dependencyResolver);

            busObjet.RegisterHandler<SumTwoNumbersCommandHandler>();
            busObjet.RegisterHandler<CalculationResultEventHandler>();

            return busObjet;
        }

    }
}