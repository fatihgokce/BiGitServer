using BiGitServer.Web.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiGitServer.Web.Controllers
{
    [GitAuthorize]
    public class GitController : Controller
    {
        // GET: Git
        public ActionResult Repo(string project,string service,string verb)
        {
            bool isClone = string.Equals("git-upload-pack", verb, StringComparison.OrdinalIgnoreCase);
         
            switch (verb)
            {
                case "info/refs":
                    return InfoRefs(project, service);
                case "git-upload-pack":
                    {
                        return RunCommand(project,verb);
                    }
                case "git-receive-pack":
                    return RunCommand(project, "git-receive-pack");
                default: return Content($"project:{project} verb:{verb}"); ;
            }
           
        }
        public ActionResult InfoRefs(string project,string service)
        {
            Response.Charset = "";
            Response.ContentType = String.Format(CultureInfo.InvariantCulture, "application/x-{0}-advertisement", service);
          
            Response.Write(FormatMessage(String.Format(CultureInfo.InvariantCulture, "# service={0}\n", service)));
            Response.Write("0000");
            string svc = service.Substring(4);//git-upload-pack remove git-
            RunProcess(true, project, GetInputStream(), Response.OutputStream, svc);
            return new EmptyResult();
          
        }
        public ActionResult RunCommand(string project,string verb)
        {
            Response.StatusCode = 200;
            Response.ContentType = "application/x-git-upload-pack-result";
            // SetNoCache
            SetNoCache();

            Response.BufferOutput = false;
            Response.Charset = "";
            string sevice = verb.Substring(4);//git-upload-pack remove git-
            RunProcess(false,project, GetInputStream(), Response.OutputStream,sevice);


            return new  EmptyResult();
        }
        private void RunProcess(bool advertiseRefs, string project,Stream inputStream,Stream outputStream,string service)
        {
            var args = service + " --stateless-rpc";
            if (advertiseRefs)
            {
                args += " --advertise-refs";
            }
          
            var projectPath =Path.Combine(Server.MapPath("~/App_Data/"), "GitProjects");
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
                process.StandardInput.Close();
                process.StandardOutput.BaseStream.CopyTo(outputStream);

                process.WaitForExit();
            }
        }
        private void SetNoCache()
        {
            Response.AddHeader("Expires", "Fri, 01 Jan 1980 00:00:00 GMT");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Cache-Control", "no-cache, max-age=0, must-revalidate");
        }

        private Stream GetInputStream()
        {
            if (Request.Headers["Content-Encoding"] == "gzip")
            {
                return new GZipStream(Request.GetBufferlessInputStream(true), CompressionMode.Decompress);
            }
            return Request.GetBufferlessInputStream(true);
        }

        private static string FormatMessage(string input)
        {
            return (input.Length + 4).ToString("X4", CultureInfo.InvariantCulture) + input;
        }

      
    }
}