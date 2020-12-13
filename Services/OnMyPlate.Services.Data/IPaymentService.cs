namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface IPaymentService
    {
        IEnumerable<KeyValuePair<int, string>> GetAllPaymentTypesAsKeyValuePairs();
    }
}
