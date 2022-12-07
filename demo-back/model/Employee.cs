using System.Runtime.Serialization;
using System.Xml.Linq;

namespace demo_back.model
{
    [DataContract(Name = "regModel")]
    public class Employee
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int? Id { get; set; }

        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(Name = "dateOfBirth", EmitDefaultValue = false)]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Name = "mobile", EmitDefaultValue = false)]
        public string Mobile { get; set; }

        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

    }
}