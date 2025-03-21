using Microsoft.EntityFrameworkCore;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Repositories.Context;

namespace S0WISRXX.PurchaseOrder.Repository.Repositories
{


    public class STG_PurchaseOrderRepository : BaseRepository<PoheaderStg>, ISTG_PurchaseOrderRepository
    {

        public STG_PurchaseOrderRepository(PurchaseOrderContext context, IUtilityLogger logger) : base(context, logger)
        {
        }


        public async Task<PoheaderStg?> GetById(int id)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrders.FindAsync(id) ?? null;
            }, "An exception occurred while attempting to get the purchase order");
        }

        public async Task<PoheaderStg?> GetByPoNum(int poNum)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrders.FirstOrDefaultAsync(x => x.Ponumberq == poNum) ?? null;
            }, "An exception occurred while attempting to get the purchase order");
        }

        public async Task<List<PoheaderStg>> GetAllUnprocessed()
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrders.Where(x => x.StatusId == 10 && x.IsDeleted == false).ToListAsync();
            }, "An exception occurred while attempting to get the purchase orders");
        }

        public async Task<PoheaderStg> Insert(PoheaderStg inc)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.STG_PurchaseOrders.AddAsync(inc);
                await _context.SaveChangesAsync();
                return inc;
            }, "An exception occurred while attempting to insert the purchase order");
        }

        public async Task<List<PoheaderStg>> BatchInsert(List<PoheaderStg> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.STG_PurchaseOrders.AddRangeAsync(incs.ToList());
                await _context.SaveChangesAsync();
                return incs;
            }, "An exception occurred while attempting to insert the purchase orders");
        }

        public async Task<PoheaderStg> Update(PoheaderStg inc)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entity = await _context.STG_PurchaseOrders.FindAsync(inc.Id);
                if (entity == null)
                {
                    return null;
                }
                _mapper.Map(inc, entity);
                await _context.SaveChangesAsync();
                return entity;
            }, "An exception occurred while attempting to Update the purchase order");
        }

        public async Task<List<PoheaderStg>> BatchUpdate(List<PoheaderStg> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var poNums = incs.Select(x => x.Ponumber).ToList();

                var entities = await _context.STG_PurchaseOrders.Where(x => poNums.Contains(x.Ponumber)).ToListAsync();

                foreach (var inc in incs)
                {
                    var entity = entities.FirstOrDefault(x => x.Ponumber == inc.Ponumber);
                    if (entity != null)
                    {
                        _mapper.Map(inc, entity);
                        entity.StatusId = 20;
                    }
                }
                await _context.SaveChangesAsync();
                return entities;
            }, "An exception occurred while attempting to Update the purchase orders");
        }

        public async Task<bool> Delete(int id)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entity = await _context.STG_PurchaseOrders.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _context.STG_PurchaseOrders.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order");
        }
        public async Task<bool> BatchDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrders.Where(x => ids.Contains(x.Id)).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.STG_PurchaseOrders.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase orders");
        }

        public async Task<bool> BatchSoftDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrders.Where(x => ids.Contains(x.Id)).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                entities.ForEach(x => x.IsDeleted = true);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase orders");
        }

        public async Task<bool> DeleteAllProcessed()
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrders.Where(x => x.IsDeleted).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.STG_PurchaseOrders.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase orders");
        }
    }
}