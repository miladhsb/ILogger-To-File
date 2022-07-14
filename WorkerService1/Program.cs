using WorkerService1;



IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
      //var pLoggerFactory =  services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
      //  pLoggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs"));

    }).ConfigureLogging(p =>
    {
        p.ClearProviders();
        p.AddJsonConsole();
       
        p.AddProvider(new FileLoggerProvider(Path.Combine(Directory.GetCurrentDirectory(), "logs")));

    })
    .Build();

await host.RunAsync();
