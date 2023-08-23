using SnappFood.Core;
using SnappFood.Core.Entities;
using SnappFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Service
{
    public class ProcurementService : IProcurementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProcurementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultModel<bool>> Buy(ProductToBuyDto productToBuyDto)
        {
            try
            {
                var productToBuy = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == productToBuyDto.ProductId);
                if (productToBuy == null)
                    return ResultModel<bool>.StandardError(new Error() { Code = 401 });

                productToBuy.InventoryCount --;
                _unitOfWork.ProductRepository.Update(productToBuy);

                var orderToCreate = new Order()
                {
                    ProductId = productToBuyDto.ProductId,
                    BuyerId = productToBuyDto.BuyerId,
                    CreationDate = DateTime.Now,
                    
                };

                _unitOfWork.OrderRepository.Add(orderToCreate);
                await _unitOfWork.CommitAsync();

                return ResultModel<bool>.StandardOk(true);
            }
            catch (Exception ex)
            {
                //log ex
                return ResultModel<bool>.StandardError(new Error() { Message = "Purchase has failed." });
            }

        }
    }
}
