using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.Serialization;

namespace demo_back.Model
{

    /****** Script for SelectTopNRows command from SSMS  ******/
    
    [DataContract(Name = "FileUploads")]
    public class FileUploads
    {
        [DataMember(Name = "files", EmitDefaultValue = false)]
        public IFormFile? files { get; set; }

        [DataMember(Name = "FileName", EmitDefaultValue = false)]
        public string? FileName { get; set; } = "";

        [DataMember(Name = "FileType", EmitDefaultValue = false)]
        public string? FileType { get; set; } = "";

        [DataMember(Name = "FileUrl", EmitDefaultValue = false)]
        public string? FileUrl { get; set; } = "";

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string? Type { get; set; }
    }

    [DataContract(Name = "GetFile")]
    public class GetFile
    {
        [DataMember(Name = "filename", EmitDefaultValue = false)]
        public string? filename { get; set; }
    }

    [DataContract(Name = "getAllFile")]
    public class GetAllFile
    {

        //[DataMember(Name = "files", EmitDefaultValue = false)]
        //public IFormFile? files { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public IFormFile? Id { get; set; }

        [DataMember(Name = "FileName", EmitDefaultValue = false)]
        public string? FileName { get; set; }

        [DataMember(Name = "FileUrl", EmitDefaultValue = false)]
        public string? FileUrl { get; set; }

        [DataMember(Name = "FileType", EmitDefaultValue = false)]
        public string? FileType { get; set; }

        [DataMember(Name = "Status", EmitDefaultValue = false)]
        public int? Status { get; set; }

        [DataMember(Name = "Uploaded_On", EmitDefaultValue = false)]
        public string? Uploaded_On { get; set; }

       
    }
}