using System;
using RailwayClient.Extensions;

namespace RailwayClient.DataAccess.Commands
{
    public class CommandBuilder : ICommandBuilder
    {
        private readonly IServiceProvider _serviceProvider;


        public CommandBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        /// <inheritdoc />
        public void ExecuteCommand<TContext>(TContext context) where TContext : IContext
        {
            var command = _serviceProvider.Resolve<ICommand<TContext>>();
            command.Execute(context);
        }
    }
}