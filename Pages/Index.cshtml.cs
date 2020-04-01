using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ImageUploader.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IWebHostEnvironment _env;
        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public async Task OnGet()
        {
            String strategyJsFile = _env.ContentRootPath+ "/Pages/Shared/strategy.js";
            String text = await System.IO.File.ReadAllTextAsync(strategyJsFile);

            //替换private key
            text = text.Replace("{PRIVATEKEY}", security.SecurityStrategy.getInstance().getCurrentKey());

            //指定特定要上传的HOST地址，如果没有，就替换为空字符串
            text = text.Replace("{HOST}",String.Empty);
            //加密
            ViewData["strategyJs"] = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
        }
    }
}
