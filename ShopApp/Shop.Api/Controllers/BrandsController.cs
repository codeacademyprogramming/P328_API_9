using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Data;
using Shop.Services.Dtos.BrandDtos;
using Shop.Services.Interfaces;

namespace Shop.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("")]
        public IActionResult Create(BrandPostDto postDto)
        {
            var result = _brandService.Create(postDto);
            return StatusCode(201,result);
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, BrandPutDto putDto)
        {
            _brandService.Edit(id,putDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandService.Delete(id);
            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<BrandGetAllItemDto>> GetAll()
        {
            return Ok(_brandService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<BrandGetDto> Get(int id)
        {
            return Ok(_brandService.GetById(id));
        }
    }
}
