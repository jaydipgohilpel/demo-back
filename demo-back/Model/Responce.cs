
using demo_back.model;
using System.Net;
using System.Runtime.Serialization;


namespace demo_proj_backend.Models
{
    [DataContract(Name = "ResponseHelper")]
    public class PostDataResponseHelper
    {
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; set; } = " ";

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int? Status { get; set; } = 0;

        [DataMember(Name = "statusText", EmitDefaultValue = false)]
        public string? StatusText { get; set; } = " ";

        [DataMember(Name = "ok", EmitDefaultValue = false)]
        public Boolean? Ok { get; set; } = false;

        [DataMember(Name = "headers", EmitDefaultValue = true)]
        public string? Headers { get; set; } = "HttpResponce";
        
    }
    public class GetDataResponseHelper
    {
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; set; } = "Record Featched successfully";

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int? Status { get; set; } = (int)HttpStatusCode.OK;

        [DataMember(Name = "statusText", EmitDefaultValue = false)]
        public string? StatusText { get; set; } = "OK";

        [DataMember(Name = "data", EmitDefaultValue = false)]
        public List<EmployeeModel>? Data { get; set; }

        [DataMember(Name = "ok", EmitDefaultValue = false)]
        public Boolean? Ok { get; set; } = true;

    }
}

