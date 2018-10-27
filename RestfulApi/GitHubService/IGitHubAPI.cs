using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestfulApi.Models;

namespace RestfulApi.GitHubService
{
    public interface IGitHubAPI
    {
        User GetUserByUserName(string userName);
        List<Repos> GetRepos();
        Repos GetRepoByProjectName(string projectName);
        List<ImagesGitHub> GetRepoImages(string projectName);
    }
}
