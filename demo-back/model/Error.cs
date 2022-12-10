
using System.Runtime.Serialization;


namespace demo_proj_backend.Models
{
    [DataContract(Name = "Response")]
    public class Error
    {
        [DataMember(Name = "Message", EmitDefaultValue = false)]
        public string Message { get; set; } = " ";

        [DataMember(Name = "Status", EmitDefaultValue = false)]
        public int Status { get; set; }

        [DataMember(Name = "header", EmitDefaultValue = false)]
        public string header { get; set; } = " ";
    }
}

