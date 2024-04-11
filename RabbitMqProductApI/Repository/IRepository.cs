using RabbitMqProductApI.Models;

namespace RabbitMqProductApI.Repository
{
	public interface IRepository<T> where T : class
	{
		public IEnumerable<Product> GetProductList();
		public Product GetProductById(int id);
		public Product AddProduct(Product product);
		public Product UpdateProduct(Product product);
		public bool DeleteProduct(int Id);


	}
}
