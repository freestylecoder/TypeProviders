using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers {
	public class ValuesController : ApiController {
		private JObject CreateData( string Key1, string Key2, int? Key3 ) {
			JObject obj = new JObject();
			obj["Key1"] = Key1;
			obj["Key2"] = Key2;
			obj["Key3"] = Key3;
			return obj;
		}

		// GET: api/values
		[HttpGet]
		public JArray Get() {
			JArray output = new JArray();
			output.Add( CreateData( "Key One", "Key Two", 3 ) );
			output.Add( CreateData( "Key Four", "Key Five", 6 ) );
			output.Add( CreateData( "Key Seven", "Key Eight", 9 ) );
			output.Add( CreateData( "Key Ten", null, null ) );
			return output;
		}

		// GET api/values/5
		public string Get( int id ) {
			return "value";
		}

		// POST api/values
		public void Post( [FromBody]string value ) {
		}

		// PUT api/values/5
		public void Put( int id, [FromBody]string value ) {
		}

		// DELETE api/values/5
		public void Delete( int id ) {
		}
	}
}
