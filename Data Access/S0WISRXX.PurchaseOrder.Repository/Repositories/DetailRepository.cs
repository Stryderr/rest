using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Mappers;
using S0WISRXX.PurchaseOrder.Repository.Models;
using S0WISRXX.PurchaseOrder.Repository.Repositories.Context;

namespace S0WISRXX.PurchaseOrder.Repository.Repositories
{

    public class DetailRepository : BaseRepository<PurchaseOrderDetail>, IDetailRepository
    {
        private readonly IMapper _mapper;

        public DetailRepository(PurchaseOrderContext context, IUtilityLogger logger) : base(context, logger)
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderRepoMappingProfile>()).CreateMapper();

        }


        public async Task<PurchaseOrderDetail?> GetById(int id)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.PurchaseOrderDetails.FindAsync(id) ?? null;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<List<PurchaseOrderDetail>?> GetByPoNum(int poNum)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entity = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.Ponumber == poNum);
                return (entity == null) ? null : await _context.PurchaseOrderDetails.Where(x => x.PurchaseOrderId == entity.Id).ToListAsync();
            }, "An exception occurred while attempting to delete the purchase order");
        }

        public async Task<List<PurchaseOrderDetail>> GetAllUnprocessed()
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                return await _context.PurchaseOrderDetails.Where(x => x.IsDeleted == false).ToListAsync();
            }, "An exception occurred while attempting to get the purchase order details");
        }

        public async Task<PurchaseOrderDetail> Insert(PurchaseOrderDetail inc)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.PurchaseOrderDetails.AddAsync(inc);
                await _context.SaveChangesAsync();
                return inc;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<List<PurchaseOrderDetail>> BatchInsert(List<PurchaseOrderDetail> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                await _context.PurchaseOrderDetails.AddRangeAsync(incs.ToList());
                await _context.SaveChangesAsync();
                return incs;
            }, "An exception occurred while attempting to insert the purchase order details");
        }

        public async Task<PurchaseOrderDetail> Update(PurchaseOrderDetail inc)
        {
            var entity = await _context.PurchaseOrderDetails.FindAsync(inc.Id);
            if (entity == null)
            {
                return null;
            }
            _mapper.Map(inc, entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<PurchaseOrderDetail>> BatchUpdate(List<PurchaseOrderDetail> incs)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var ids = incs.Select(x => x.Id).ToList();

                var entities = await _context.PurchaseOrderDetails.Where(x => ids.Contains(x.Id)).ToListAsync();

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
                var entity = await _context.PurchaseOrderDetails.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _context.PurchaseOrderDetails.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<bool> BatchDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.PurchaseOrderDetails.Where(x => ids.Contains(x.Id)).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.PurchaseOrderDetails.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }

        public async Task<bool> BatchSoftDelete(List<int> ids)
        {
            return await ExecuteWithLoggingAsync(async () =>
            {
                var entities = await _context.PurchaseOrderDetails.Where(x => ids.Contains(x.Id)).ToListAsync();
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
                var entities = await _context.PurchaseOrderDetails.Where(x => x.IsDeleted).ToListAsync();
                if (entities.Count == 0)
                {
                    return false;
                }
                _context.PurchaseOrderDetails.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }, "An exception occurred while attempting to delete the purchase order details");
        }
    }
}