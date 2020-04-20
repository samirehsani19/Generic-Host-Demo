using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericHost
{
    class MainService : IHostedService
    {
        public readonly DataContext dataContext;
        private IHostApplicationLifetime lifeTime;
        public MainService(DataContext dataContext, IHostApplicationLifetime lifetime)
        {
            this.dataContext = dataContext;
            this.lifeTime = lifetime;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            DataManager data = new DataManager(dataContext);
            //enter the name of actor and movie name
            data.InsertDataToTables("Scott Adkin", "Undisputed");
            data.GetAllData();

            //enter the old name and the new name to update
            data.UpdateActorName("Jonny", "");
            //data.RemoveData(dataContext);

            Console.ReadKey();
            lifeTime.StopApplication();
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}
