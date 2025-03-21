using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface ISTG_MessageDetailBO
    {
        Task<STG_MessageDetailDM> GetById(int id);
        Task<STG_MessageDetailDM> GetByPoNum(int poNum);
        Task<List<STG_MessageDetailDM>> GetAllUnprocessed();
        Task<STG_MessageDetailDM> Insert(STG_MessageDetailDM inc);
        Task<List<STG_MessageDetailDM>> BatchInsert(List<STG_MessageDetailDM> inc);
        Task<STG_MessageDetailDM> Update(STG_MessageDetailDM inc);
        Task<List<STG_MessageDetailDM>> BatchUpdate(List<STG_MessageDetailDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();


    }
}
