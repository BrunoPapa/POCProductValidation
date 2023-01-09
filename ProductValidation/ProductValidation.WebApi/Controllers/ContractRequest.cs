using System.Collections.Generic;

namespace ProductValidation.WebApi.Controllers
{
    public class ContractRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<FieldsRequest> Fields { get; set; }
    }

    public class FieldsRequest
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
}