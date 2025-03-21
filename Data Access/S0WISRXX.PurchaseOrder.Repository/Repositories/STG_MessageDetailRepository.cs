using Microsoft.EntityFrameworkCore;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Models;
using S0WISRXX.PurchaseOrder.Repository.Repositories.Context;

namespace S0WISRXX.PurchaseOrder.Repository.Repositories
{

    public class STG_MessageDetailRepository : BaseRepository<PoextendedMessageDetailStg>, ISTG_MessageDetailRepository
    {

        public STG_MessageDetailRepository(PurchaseOrderContext context, IUtilityLogger logger) : base(context, logger)
        {
        }


        public async Task<PoextendedMessageDetailStg?> GetById(int id)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrderMessageDetails.FindAsync(id) ?? null;
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<List<PoextendedMessageDetailStg>?> GetByPoNum(int poNum)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entity = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.Ponumber == poNum);
                return (entity == null) ? null : await _context.STG_PurchaseOrderMessageDetails.Where(x => x.PurchaseOrderId == entity.Id).ToListAsync();
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<List<PoextendedMessageDetailStg>> GetAllUnprocessed()
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrderMessageDetails.Where(x => x.IsDeleted == false).ToListAsync();
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<PoextendedMessageDetailStg> Insert(PoextendedMessageDetailStg inc)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.STG_PurchaseOrderMessageDetails.AddAsync(inc);
                await _context.SaveChangesAsync();
                return inc;
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<List<PoextendedMessageDetailStg>> BatchInsert(List<PoextendedMessageDetailStg> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.STG_PurchaseOrderMessageDetails.AddRangeAsync(incs.ToList());
                await _context.SaveChangesAsync();
                return incs;
            }, "An exception occurred while attempting to insert the purchase order details");
        }

        public async Task<PoextendedMessageDetailStg> Update(PoextendedMessageDetailStg inc)
        {
            var entity = await _context.PurchaseOrderMessages.FindAsync(inc.Id);
            if (entity == null)
            {
                return null;
            }
            _mapper.Map(inc, entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<PoextendedMessageDetailStg>> BatchUpdate(List<PoextendedMessageDetailStg> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var ids = incs.Select(x => x.Id).ToList();

                var entities = await _context.STG_PurchaseOrderMessageDetails.Where(x => ids.Contains(x.Id)).ToListAsync();

                foreach (var inc in incs)
                {
                    var entity = entities.FirstOrDefault(x => x.Id == inc.Id);
                    if (entity != null)
                    {
                        _mapper.Map(inc, entity);
                    }
                }
                await _context.SaveChangesAsync();
                return entities;
            }, "An exception occurred while attempting to Update the purchase order details");
        }

        public async Task<bool> Delete(int id)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entity = await _context.PurchaseOrderMessages.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _context.PurchaseOrderMessages.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<bool> BatchDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrderMessageDetails.Where(x => ids.Contains(x.Id)).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.STG_PurchaseOrderMessageDetails.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<bool> BatchSoftDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrderMessageDetails.Where(x => ids.Contains(x.Id)).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                entities.ForEach(x => x.IsDeleted = true);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<bool> DeleteAllProcessed()
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrderMessageDetails.Where(x => x.IsDeleted).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.STG_PurchaseOrderMessageDetails.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }
    }
}