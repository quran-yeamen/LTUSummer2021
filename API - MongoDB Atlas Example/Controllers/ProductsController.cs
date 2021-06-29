
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Homework2.Dtos;
using Homework2.Models;
using Homework2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var result = _mapper.Map<ProductReadDto>(await _productsRepository.Create(_mapper.Map<Product>(dto)));
            return CreatedAtRoute(nameof(GetById), new {result.Id}, result);
        }

        // Arrow function
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(_mapper.Map<IEnumerable<ProductReadDto>>(await _productsRepository.GetAllProducts()));
        


        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var student = await _productsRepository.GetById(id);
            return student == null ? (IActionResult) NotFound() : Ok(_mapper.Map<ProductReadDto>(student));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(string id, ProductUpdateDto dto)
        {
            
            var update = await _productsRepository.UpdateById(id, _mapper.Map<Product>(dto));
            return update == null ? (IActionResult) NotFound() : Ok(_mapper.Map<ProductReadDto>(update));
        }
        // Arrow function
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id) =>
            await _productsRepository.DeleteById(id) ? (IActionResult) Ok() : NotFound();
        

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _productsRepository.DeleteAllProducts();
            return Ok();
        }
    }
}