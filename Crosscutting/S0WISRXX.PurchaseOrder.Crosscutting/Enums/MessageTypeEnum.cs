using System.ComponentModel;

namespace S0WISRXX.PurchaseOrder.Crosscutting.Enums
{
    public enum MessageTypeEnum
    {
        [AmbientValue("PO      HEADER")]
        PoHeader,

        [AmbientValue("PO      DETAIL")]
        PoDetail,

        [AmbientValue("EXT MSG HEADER")]
        PoMsgHeader,

        [AmbientValue("EXT MSG DETAIL")]
        PoMsgDetail,

        [AmbientValue("TRANSREQHEADER")]
        TransReqHeader,

        [AmbientValue("TRANSREQDETAIL")]
        TransReqDetail,

        [AmbientValue("DEFAULT")]
        Default
    }
}
