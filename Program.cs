
using DotnetDi.Application;
using DotnetDi.Models;
using DotnetDi.Repository;
using DotnetDi.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

void RunClientController(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
    Application.ClientController(uow);
}

IServiceProvider DependencyInjection1()
{
    var serviceProvider = new ServiceCollection()
        .AddScoped<IDbSession, DbSession>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IRepository<Client>,Repository<Client>>()
        .AddScoped<IRepository<Product>, Repository<Product>>()
        .BuildServiceProvider();
    return serviceProvider;
}

IServiceProvider DependencyInjection2()
{
    var serviceProvider = new ServiceCollection()
        .AddTransient<IDbSession, DbSession>()
        .AddTransient<IUnitOfWork, UnitOfWork>()
        .AddTransient<IRepository<Client>,Repository<Client>>()
        .AddTransient<IRepository<Product>, Repository<Product>>()
        .BuildServiceProvider();
    return serviceProvider;
}

IServiceProvider DependencyInjection3()
{
    var serviceProvider = new ServiceCollection()
        .AddSingleton<IDbSession, DbSession>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IRepository<Client>,Repository<Client>>()
        .AddScoped<IRepository<Product>, Repository<Product>>()
        .BuildServiceProvider();
    return serviceProvider;
}

IServiceProvider DependencyInjection4()
{
    var serviceProvider = new ServiceCollection()
        .AddTransient<IDbSession, DbSession>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IRepository<Client>,Repository<Client>>()
        .AddScoped<IRepository<Product>, Repository<Product>>()
        .BuildServiceProvider();
    return serviceProvider;
}

void Main()
{
    var serviceProvider1 = DependencyInjection1();
    var serviceProvider2 = DependencyInjection2();
    var serviceProvider3 = DependencyInjection3();
    var serviceProvider4 = DependencyInjection4();


    Console.WriteLine("DI service - AddScoped (all)");
    RunClientController(serviceProvider1);
    RunClientController(serviceProvider1);

    Console.WriteLine("DI service - AddTransient");
    RunClientController(serviceProvider2);
    RunClientController(serviceProvider2);

    Console.WriteLine("DI service - AddSingleton (DbSession) and AddScope (rest)");
    RunClientController(serviceProvider3);
    RunClientController(serviceProvider3);

    Console.WriteLine("DI service - AddTransient (DbSession) and AddScope (rest)");
    RunClientController(serviceProvider3);
    RunClientController(serviceProvider3);
}

Main();