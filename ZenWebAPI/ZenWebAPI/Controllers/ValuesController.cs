using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZenWebAPI.Authorization;
using ZenWebAPI.Models;
using ZenWebAPI.Utility;

namespace ZenWebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        [AllowAnonymous]
        [Route("signin/jsonbody")]
        [HttpPost]
        public IHttpActionResult jsonbody([FromBody] JObject data)
        {

            string username = data["username"]?.ToString();
            string password = data["password"]?.ToString();

            Dictionary<string, string> payloads = new Dictionary<string, string>();
            payloads["api_key"] = "aezen";
            payloads["api_secret"] = "zensecret";
            payloads["usertype"] = "user";
            payloads["userid"] = "AEZEN";
            payloads["username"] = username;
            payloads["password"] = password;
            payloads["link"] = "../landing/index.html";

            string token = JwtManager.GenerateToken(payloads);
            return Ok(token);
        }

        [AllowAnonymous]
        [Route("signin/bodyparams")]
        [HttpPost]
        public IHttpActionResult bodyparams(string username, string password)
        {
            Dictionary<string, string> payloads = new Dictionary<string, string>();
            payloads["api_key"] = "aezen";
            payloads["api_secret"] = "zensecret";
            payloads["usertype"] = "user";
            payloads["userid"] = "AEZEN";
            payloads["username"] = username;
            payloads["password"] = password;
            payloads["link"] = "../landing/index.html";

            string token = JwtManager.GenerateToken(payloads);
            return Ok(token);
        }

        [AllowAnonymous]
        [Route("signin/bodymodel")]
        [HttpPost]
        public IHttpActionResult bodymodel([FromBody] LoginDTO model)
        {
            Dictionary<string, string> payloads = new Dictionary<string, string>();
            payloads["api_key"] = "aezen";
            payloads["api_secret"] = "zensecret";
            payloads["usertype"] = "user";
            payloads["userid"] = "AEZEN";
            payloads["username"] = model.username;
            payloads["password"] = model.password;
            payloads["SAMPLESTRING"] = "GORDONRAMSAY";
            payloads["link"] = "../landing/index.html";

            string token = JwtManager.GenerateToken(payloads);
            return Ok(token);
        }


        /// <summary>
        /// Retrieves a list of all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        [Authorizations]
        [HttpGet]
        [Route("user/types")]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
