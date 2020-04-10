using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;

namespace JayJanuar.Repo.Repository
{
    public class RestRepository<T> :IRepository<T>
    {
        private string url = "http://agl-developer-test.azurewebsites.net";
        private HttpClient client = new HttpClient();
        public RestRepository()
        {
           
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            client.BaseAddress = new Uri(this.url);
            var result = client.GetAsync("/people.json").Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
            IQueryable<T> resultList = JsonConvert.DeserializeObject<List<T>>(resultContent).AsQueryable();
            return resultList;
        }




    }
}
