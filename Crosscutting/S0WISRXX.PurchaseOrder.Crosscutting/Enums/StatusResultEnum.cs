using System.ComponentModel;

namespace S0WISRXX.PurchaseOrder.Crosscutting.Enums
{
    public enum StatusResultEnum
    {
        [AmbientValue("SUCCESS")]
        Success,

        [AmbientValue("FAILED")]
        Failed,

        [AmbientValue("SKIPPED")]
        Skipped,

        [AmbientValue("DEFAULT")]
        Default
    }
}
