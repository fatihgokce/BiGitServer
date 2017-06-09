using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

using BiGitServer.Web.Middlewares;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiGitServer.Web.Controllers
{
    [MiddlewareFilter(typeof(GitAuthenticationMiddlewarePipeline))]
    public class GitController : BaseApi
    {
        // GET: /<controller>/
        public IActionResult Repo(string project, string service, string verb)
        {
            bool isClone = string.Equals("git-upload-pack", verb, StringComparison.OrdinalIgnoreCase);

            switch (verb)
            {
                case "info/refs":
                    return InfoRefs(project, service);
                case "git-upload-pack":
                    {
                        return RunCommand(project, verb);
                    }
                case "git-receive-pack":
                    return RunCommand(project, "git-receive-pack");
                default: return Content($"project:{project} verb:{verb}"); ;
            }

        }
        public ActionResult InfoRefs(string project, string service)
        {
            //Response.Charset = "";
            Response.ContentType = String.Format(CultureInfo.InvariantCulture, "application/x-{0}-advertisement", service);
            string input = FormatMessage(String.Format(CultureInfo.InvariantCulture, "# service={0}\n", service));
            WriteBody(input);
            WriteBody("0000");
            string svc = service.Substring(4);//git-upload-pack remove git-
            RunProcess(true, project, GetInputStream(), Response.Body, svc);
            return new EmptyResult();

        }
        public ActionResult RunCommand(string project, string verb)
        {
            Response.StatusCode = 200;
            Response.ContentType = "application/x-git-upload-pack-result";
            // SetNoCache
            SetNoCache();

            //Response.Body.BufferOutput = false;
            //Response.Charset = "";
            string sevice = verb.Substring(4);//git-upload-pack remove git-
            RunProcess(false, project, GetInputStream(), Response.Body, sevice);


            return new EmptyResult();
        }
        private void WriteBody(string input)
        {
            var bytes= Encoding.ASCII.GetBytes(input);
            Response.Body.Write(bytes, 0, bytes.Length);
        }
      
        private void RunProcess(bool advertiseRefs, string project, Stream inputStream, Stream outputStream, string service)
        {
            var args = service + " --stateless-rpc";
            if (advertiseRefs)
            {
                args += " --advertise-refs";
            }

            var projectPath =Path.Combine( Path.Combine(Directory.GetCurrentDirectory(),"App_Data"), "GitProjects");
            string repoPath = projectPath;
            projectPath = Path.Combine(projectPath, project);
            args += " \"" + projectPath + "\"";
            //C:\Program Files\Git\mingw64\libexec\git-core\git.exe
            //var gitPath = @"C:\Program Files\Git\mingw64\libexec\git-core\git.exe";
            var gitPath = @"C:\Program Files\Git\bin\git.exe";
            var info = new ProcessStartInfo(gitPath, args)
            {
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(repoPath),
            };

            using (var process = System.Diagnostics.Process.Start(info))
            {
                inputStream.CopyTo(process.StandardInput.BaseStream);
                process.StandardInput.Dispose();
                process.StandardOutput.BaseStream.CopyTo(outputStream);

                process.WaitForExit();
            }
        }
        private void SetNoCache()
        {
            Response.Headers.Add("Expires", "Fri, 01 Jan 1980 00:00:00 GMT");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Cache-Control", "no-cache, max-age=0, must-revalidate");
        }

        private Stream GetInputStream()
        {
            if (Request.Headers["Content-Encoding"] == "gzip")
            {
                return new GZipStream(Request.Body, CompressionMode.Decompress);
            }
            return Request.Body;
        }

        private static string FormatMessage(string input)
        {
            return (input.Length + 4).ToString("X4", CultureInfo.InvariantCulture) + input;
        }
    }
}
