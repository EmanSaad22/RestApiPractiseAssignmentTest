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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService<Category> categoryService , IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAll();

                if (categories == null)
                    return NotFound();

                return Ok(_mapper.Map<IEnumerable<CategoryModel>>(categories));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryCreationModel category)
        {
            var categoryToAdd = _mapper.Map<Category>(category);
            _categoryService.Add(categoryToAdd);

            var categoryToReturn = _mapper.Map<CategoryModel>(categoryToAdd);
            return CreatedAtRoute("GetCategory", new { categoryId = categoryToReturn.CategoryId }, categoryToReturn);
        }
        [HttpGet("{categoryId}", Name = "GetCategory")]
        public ActionResult<CategoryModel> GetCategoryById(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                    return BadRequest("Invalid category id");

                var category = _categoryService.GetCategoryById(categoryId);

                if (category == null)
                    return NotFound();

                return Ok(_mapper.Map<CategoryModel>(category));
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
