using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIApp.Controllers
{
    [Route("Product")]
    public class ProductInfoController : Controller
    {
        private readonly IProductRepo<Product> _productRepo;
        public ProductInfoController(IProductRepo<Product> productRepo)
        {
            this._productRepo = productRepo;
        }

        [Route("ProductList", Name = "ProductList")]
        public IActionResult ShowAllProducts()
        {
            var products = _productRepo.GetAllProducts();
            return View(products);
        }

        [Route("AddProduct", Name = "AddProduct")]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveProduct", Name = "SaveProduct")]
        public IActionResult AddNewProduct(Product product)
        {
            var newProduct = _productRepo.AddProduct(product);
            return RedirectToRoute("ProductList");
        }

        [Route("GetById/{id}", Name = "GetById")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepo.GetProductById(id);
            return View(product);
        }

        [Route("EditProduct/{id}", Name = "EditProduct")]
        public IActionResult EditProduct(int id)
        {
            var product = _productRepo.GetProductById(id);
            return View("UpdateProduct", product); // Loads Update form with data
        }

        [HttpPost]
        [Route("UpdateProduct", Name = "UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            var updated = _productRepo.UpdateProduct(product.ProductId, product);
            return RedirectToRoute("ProductList");
        }


        [Route("RemoveProduct/{id}", Name = "RemoveProduct")]

        public IActionResult RemoveProduct(int id)
        {
            var removedProduct = _productRepo.RemoveProduct(id);
            if (removedProduct != null)
            {
                return RedirectToRoute("ProductList");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
