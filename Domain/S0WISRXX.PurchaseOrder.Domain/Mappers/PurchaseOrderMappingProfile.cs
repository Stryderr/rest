using AutoMapper;
using S0WISRXX.PurchaseOrder.Domain.Models;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Mappers
{
    public class PurchaseOrderMappingProfile : Profile
    {
        public PurchaseOrderMappingProfile()
        {

            // ENTITY TO DOAMIN

            CreateMap<PurchaseOrder3, PurchaseOrderDM>();
            CreateMap<PurchaseOrderDetail, DetailDM>();
            CreateMap<PurchaseOrderMessage, MessageDM>();
            CreateMap<PurchaseOrderMessageDetail, MessageDetailDM>();




            // DOMAIN TO ENTITY

            CreateMap<PurchaseOrderDM, PurchaseOrder3>();
            CreateMap<DetailDM, PurchaseOrderDetail>();
            CreateMap<MessageDM, PurchaseOrderMessage>();
            CreateMap<MessageDetailDM, PurchaseOrderMessageDetail>();
        }
    }
}



//.ForMember(dest => dest.Id, opt => opt.Ignore())
//.ForMember(dest => dest.StatusId, opt => opt.Ignore())
//.ForMember(dest => dest.Facility, opt => opt.MapFrom(src => MapFacility(src.Header.ShipToWarehouse, src.Header.DistributionCenterID)))
//.ForMember(dest => dest.Ponumber, opt => opt.MapFrom(src => src.Header.PONumber));