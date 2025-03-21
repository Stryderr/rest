using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface ISTG_DetailBO
    {
        Task<STG_DetailDM> GetById(int id);
        Task<STG_DetailDM> GetByPoNum(int poNum);
        Task<List<STG_DetailDM>> GetAllUnprocessed();
        Task<STG_DetailDM> Insert(STG_DetailDM inc);
        Task<List<STG_DetailDM>> BatchInsert(List<STG_DetailDM> inc);
        Task<STG_DetailDM> Update(STG_DetailDM inc);
        Task<List<STG_DetailDM>> BatchUpdate(List<STG_DetailDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();

    }

}
