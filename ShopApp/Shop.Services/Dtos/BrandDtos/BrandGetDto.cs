using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Dtos.BrandDtos
{
    public class BrandGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductsCount { get; set; }
    }
}
