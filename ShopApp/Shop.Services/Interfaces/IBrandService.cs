using Shop.Services.Dtos.BrandDtos;
using Shop.Services.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces
{
    public interface IBrandService
    {
        CreatedEntityDto Create(BrandPostDto dto);
        void Edit(int id, BrandPutDto dto);
        List<BrandGetAllItemDto> GetAll();
        void Delete(int id);
        BrandGetDto GetById(int id);
    }
}
