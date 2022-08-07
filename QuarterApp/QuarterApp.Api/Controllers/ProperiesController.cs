using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuarterApp.Service.DTOs.PropertyDTOs;
using QuarterApp.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace QuarterApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProperiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public ProperiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]PropertyPostDto postDto)
        {
            var model = await _propertyService.Create(postDto);
            return StatusCode(201,model);
        }

    }
}
