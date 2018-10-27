

# RestSharp Client Demo

This is a RestSharp Client Demo that uses Rest API.  You are welcome to add more services into the project, like Facebook, YouTube, or Twitter.  This code is based from the code in the following article below:

[https://exceptionnotfound.net/building-the-ultimate-restsharp-client-in-asp-net-and-csharp/](https://exceptionnotfound.net/building-the-ultimate-restsharp-client-in-asp-net-and-csharp/)

Credit goes Matthew Jones for writing the useful code and great article, and I highly recommend checking it out.

## Getting Started

Downloading the solution containing two projects:

- RestfulAPI (Class project)
- RestfulApiMvcDemo (MVC Project)

The projects will run in Visual Studio 2017.  Set the &#39;RestfulApiMvcDemo&#39; project as a startup project by doing the following

1. Right-click on &#39;RestfulAPIMvcDemo&#39; project.
2. Click on &#39;Set as Startup Project&#39;.

### Prerequisities

In order to run this application, you&#39;ll need the following installed into your projects:

#### RestfulApiMvcDemo (ASP.NET MVC)

Install the following references into the MVC project using Nuget Package Manager:

1. RestfulAPI
2. Unity.Mvc5

#### RestfulApi (Class Project)

Install the following references using Nuget Package Manager:

1. Newtonsoft.Json
2. RestSharp
3. System.Runtime.Caching

## Built With

- [Visual Studio Community  2017](http://www.dropwizard.io/1.0.2/docs/) – Integrated Development Environment (IDE).
- [ASP.NET](http://www.dropwizard.io/1.0.2/docs/) – Open-source server-side web application framework.
- [MVC](https://maven.apache.org/) – Web Application Framework
- [C#](https://rometools.github.io/rome/) - Programming language

## How to Add New Services

To add a new service that reads from a different API source, Go to the &#39;RestfulApi&#39; project, make a new folder, and put in a new class that can derive from the &#39;BaseClient&#39; class and its own interface.  Plus, you can add the appropriate api link as the base url, like &quot;https://api.github.com/&quot;.  Look at the bottom below as an example:

publicclassNewClassAPI : BaseClient, INewClassAPI

    {

        public GitHubAPI(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)

            : base(cache, serializer, errorLogger, "https://api.demo.com")

        {

            this.baseURL = baseURL;

        }

    }

After that, go to the "RestfulApiMvcDemo" project, go into the "App\_Start" folder, and open the UnityConfig.cs file, and register the new interface and new class like the following below:

            container.RegisterType<INewClassAPI, NewClassAPI>();

To have an instance of that new object, type in the class in the constructor method of any controller class you want, like the code below:

        private readonly IGitHubAPI gitHub;

        public HomeController(GitHubAPI gitHub)

        {

            this.gitHub = gitHub;

        }

### If you don't have a UnityConfig.cs file in your MVC project:

1. Right-click on "RestfulApiMvcDemo";
2. Click on "Manage Nuget Packages", and it will open Nuget Package Manager.
3. Type in the following line in the search bar:
  1. Unity.Mvc5
4. Click on the "Unity.Mvc5" package.
5. Click on install, and click "Accept".

After that, you should see a file called, "UnityConfig.cs" file in your "App\_Start" folder.  In order for the type-mapping to be registered, the method, "RegisterComponents" must run when the application runs.  Here are the steps:

1. Open the "Global.asax.cs" file
2. Add the following line into the method, "Application Start":

UnityConfig.RegisterComponents();

The type-mappings can now be registered.

## Release History

- v1.0.0
  - Initial Release
- v1.1.1
  - Added page to display images, and modified code to make it less coupled.

## Author(s)

- **James Zacka** – _Entire solution_ – RestfulApiMvcDemoLicense

**(MIT License)**

Copyright © 2018 James Zacka

Permission is hereby granted, free of charge, to any person obtaining a copy

of this software and associated documentation files (the &quot;Software&quot;), to deal

in the Software without restriction, including without limitation the rights

to use, copy, modify, merge, publish, distribute, sublicense, and/or sell

copies of the Software, and to permit persons to whom the Software is

furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR

IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,

FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE

AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER

LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,

OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE

SOFTWARE.

## Acknowledgments

- The RestSharp client was developed by Matthew Jones.
- He wrote an article on how to write a set of classes for consuming RESTful APIs:
  - https://exceptionnotfound.net/building-the-ultimate-restsharp-client-in-asp-net-and-csharp/
- His contribution inspired me to write a demo on consuming RESTful APIs in ASP.NET MVC.

