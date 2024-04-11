using Microsoft.EntityFrameworkCore;
using RabbitMqProductApI.Data;
using RabbitMqProductApI.Models;

namespace RabbitMqProductApI.Repository
{
	public class ProductRepository : IRepository<Product>
	{
		private readonly RMQEntity _dbContext;

		public ProductRepository(RMQEntity dbContext)
		{
			_dbContext = dbContext;
			
		}
		public IEnumerable<Product> GetProductList()
		{
			return _dbContext.Product.ToList();
		}
		public Product GetProductById(int id)
		{
			return _dbContext.Product.Where(x => x.ProductId == id).FirstOrDefault();
		}
		public Product AddProduct(Product product)
		{
			var result = _dbContext.Product.Add(product);
			_dbContext.SaveChanges();
			return result.Entity;
		}
		public Product UpdateProduct(Product product)
		{
			var result = _dbContext.Product.Update(product);
			_dbContext.SaveChanges();
			return result.Entity;
		}
		public bool DeleteProduct(int Id)
		{
			Product filteredData = GetProductById(Id);
			var result = _dbContext.Remove(filteredData);
			_dbContext.SaveChanges();
			return result != null ? true : false;
		}

	}
}
