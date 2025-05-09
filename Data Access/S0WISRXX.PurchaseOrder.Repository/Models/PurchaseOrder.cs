﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace S0WISRXX.PurchaseOrder.Repository.Models;

public partial class PurchaseOrder3 : BaseModel
{
    public int Id { get; set; }

    public int Facility { get; set; }

    public int Ponumber { get; set; }

    public int StatusId { get; set; }

    public string ActionCode { get; set; }

    public string Department { get; set; }

    public string Vendor { get; set; }

    public string Buyer { get; set; }

    public string TransportationMethod { get; set; }

    public string LoadType { get; set; }

    public string Fobcode { get; set; }

    public string FreightBasisCode { get; set; }

    public string CancelDate { get; set; }

    public string CreatedDate { get; set; }

    public string PickUpDate { get; set; }

    public string ScheduledReceiptDate { get; set; }

    public string RequestedShipDate { get; set; }

    public string FreightChargeCode { get; set; }

    public string FreightChargeAmount { get; set; }

    public string FreightAllowanceCode { get; set; }

    public string FreightAllowanceAmount { get; set; }

    public string FreightTerms { get; set; }

    public string Potype { get; set; }

    public string PotypeDescription { get; set; }

    public string Message1 { get; set; }

    public string Message2 { get; set; }

    public string Message3 { get; set; }

    public string PalletDisposition { get; set; }

    public string Carrier { get; set; }

    public string ResponsibilityCode { get; set; }

    public string BuyerName { get; set; }

    public string ScheduledReceiptTime { get; set; }

    public string SpecialMessage { get; set; }

    public string TrailerOrRailCarNumber { get; set; }

    public string PlannedArrivalDate { get; set; }

    public string TransportationType { get; set; }

    public string CarrierNumber { get; set; }

    public string ReceivingLocation { get; set; }

    public string DropTrailer { get; set; }

    public string RapidReplenishment { get; set; }

    public string Deanumber { get; set; }

    public int? TransferFileStatusId { get; set; }

    public string LastUpdatedBy { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    public virtual ICollection<PurchaseOrderMessageDetail> PurchaseOrderMessageDetails { get; set; } = new List<PurchaseOrderMessageDetail>();

    public virtual ICollection<PurchaseOrderMessage> PurchaseOrderMessages { get; set; } = new List<PurchaseOrderMessage>();
}