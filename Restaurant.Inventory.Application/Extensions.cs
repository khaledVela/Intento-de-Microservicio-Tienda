using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Inventory.Application.UseCases.Item.CreateItem;
using Restaurant.Inventory.Domain.Model.Transactions.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<ITransactionFactory, TransactionFactory>();
            

            //IMediator mediator;

            //CreateItemCommand command = new CreateItemCommand()
            //{
            //    ItemName = "Coca-cola"
            //};

            //var id =await mediator.Send(command);

            return services;
        }
        
    }
}
