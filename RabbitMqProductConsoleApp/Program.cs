using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqProductConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Here we specify the Rabbit MQ Server. 
			var factory = new ConnectionFactory
			{
				HostName = "localhost"
			};
			//Create the RabbitMQ connection using connection factory
			var connection = factory.CreateConnection();
			//Here we create channel with session and model
			var channel = connection.CreateModel();
			//declare the queue after mentioning name and a few property related to that
			channel.QueueDeclare(queue: "product",
								 durable: false,
								 exclusive: false,
								 autoDelete: false,
								 arguments: null);
			//Set Event object which listen message from chanel which is sent by producer
			var consumer = new EventingBasicConsumer(channel);
			consumer.Received += (model, eventArgs) =>
			{
				var body = eventArgs.Body.ToArray();
				var message = Encoding.UTF8.GetString(body);
				Console.WriteLine($"Product message received: {message}");
			};
			//read the message
			channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
			Console.ReadKey();
		}
	}
}
