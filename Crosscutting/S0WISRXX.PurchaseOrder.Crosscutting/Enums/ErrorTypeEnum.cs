using System.ComponentModel;

namespace S0WISRXX.PurchaseOrder.Crosscutting.Enums
{
    public enum ErrorTypeEnum
    {
        [AmbientValue(-100)]
        GenericValidationError,

        [AmbientValue(-200)]
        DatabaseException,

        [AmbientValue(-300)]
        NotAuthorized
    }
}