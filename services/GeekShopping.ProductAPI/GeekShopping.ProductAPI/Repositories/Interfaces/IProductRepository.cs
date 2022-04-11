using System.Collections.Generic;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.DTO;

namespace GeekShopping.ProductAPI.Repositories.interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> FindAll();
        
        Task<ProductDTO> FindById(long id);

        Task<ProductDTO> Create(ProductDTO productDto);

        Task<ProductDTO> Update(ProductDTO productDto);

        Task<bool> Delete(long id);
    }
}