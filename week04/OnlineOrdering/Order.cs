using System.Collections.Generic;
using System.Text;

namespace OnlineOrderingProgram
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalPrice()
        {
            double total = 0;
            foreach (var product in _products)
            {
                total += product.GetTotalCost();
            }

            double shippingCost = _customer.LivesInUSA() ? 5 : 35;
            total += shippingCost;
            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var product in _products)
            {
                sb.AppendLine($"Product Name: {product.GetName()}, Product ID: {product.GetProductId()}");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            sb.AppendLine(_customer.GetName());
            sb.AppendLine(_customer.GetAddress().GetFullAddress());
            return sb.ToString();
        }
    }
}
