using System.ComponentModel;

namespace S0WISRXX.PurchaseOrder.Crosscutting.Enums
{
    public enum PurchaseOrderStatusEnum
    {
        [AmbientValue(-99)]
        Suspended,                          //When received PO from Marwood which is closed in WMS already

        [AmbientValue(-50)]
        SendToWMSFailed,                    //Fail to send data to WMS= -50,

        [AmbientValue(-20)]
        LoadFailed,                         //Fail to read data from stage table,

        [AmbientValue(0)]
        Unknown,                            //

        [AmbientValue(10)]
        Staged,                             //Get data from MQ/Kafka or from third party and stage them in tables

        [AmbientValue(20)]
        Loaded,                             //Read from stage table and put data into main tables

        [AmbientValue(30)]
        InProcess,                          //Data being called throught API for further processing

        [AmbientValue(40)]
        SendToWMSProhibited,                //Data has been processed but restricted to send to WMSted = 40,

        [AmbientValue(50)]
        SentToWMS,                          //Data sent to WMS

        [AmbientValue(60)]
        WarehouseInactive,                  //Specific warehouse is Inactive due to some reason doesn't mean it is in maintenancee = 60,

        [AmbientValue(70)]
        POClosed,                           //This status is specific to purchase order being received and closed in WISR

        [AmbientValue(99)]
        Completed,                          //
    }
}