using SnappFood.Core;
using SnappFood.Model;

namespace SnappFood.Service
{
    public interface IProcurementService
    {
        Task<ResultModel<bool>> Buy(ProductToBuyDto productToBuyDto);
    }
}
