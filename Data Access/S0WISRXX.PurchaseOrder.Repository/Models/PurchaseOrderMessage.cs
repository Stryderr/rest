﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace S0WISRXX.PurchaseOrder.Repository.Models;

public partial class PurchaseOrderMessage : BaseModel
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public int StatusId { get; set; }
    [NotMapped]
    public int PONumber { get; set; }

    [NotMapped]
    public int Facility { get; set; }
    public string ActionCode { get; set; }

    public string MessageNumber { get; set; }

    public string ChangedDate1 { get; set; }

    public string ChangedOperator1 { get; set; }

    public string ChangedDate2 { get; set; }

    public string ChangedOperator2 { get; set; }

    public string ChangedDate3 { get; set; }

    public string ChangedOperator3 { get; set; }

    public string LastUpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PurchaseOrder3 PurchaseOrder { get; set; }

    public virtual ICollection<PurchaseOrderMessageDetail> PurchaseOrderMessageDetails { get; set; } = new List<PurchaseOrderMessageDetail>();
}