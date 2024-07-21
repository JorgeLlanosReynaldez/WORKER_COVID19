using DATASET;
using MAIL;
using PDF;
using WORKER_COVID19;

IHost host = Host.CreateDefaultBuilder(args)
       .ConfigureServices(services =>
       {
           services.AddHostedService<Worker>()
           .AddSingleton<IReadDataset, ReadDataset>()
           .AddSingleton<IGeneratePDF, GeneratePDF>()
           .AddSingleton<ISendMail, SendMail>();
       })
       // Configure as a Windows Service
       .UseWindowsService(options =>
       {
           options.ServiceName = "My Service";
       })
       .Build();

host.Run();