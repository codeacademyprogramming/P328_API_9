using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Repositories;
using Shop.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Shop.Services.Dtos.ProductDtos;
using Shop.Services.Interfaces;

namespace Shop.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController( IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("")]
        public IActionResult Create([FromForm] ProductPostDto postDto)
        {
            return StatusCode(201, _productService.Create(postDto));
        }
        [HttpGet("all")]
        public ActionResult<List<ProductGetAllItemDto>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,[FromForm]ProductPutDto putDto)
        {
            _productService.Edit(id, putDto);

            return NoContent();
        }


        [HttpGet("{id}")]
        public ActionResult<ProductGetDto> Get(int id)
        {
            return Ok(_productService.GetById(id));
        }
    }
}
