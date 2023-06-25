using Shop.Services.Dtos.Common;
using Shop.Services.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces
{
    public interface IProductService
    {
        CreatedEntityDto Create(ProductPostDto dto);
        void Edit(int id, ProductPutDto dto);
        ProductGetDto GetById(int id);
        List<ProductGetAllItemDto> GetAll();
        void Delete(int id);
    }
}
