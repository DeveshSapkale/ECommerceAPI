using AutoMapper;
using ECommerce.Models;
using ECommerce.Models.ApplicationDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public ProductController()
        {
            _applicationDBContext = new ApplicationDBContext();
        }
        // GET api/values
        [Route("api/Products")]
        [HttpGet]
        public IEnumerable<Product> Products()
        {
            IEnumerable<Product> products = _applicationDBContext.Products;
            return products;
        }
        [Route("api/Product/{id:int}")]
        [HttpGet]
        // GET api/values/5
        public Product Product(int id)
        {
            Product product = _applicationDBContext.Products.SingleOrDefault(p => p.Product_id == id);
            return product;
        }
        [Route("api/Product/Create")]
        [HttpPost]
        // POST api/values
        public void CreateProduct([FromBody]Product product)
        {
            if(product != null)
            {
                _applicationDBContext.Products.Add(product);
                _applicationDBContext.SaveChanges();
            }
        }
        [HttpPut]
        [Route("api/Product/Update/{id:int}")]
        // PUT api/values/5
        public void UpdateProduct(int id, [FromBody]Product product)
        {
            Product dbproduct = _applicationDBContext.Products.SingleOrDefault(p => p.Product_id == id);
            Mapper.Map<Product, Product>(product, dbproduct);
            _applicationDBContext.SaveChanges();

        }
        [Route("api/Product/delete/{id:int}")]
        [HttpDelete]
        // DELETE api/values/5
        public void DeleteProduct(int id)
        {
            Product dbproduct = _applicationDBContext.Products.SingleOrDefault(p => p.Product_id == id);
            _applicationDBContext.Products.Remove(dbproduct);
        }
        [HttpGet]
        [Route("api/Product/Categories")]
        public IEnumerable<ProductCategory> GetCategories()
        {
            return _applicationDBContext.ProductCategories;
        }
    }
}
