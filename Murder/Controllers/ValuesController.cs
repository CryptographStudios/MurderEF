using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace Murder.Controllers
{
	public class ValuesController : ApiController
	{
		/// <summary>
		/// Matt learning swagger docs
		/// </summary>
		/// <returns></returns>
		[SwaggerOperation("GetAll")]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		/// <summary>
		/// Matt swagger GetById
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[SwaggerOperation("GetById")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public string Get(int id)
		{
			return "value";
		}

		/// <summary>
		/// Matt Swagger POST
		/// </summary>
		/// <param name="value"></param>
		[SwaggerOperation("Create")]
		[SwaggerResponse(HttpStatusCode.Created)]
		public void Post([FromBody]string value)
		{
		}

		/// <summary>
		///  Matt Swagger PUT
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		[SwaggerOperation("Update")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public void Put(int id, [FromBody]string value)
		{
		}

		/// <summary>
		///  Matt Swagger Delete		
		/// </summary>
		/// <param name="id"></param>
		[SwaggerOperation("Delete")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public void Delete(int id)
		{
		}
	}
}
