using MassTransit;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string rabbitMqUri = "amqps://wmfjyalu:X0GmitgZM7iXUPmT4uymccexqiTKoxJq@shark.rmq.cloudamqp.com/wmfjyalu";
            string queue = "test-queue";
            string userName = "wmfjyalu";
            string password = "X0GmitgZM7iXUPmT4uymccexqiTKoxJq";

            var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(rabbitMqUri, configurator =>
                {
                    configurator.Username(userName);
                    configurator.Password(password);
                });
            });

            await Task.Run(async () =>
            {
                while (true)
                {
                    Console.Write("Mesaj yaz : ");
                    Message message = new Message
                    {
                        Text = Console.ReadLine()
                    };
                    if (message.Text.ToUpper() == "C")
                        break;
                    await bus.Publish<IMessage>(message);
                    Console.WriteLine("");
                }
            });
        }
    }
}
