using SnappFood.Core;
using SnappFood.Model;

namespace SnappFood.Service
{
    public interface IProductService
    {
        Task<ResultModel<int>> CreateProductAsync(ProductToCreateDto productToCreateDto);
        Task<ResultModel<bool>> UpdateProductInventoryCountAsync(int id, int count);
        ResultModel<ProductDto> GetProduct(int id);
       
    }
}
