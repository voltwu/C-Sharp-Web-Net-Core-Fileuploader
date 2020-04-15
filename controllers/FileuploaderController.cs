using ImageUploader.security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jQuery_File_Upload.MVC3.Controllers
{
    [ApiController]
    public class FileuploaderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public FileuploaderController(IWebHostEnvironment env) {
            _env = env;
        }
        /// <summary>
        /// 图片文件存储路径
        /// </summary>
        private string StorageRoot
        {
            get {
                //按照年 / 月 分目录
                String path = Path.Combine(_env.WebRootPath, 
                    "files", 
                    Convert.ToString(DateTime.Now.Year),
                    Convert.ToString(DateTime.Now.Month));

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                return path; 
            }
        }

        private const String RoutPath = "fileupload";

        #region GET 对外接口，实例化当前服务器上的SecurityStrategy
        /// <summary>
        /// 实例SecurityStrategy的接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/"+ RoutPath + "/intancestrategy")]
        public ActionResult instanceSecurityStrategy() {
            SecurityStrategy.getInstance(false).getCurrentKey();
            return Content("okay");
        }
        #endregion

        #region GET 对外接口，获取文件加载的模块，需要key验证
        /// <summary>
        /// 获取文件加载组件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/"+ RoutPath + "/strategy/{key}")]
        [SecurityStrategyAuthentication]
        public async Task<ActionResult> getUploaderAsync()
        {
            String result = "";
            //显示模板文件中的内容
            String path = _env.ContentRootPath + "/Pages/Shared/_fileUploadTemplate.html";
            result = await System.IO.File.ReadAllTextAsync(path);
            return Content(result);
        }
        #endregion

        #region DELETE 对外接口，删除文件，需要key验证
        /// <summary>
        /// 删除图片文件，需要验证
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [HttpDelete]
        [SecurityStrategyAuthentication]
        [Route("/" + RoutPath + "/Delete/{filename}/{key}")]
        public ActionResult Delete(string filename)
        {
            var filePath = Path.Combine(StorageRoot, filename);
            deleteFile(filePath);
            return Content("{\""+filename+"\":1}");
        }
        #endregion

        #region GET 对外接口 下载图片文件
        /// <summary>
        /// 对外接口 下载文件
        /// </summary>
        /// <param name="filename"></param>
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
        #endregion

        #region POST/GET 对外接口，上传图片文件，需要key验证
        /// <summary>
        /// 对外接口，上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HttpGet]
        [SecurityStrategyAuthentication]
        [Route("/"+ RoutPath + "/UploadFiles/{key}")]
        public ActionResult UploadFiles()
        {
            var r = new List<IViewDataUploadFilesResult>();

            if(Request.Method=="POST")
            foreach (IFormFile file in Request.Form.Files)
            {
                var statuses = new List<IViewDataUploadFilesResult>();
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

        /// <summary>
        /// 上传更新某一个文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="request"></param>
        /// <param name="statuses"></param>
        private void UploadPartialFile(string fileName, HttpRequest request, List<IViewDataUploadFilesResult> statuses)
        {
            if (request.Form.Files.Count != 1)
                throw new Exception("file count must be one");
            var file = request.Form.Files[0];
            var inputStream = file.OpenReadStream();
            String _file_NewName = uniqueFileName() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(StorageRoot, _file_NewName);

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
            if (isValidImageFile(fullPath))
            {
                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = fileName,
                    size = file.Length,
                    type = file.ContentType,
                    url = $"/{RoutPath}/Download/" + _file_NewName,
                    deleteUrl = request.Scheme + "://" + request.Host + $"/{RoutPath}/Delete/" + _file_NewName + "/" + SecurityStrategy.getInstance().getCurrentKey(),
                    thumbnailUrl = @"data:image/png;base64," + EncodeFile(fullPath),
                    deleteType = "DELETE",
                });
            }
            else
            {   //不是一个有效的图片文件
                deleteFile(fullPath);
                statuses.Add(new ViewDataUploadFileErrorResult()
                {
                    name = file.FileName,
                    size = file.Length,
                    error = "The current format is not supported"
                });
            }
        }
        /// <summary>
        /// 上传存储新文件
        /// </summary>
        /// <param name="request"></param>
        /// <param name="statuses"></param>
        private void UploadWholeFile(HttpRequest request, List<IViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Form.Files.Count; i++)
            {
                var file = request.Form.Files[i];
                String _file_NewName = uniqueFileName() + Path.GetExtension(file.FileName);
                var fullPath = Path.Combine(StorageRoot, _file_NewName);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream).Wait();
                }
                if (isValidImageFile(fullPath)) { 
                    statuses.Add(new ViewDataUploadFilesResult()
                    {
                        name = file.FileName,
                        size = file.Length,
                        type = file.ContentType,
                        url = $"/{RoutPath}/Download/" + _file_NewName,
                        deleteUrl = request.Scheme + "://" + request.Host + $"/{RoutPath}/Delete/" + _file_NewName + "/" + SecurityStrategy.getInstance().getCurrentKey(),
                        thumbnailUrl = @"data:image/png;base64," + EncodeFile(fullPath),
                        deleteType = "DELETE",
                    });
                }
                else {//不是一个有效的图片文件
                    deleteFile(fullPath);
                    statuses.Add(new ViewDataUploadFileErrorResult()
                    {
                        name = file.FileName,
                        size = file.Length,
                        error = "The current format is not supported"
                    });
                }
            }
        }
        #endregion

        #region 辅助工具函数
        public static bool isValidImageFile(String path)
        {
            using (FileStream fs = System.IO.File.OpenRead(path))
            {
                byte[] header = new byte[10];
                fs.Read(header, 0, 10);
                if (ImageFormatHelper.ImageFormat.unknown !=
                    ImageFormatHelper.GetImageFormat(header)) {
                    return true;
                }
            }
            return false;
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
        private void deleteFile(String fullPath) {
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);
        }
        private String uniqueFileName() {
            return
                String.Format("{0}-{1}",
                DateTime.Now.ToString("yyyyMMddHHmm"),
                Guid.NewGuid().ToString());
        }
        #endregion
    }

    #region 图片格式判断辅助类
    class ImageFormatHelper {
        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }
        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
    }
    #endregion

    #region 文件上传返回结果Model
    public class ViewDataUploadFilesResult : IViewDataUploadFilesResult
    {
        public string name { get; set; }
        public long size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
    }
    public class ViewDataUploadFileErrorResult : IViewDataUploadFilesResult {
        public string name { set; get; }
        public long size { set; get; }
        public string error { set; get; }
    }
    public interface IViewDataUploadFilesResult { 
        
    }
    #endregion

}
