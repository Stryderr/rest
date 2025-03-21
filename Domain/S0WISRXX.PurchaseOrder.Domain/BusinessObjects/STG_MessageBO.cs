using AutoMapper;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Domain.Mappers;
using S0WISRXX.PurchaseOrder.Domain.Models;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Domain.BusinessObjects
{

    public class STG_MessageBO : ISTG_MessageBO
    {
        private readonly IUtilityLogger _logger;
        private readonly ISTG_MessageRepository _repo;
        private readonly IMapper _mapper;

        public STG_MessageBO(IUtilityLogger logger, ISTG_MessageRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderMappingProfile>()).CreateMapper();
        }


        public async Task<STG_MessageDM> GetById(int id)
        {
            try
            {
                var result = await _repo.GetById(id);
                return _mapper.Map<STG_MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<STG_MessageDM> GetByPoNum(int poNum)
        {
            try
            {
                var result = await _repo.GetByPoNum(poNum);
                return _mapper.Map<STG_MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<STG_MessageDM>> GetAllUnprocessed()
        {
            try
            {
                var result = await _repo.GetAllUnprocessed();
                return _mapper.Map<List<STG_MessageDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<STG_MessageDM> Insert(STG_MessageDM inc)
        {
            try
            {
                var entity = _mapper.Map<PoextendedMessageHeaderStg>(inc);
                var result = await _repo.Insert(entity);
                return _mapper.Map<STG_MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<STG_MessageDM>> BatchInsert(List<STG_MessageDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PoextendedMessageHeaderStg>>(inc);
                var result = await _repo.BatchInsert(entities);
                return _mapper.Map<List<STG_MessageDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<STG_MessageDM> Update(STG_MessageDM inc)
        {
            try
            {
                var entity = _mapper.Map<PoextendedMessageHeaderStg>(inc);
                var result = await _repo.Update(entity);
                return _mapper.Map<STG_MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<STG_MessageDM>> BatchUpdate(List<STG_MessageDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PoextendedMessageHeaderStg>>(inc);
                var result = await _repo.BatchUpdate(entities);
                return _mapper.Map<List<STG_MessageDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> BatchDelete(List<int> ids)
        {
            try
            {
                return await _repo.BatchDelete(ids);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> BatchSoftDelete(List<int> ids)
        {
            try
            {
                return await _repo.BatchSoftDelete(ids);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteAllProcessed()
        {
            try
            {
                return await _repo.DeleteAllProcessed();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
