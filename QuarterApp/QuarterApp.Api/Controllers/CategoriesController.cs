using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuarterApp.Service.CustomExpections;
using QuarterApp.Service.DTOs.CategoryDTOs;
using QuarterApp.Service.Services.Implementations;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuarterApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryPostDto postDto)
        {
            await _categoryService.CreateAsync(postDto);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoryGetDto =  await _categoryService.GetByIdAsync(id);
            return Ok(categoryGetDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CategoryPostDto postDto , int id)
        {
            await _categoryService.UpdateAsync(postDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetFiltered(string search, int page = 1)
        {
            var pagenateed = await _categoryService.GetAllFiltered(page,search);
            return Ok(pagenateed);
        }
    }
}
