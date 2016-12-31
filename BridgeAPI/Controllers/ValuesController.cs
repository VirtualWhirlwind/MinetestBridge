using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BridgeAPI.Controllers
{
	public class TestObject
	{
		protected List<string> _Values = new List<string>();

		public List<string> Values
		{
			get
			{
				return _Values;
			}
			set
			{
				_Values = value ?? new List<string>();
			}
		}
	}

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
		protected TestObject TestCache { get; set; }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
			CheckCache();

			return Json(TestCache);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
			CheckCache();

			if (id >= 0 && id < TestCache.Values.Count)
			{
				return Json(TestCache.Values[id]);
			}

			return Json(null);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

		#region Methods
		protected void CheckCache()
		{
			if (TestCache == null)
			{
				TestCache = new TestObject();
				TestCache.Values.Add("valueA");
				TestCache.Values.Add("valueB");
				TestCache.Values.Add("valueC");
			}
		}
		#endregion
	}
}
