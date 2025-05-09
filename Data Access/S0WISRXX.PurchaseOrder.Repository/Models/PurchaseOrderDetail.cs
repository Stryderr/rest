﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace S0WISRXX.PurchaseOrder.Repository.Models;

public partial class PurchaseOrderDetail : BaseModel
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public string ActionCode { get; set; }
    [NotMapped]
    public int PONumber { get; set; }
    public string ItemCode { get; set; }

    public string BackOrderAllowed { get; set; }

    public string NetCost { get; set; }

    public string ListCost { get; set; }

    public string CostAdjust1 { get; set; }

    public string CostAdjust2 { get; set; }

    public string CostAdjust3 { get; set; }

    public string VendorTi { get; set; }

    public string VendorHi { get; set; }

    public string QuantityOrdered { get; set; }

    public string LotNumber { get; set; }

    public string ShipPack { get; set; }

    public string PromoInvestCode { get; set; }

    public string ReqCost { get; set; }

    public string PolineNo { get; set; }

    public string ProdDetailId { get; set; }

    public string IrmswarehouseId { get; set; }

    public string ShipWeight { get; set; }

    public string Pgmname { get; set; }

    public string LastUpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PurchaseOrder3 PurchaseOrder { get; set; }

}