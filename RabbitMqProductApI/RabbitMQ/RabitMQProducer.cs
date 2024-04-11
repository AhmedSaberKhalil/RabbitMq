using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;


namespace RabbitMqProductApI.RabbitMQ
{
	public class RabitMQProducer : IRabitMQProducer
	{
		public void SendProductMessage<T>(T message)
		{
			//Here we specify the Rabbit MQ Server.
			var factory = new ConnectionFactory
			{
				HostName = "localhost"
			};
			//Create the RabbitMQ connection using connection factory.
			var connection = factory.CreateConnection();
			//Here we create channel with session and model
			using var channel = connection.CreateModel();
			//declare the queue after mentioning name and a few property related to that
			//	channel.QueueDeclare("product", exclusive: false);
			channel.QueueDeclare(queue: "product",
						 durable: false,
						 exclusive: false,
						 autoDelete: false,
						 arguments: null);
			//Serialize the message
			var json = JsonConvert.SerializeObject(message);
			var body = Encoding.UTF8.GetBytes(json);
			//put the data on to the product queue
			channel.BasicPublish(exchange: "", routingKey: "product", body: body);
		}
	}
}
