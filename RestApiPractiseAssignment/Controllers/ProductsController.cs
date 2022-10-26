using AutoMapper;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiPractiseAssignmentApi.Models;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiPractiseAssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService<Products> _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService<Products> productService , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();

                if (products == null)
                    return NotFound();

                return Ok(_mapper.Map<IEnumerable<ProductModel>>(products));
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("{productId}",Name ="GetProduct")]
        public ActionResult<ProductModel> GetProductById(int productId)
        {
            try
            {
                if (productId <= 0)
                    return BadRequest("Invalid product id");

                var product = _productService.GetProductById(productId);

                if (product == null)
                    return NotFound();

                return Ok(_mapper.Map<ProductModel>(product));
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("[action]", Name = "GetCategoryProducts")]
        public ActionResult<IEnumerable<ProductModel>> GetCategoryProducts([FromQuery] int categoryId)
        {
            try
            {
                var products = _productService.GetCategoryProducts(categoryId);

                if (products == null)
                    return NotFound();

                return Ok(_mapper.Map<IEnumerable<ProductModel>>(products));
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult AddProduct(ProductCreationModel product)
        {
            var productToAdd = _mapper.Map<Products>(product);
            _productService.AddProduct(productToAdd);

            var productToReturn = _mapper.Map<ProductModel>(productToAdd);
            return CreatedAtRoute("GetProduct",new { productId = productToReturn.ProductId}, productToReturn);
        }
        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(ProductCreationModel product, int productId)
        {
            var productFromDB = _productService.GetProductById(productId);

            if (productFromDB == null)
            {
                //add
                var productToAdd = _mapper.Map<Products>(product);
                _productService.AddProduct(productToAdd);

                var productToReturn = _mapper.Map<ProductModel>(productToAdd);

                return CreatedAtRoute("GetProduct", new { productId = productToReturn.ProductId }, productToReturn);


            }
            //update 
            _mapper.Map(product, productFromDB);

            _productService.UpdateProduct(productFromDB);
            return NoContent();

        }




    }
}
