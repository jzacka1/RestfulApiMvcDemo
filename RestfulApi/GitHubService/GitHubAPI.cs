using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulApi.GitHubService;
using RestfulApi.Models;
using RestSharp;
using RestSharp.Deserializers;

namespace RestfulApi.GitHubService
{
    public class GitHubAPI : BaseClient, IGitHubAPI
    {
        public string baseURL { get; set; }
        public string widget { get; set; }

        public string userName { get; set; }

        public GitHubAPI(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
            : base(cache, serializer, errorLogger, "https://api.github.com/")
        {
            this.baseURL = baseURL;
            this.userName = "jzacka1";
        }

        public User GetUserByUserName(string userName)
        {
            RestRequest request = new RestRequest("users/" + userName, Method.GET);
            return Get<User>(request);
        }

        public List<Repos> GetRepos()
        {
            string link = String.Format("users/{0}/repos", this.userName);
            RestRequest request = new RestRequest(link, Method.GET);
            //return Get<List<Repos>>(request);
            string cachekey = String.Format("repos-list-{0}", this.userName);
            return GetFromCache<List<Repos>>(request, cachekey);
        }

        public Repos GetRepoByProjectName(string projectName)
        {
            //the url to the path is case sensitive
            string link = String.Format("repos/{0}/{1}/contents", this.userName, projectName);
            RestRequest request = new RestRequest(link, Method.GET);

            //return Get<Repos>(request);
            string cachekey = String.Format("repo-{0}-{1}-Images", this.userName, projectName);
            return GetFromCache<Repos>(request, cachekey);
        }

        public List<ImagesGitHub> GetRepoImages(string projectName)
        {
            //the url to the path is case sensitive
            string link = String.Format("repos/{0}/{1}/contents/images", this.userName, projectName);
            RestRequest request = new RestRequest(link, Method.GET);

            //return Get<Repos>(request);
            string cachekey = String.Format("repo-{0}-{1}-images", this.userName, projectName);
            return GetFromCache<List<ImagesGitHub>>(request, cachekey); ;
        }
    }
}
