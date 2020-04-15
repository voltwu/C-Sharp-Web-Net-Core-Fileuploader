using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace jQuery_File_Upload.MVC3.Controllers
{
    [ApiController]
    public class FileuploaderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public FileuploaderController(IWebHostEnvironment env) {
            _env = env;
        }
        private string StorageRoot
        {
            get {
                String path = Path.Combine(_env.WebRootPath, "files");
                if (!System.IO.Directory.Exists(path)) {
                    System.IO.Directory.CreateDirectory(path);
                }
                return path; 
            }
        }
        private const String RoutPath = "fileupload";

        [Route("/"+ RoutPath + "/Delete/{filename}")]
        [HttpDelete]
        public ActionResult Delete(string filename)
        {
            var filePath = Path.Combine(StorageRoot, filename);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return Content("{\""+filename+"\":1}");
        }
        [HttpGet]
        [Route("/"+ RoutPath + "/Download/{filename}")]
        public void Download(string filename)
        {
            var filePath = Path.Combine(StorageRoot, filename);

            var context = HttpContext;

            if (System.IO.File.Exists(filePath))
            {
                context.Response.Clear();            
                context.Response.Headers.Add("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                context.Response.ContentType = "application/octet-stream";
                using (System.IO.FileStream fsm = new FileStream(filePath, FileMode.Open))
                {
                    byte[] bytes = new byte[1024];
                    int len = 0;
                    while ((len = fsm.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        context.Response.BodyWriter.AsStream().Write(bytes, 0, len);
                    }
                }
            }
            else
                context.Response.StatusCode = 404;
        }

        [HttpPost]
        [HttpGet]
        [Route("/"+ RoutPath + "/UploadFiles/")]
        public ActionResult UploadFiles()
        {
            var r = new List<ViewDataUploadFilesResult>();

            if(Request.Method=="POST")
            foreach (IFormFile file in Request.Form.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(Request, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }
                return Content("{\"files\":" + JsonConvert.SerializeObject(statuses) + "}");
            }
            return Content("{\"files\":" + JsonConvert.SerializeObject(r) + "}");
        }

        private void UploadPartialFile(string fileName, HttpRequest request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Form.Files.Count != 1)
                throw new Exception("file count must be one");
            var file = request.Form.Files[0];
            var inputStream = file.OpenReadStream();
            var fullPath = Path.Combine(StorageRoot, Path.GetFileName(fileName));
            using (var fs = new FileStream(fullPath, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];
                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new ViewDataUploadFilesResult()
            {
                name = fileName,
                size = file.Length,
                type = file.ContentType,
                url =$"/{RoutPath}/Download/" + file.FileName,
                deleteUrl = request.Scheme + "://" + request.Host + $"/{RoutPath}/Delete/" + file.FileName,
                thumbnailUrl = @"data:image/png;base64," + EncodeFile(fullPath),
                deleteType = "DELETE",
            });
        }
        private void UploadWholeFile(HttpRequest request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Form.Files.Count; i++)
            {
                var file = request.Form.Files[i];
                var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file.FileName));
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream).Wait();
                }
                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = file.FileName,
                    size = file.Length,
                    type = file.ContentType,
                    url = $"/{RoutPath}/Download/" + file.FileName,
                    deleteUrl = request.Scheme + "://" + request.Host + $"/{RoutPath}/Delete/" + file.FileName,
                    thumbnailUrl = @"data:image/png;base64," + EncodeFile(fullPath),
                    deleteType = "DELETE",
                });
            }
        }
        private string EncodeFile(string fileName)
        {
            Image image = generateThumbnailImage(80,80,fileName);
            byte[] bytes = imageToByteArray(image);
            return Convert.ToBase64String(bytes);
        }
        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        private Image generateThumbnailImage(int width, int height, String resourcePath)
        {
                using var resource = System.IO.File.OpenRead(resourcePath);
                Image image = Image.FromStream(resource);
                Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                return thumb;
        }
    }
    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public long size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
    }
}
