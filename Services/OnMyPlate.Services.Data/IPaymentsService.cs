namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;

    public interface IPaymentsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllPaymentTypesAsKeyValuePairs();

        int GetCounts();
    }
}
