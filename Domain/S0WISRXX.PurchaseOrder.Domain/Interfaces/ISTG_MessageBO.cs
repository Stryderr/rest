using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface ISTG_MessageBO
    {
        Task<STG_MessageDM> GetById(int id);
        Task<STG_MessageDM> GetByPoNum(int poNum);
        Task<List<STG_MessageDM>> GetAllUnprocessed();
        Task<STG_MessageDM> Insert(STG_MessageDM inc);
        Task<List<STG_MessageDM>> BatchInsert(List<STG_MessageDM> inc);
        Task<STG_MessageDM> Update(STG_MessageDM inc);
        Task<List<STG_MessageDM>> BatchUpdate(List<STG_MessageDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();

    }

}
