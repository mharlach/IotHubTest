namespace IotHubTest.App
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices.Client;
    using Microsoft.Azure.Devices.Shared;

    public class Management
    {
        private string connectionString;
        private DeviceClient client;
        private TransportType transportType = TransportType.Amqp;

        public Management(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Initialize()
        {
            client = DeviceClient.CreateFromConnectionString(connectionString, transportType);
            if (client != null)
            {
                var twinTask = client.GetTwinAsync();
                var restartCollectionTask = client.SetMethodHandlerAsync(nameof(RestartCollection), RestartCollection, null);

                var twin = await twinTask;
                await restartCollectionTask;
            }
            else
            {
                throw new ArgumentException()
            }

        }

        public async Task<MethodResponse> RestartCollection(MethodRequest request, object context)
        {
            throw new NotImplementedException();
        }
    }
}