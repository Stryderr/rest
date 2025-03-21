using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Mappers;
using S0WISRXX.PurchaseOrder.Repository.Models;
using S0WISRXX.PurchaseOrder.Repository.Repositories.Context;

namespace S0WISRXX.PurchaseOrder.Repository.Repositories
{

    public class STG_DetailRepository : BaseRepository<PodetailStg>, ISTG_DetailRepository
    {
        private readonly IMapper _mapper;

        public STG_DetailRepository(PurchaseOrderContext context, IUtilityLogger logger) : base(context, logger)
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderRepoMappingProfile>()).CreateMapper();

        }


        public async Task<PodetailStg?> GetById(int id)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrderDetails.FindAsync(id) ?? null;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<List<PodetailStg>?> GetByPoNum(int poNum)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entity = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.Ponumber == poNum);
                return (entity == null) ? null : await _context.STG_PurchaseOrderDetails.Where(x => x.PurchaseOrderId == entity.Id).ToListAsync();
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<List<PodetailStg>> GetAllUnprocessed()
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.STG_PurchaseOrderDetails.Where(x => x.IsDeleted == false).ToListAsync();
            }, "An exception occurred while attempting to get the purchase order details");
        }

        public async Task<PodetailStg> Insert(PodetailStg inc)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.STG_PurchaseOrderDetails.AddAsync(inc);
                await _context.SaveChangesAsync();
                return inc;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<List<PodetailStg>> BatchInsert(List<PodetailStg> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.STG_PurchaseOrderDetails.AddRangeAsync(incs.ToList());
                await _context.SaveChangesAsync();
                return incs;
            }, "An exception occurred while attempting to insert the purchase order details");
        }

        public async Task<PodetailStg> Update(PodetailStg inc)
        {
            var entity = await _context.STG_PurchaseOrderDetails.FindAsync(inc.Id);
            if (entity == null)
            {
                return null;
            }
            _mapper.Map(inc, entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<PodetailStg>> BatchUpdate(List<PodetailStg> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var ids = incs.Select(x => x.Id).ToList();

                var entities = await _context.STG_PurchaseOrderDetails.Where(x => ids.Contains(x.Id)).ToListAsync();

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
                var entity = await _context.STG_PurchaseOrderDetails.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _context.STG_PurchaseOrderDetails.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<bool> BatchDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrderDetails.Where(x => ids.Contains(x.Id)).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.STG_PurchaseOrderDetails.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<bool> BatchSoftDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.STG_PurchaseOrderDetails.Where(x => ids.Contains(x.Id)).ToListAsync();
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
                var entities = await _context.STG_PurchaseOrderDetails.Where(x => x.IsDeleted).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.STG_PurchaseOrderDetails.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }
    }
}