using SnappFood.Core;
using SnappFood.Core.Entities;
using SnappFood.Infrastructure;
using SnappFood.Model;

namespace SnappFood.Service
{
    public class ProductService : IProductService
    {
        //todo:read from config
        private const int InventoryCountConst = 10;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadOnlyRepository<Product> _readOnlyProductRepository;
            
        public ProductService(IUnitOfWork unitOfWork, IReadOnlyRepository<Product> readOnlyProductRepository)
        {
            _unitOfWork = unitOfWork;
            _readOnlyProductRepository = readOnlyProductRepository;
        }

        public async Task<ResultModel<int>> CreateProductAsync(ProductToCreateDto productToCreateDto)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync();
                if (products.Any(p => p.Title == productToCreateDto.Title))
                    return ResultModel<int>.StandardError(new Error() { Message = "There is a product with this title." });
                

                var productToCreate = new Product() { Title = productToCreateDto.Title,
                                                      InventoryCount = InventoryCountConst, 
                                                      Price = productToCreateDto.Price,
                                                      Discount = productToCreateDto.Discount };

                _unitOfWork.ProductRepository.Add(productToCreate);
                await _unitOfWork.CommitAsync();

                return ResultModel<int>.StandardOk(productToCreate.Id);
            }
            catch (Exception ex)
            {
                //log ex
                return ResultModel<int>.StandardError(new Error() { Message = "Creating product is failed." });
            }

        }
        public async Task<ResultModel<bool>> UpdateProductInventoryCountAsync(int id, int count)
        {
            try
            {
                var productToUpdate = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
                if (productToUpdate == null)
                    return ResultModel<bool>.StandardError(new Error() { Code = 401 });

                productToUpdate.InventoryCount += count;

                _unitOfWork.ProductRepository.Update(productToUpdate);
                await _unitOfWork.CommitAsync();

                return ResultModel<bool>.StandardOk(true);
            }
            catch (Exception ex)
            {
                //log ex
                return ResultModel<bool>.StandardError(new Error() { Message = "Increasing product inventory count is failed." });
            }

        }
        public ResultModel<ProductDto> GetProduct(int id)
        {
            try
            {
                var product = _readOnlyProductRepository.GetById(id);
                if (product == null)
                    return ResultModel<ProductDto>.StandardError(new Error() { Code=401 });

                var productToCreateDto = new ProductDto() {Id=product.Id, 
                                                           Title = product.Title,
                                                           InventoryCount=product.InventoryCount,
                                                           Price = product.Price - (product.Price * product.Discount / 100),
                                                           Discount =product.Discount };
                return ResultModel<ProductDto>.StandardOk(productToCreateDto);
            }
            catch (Exception ex)
            {
                //log ex
                return ResultModel<ProductDto>.StandardError(new Error() { Message = "Getting product is failed." });
            }
        }
      
    }
}