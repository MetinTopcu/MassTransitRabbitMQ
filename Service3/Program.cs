using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string rabbitMqUri = "amqps://wmfjyalu:X0GmitgZM7iXUPmT4uymccexqiTKoxJq@shark.rmq.cloudamqp.com/wmfjyalu";
            string queue = "test-queue-2";

            string userName = "wmfjyalu";
            string password = "X0GmitgZM7iXUPmT4uymccexqiTKoxJq";

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMqUri, configurator =>
                {
                    configurator.Username(userName);
                    configurator.Password(password);
                });

                factory.ReceiveEndpoint(queue, endpoint => endpoint.Consumer<MessageConsumer>());
            });
            await bus.StartAsync();
            Console.ReadLine();
            await bus.StopAsync();
        }
    }
}
