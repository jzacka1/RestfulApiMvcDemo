using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestfulApi;
using RestfulApi.GitHubService;
using RestfulApi.Models;
using RestSharp.Deserializers;

namespace RestfulApiMvcDemo.Controllers
{
    //https://exceptionnotfound.net/building-the-ultimate-restsharp-client-in-asp-net-and-csharp/
    public class HomeController : Controller
    {
        private readonly IGitHubAPI gitHub;

        public HomeController(GitHubAPI gitHub)
        {
            this.gitHub = gitHub;
        }

        public ActionResult Index()
        {
            List<Repos> repos = this.gitHub.GetRepos();
            return View(repos);
        }

        public ActionResult GitHubProject(string projectName)
        {
            Repos repo = this.gitHub.GetRepoByProjectName(projectName);
            return View(repo);
        }

        public ActionResult GitHubImages(string projectName)
        {
            ViewBag.ProjectName = projectName;
            List<ImagesGitHub> images = this.gitHub.GetRepoImages(projectName);
            return View(images);
        }

    }
}