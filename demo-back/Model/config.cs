using System.Runtime.Serialization;

namespace demo_back.Model
{
    [DataContract(Name = "Congig")]
    public class Congig
    {
        [DataMember(Name = "directory", EmitDefaultValue = false)]
        public string? directory { get; set; } = "D:\\jaydip\\dotnetbackend\\demo-back\\demo-back\\wwwroot\\uploads";
    }
}