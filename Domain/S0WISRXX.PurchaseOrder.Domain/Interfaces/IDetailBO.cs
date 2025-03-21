using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface IDetailBO
    {
        Task<DetailDM> GetById(int id);
        Task<DetailDM> GetByPoNum(int poNum);
        Task<List<DetailDM>> GetAllUnprocessed();
        Task<DetailDM> Insert(DetailDM inc);
        Task<List<DetailDM>> BatchInsert(List<DetailDM> inc);
        Task<DetailDM> Update(DetailDM inc);
        Task<List<DetailDM>> BatchUpdate(List<DetailDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();

    }

}
