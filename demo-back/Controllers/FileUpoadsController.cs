using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Channels;
using System.Collections.Generic;
using demo_back.Model;
using Microsoft.AspNetCore.Http.Metadata;
using System.Net;
using demo_proj_backend.Models;
using demo_back.model;
using demo_back.Handler;

namespace demo_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpoadsController : ControllerBase
    {
        public static IWebHostEnvironment? _webHostEnvironment;
        BoFileUpoads drop = new BoFileUpoads();
        PostDataResponseHelper Responce = new PostDataResponseHelper();
        public FileUpoadsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("upload")]
        public PostDataResponseHelper Post([FromForm] FileUploads fileUpload)
        {

            try
            {
                
                if (fileUpload.files?.Length > 0)
                {
                    string path = _webHostEnvironment?.WebRootPath + "\\uploads\\";
                    //this is also work properly
                    //tring path = "D:/jaydip/dotnetbackend/demo-back/demo-back/wwwroot/uploads/";

                   
                    if (System.IO.File.Exists((path + fileUpload.files.FileName).ToString()))
                    {
                        //return "File Already Uploaded";
                        Responce.Status = (int)HttpStatusCode.BadRequest;
                        Responce.Message = "File Already Uploaded";
                        Responce.StatusText = "BadRequest";
                        Responce.Ok = false;
                        return Responce;
                    }

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.files.FileName))
                    {
                        fileUpload.files.CopyTo(fileStream);
                        fileStream.Flush();

                        //database insert is here
                        //===================================
         
                        String msg = string.Empty;
                       
                  
                        try
                        {
                            fileUpload.Type = "insert";
                            fileUpload.FileName = fileUpload.files.FileName;
                            fileUpload.FileUrl = (path + fileUpload.files.FileName).ToString();
                            fileUpload.FileType = fileUpload.files.ContentType;


                            msg = drop.AddAndUpdatEmployeeDetails(fileUpload);
                        }
                        catch (Exception ex)
                        {

                            Responce.Status = (int)HttpStatusCode.BadRequest;
                            Responce.Message = ex.Message;
                            Responce.StatusText = "BadRequest";
                            Responce.Headers = "Registraion Failed ,Record is Not Inserted.";
                            Responce.Ok = false;
                            return Responce;

                        }
                        Responce.Status = (int)HttpStatusCode.Created;
                        Responce.Message = msg;
                        Responce.StatusText = "Created";
                        Responce.Ok = true;
                        return Responce;
                        //===================================






                      //  return "Upload Succesfully.";
                    }
                }
                else
                {
                    Responce.Status = (int)HttpStatusCode.BadRequest;
                    Responce.Message = "Upload Failed";
                    Responce.StatusText = "BadRequest";
                    Responce.Headers = "Upload Failed";
                    Responce.Ok = false;
                    return Responce;
                   // return "Upload Failed";
                }
            }
            catch (Exception ex)
            {
                Responce.Status = (int)HttpStatusCode.BadRequest;
                Responce.Message = ex.Message;
                Responce.StatusText = "BadRequest";
                Responce.Headers = "Registraion Failed ,Record is Not Inserted.";
                Responce.Ok = false;
                return Responce;
               // return ex.Message;
            }
        }

        [HttpGet]
        [Route("getimage")]
        public async Task<IActionResult> Get([FromBody] GetFile filename)
        {
            FromRouteAttribute r = new FromRouteAttribute();
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + filename.filename + ".png";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/png");
            }
            return null;
        }

    }
}
