namespace RabbitMqProductApI.RabbitMQ
{
	public interface IRabitMQProducer
	{
		public void SendProductMessage<T>(T message);
	}
}
