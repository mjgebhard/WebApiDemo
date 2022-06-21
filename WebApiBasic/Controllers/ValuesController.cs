using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBasic.Models;

namespace WebApiBasic.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly List<ResponseOrder> model;
        public ValuesController()
        {
            model = new List<ResponseOrder>
            {
                new ResponseOrder()
                {
                    actorname = "Marking",
                    stepname = "2022-06-10-O424",
                    taskname = "EXECUTION_2",
                    parameters = new List<Parameter>
                    {
                      new Parameter {  name = "parameter A", value = 73.1m },
                      new Parameter {  name = "parameter B", value = 12m },
                      new Parameter {  name = "parameter C", value = 173.1m },
                      new Parameter {  name = "parameter D", value = 112m },
                      new Parameter {  name = "parameter E", value = 273.1m },
                      new Parameter {  name = "parameter F", value = 312m },
                    }
                },
                new ResponseOrder()
                {
                    actorname = "Marking",
                    stepname = "2022-06-10-O425",
                    taskname = "EXECUTION_3",
                    parameters = new List<Parameter>
                    {
                      new Parameter {  name = "parameter 1", value = 1.23m },
                      new Parameter {  name = "parameter 2", value = 4.56m },
                      new Parameter {  name = "parameter 3", value = 7.89m },
                      new Parameter {  name = "parameter 4", value = 9.36m },
                      new Parameter {  name = "parameter 5", value = 28.2m },
                      new Parameter {  name = "parameter 6", value = 7.14m },
                    }
                }

            };
        }
        // GET api/values
        [HttpGet]
        public List<ResponseOrder> Get()
        {
            return model;
        }

        // GET api/values/5
        public ResponseOrder Get(string id)
        {
            return model.FirstOrDefault(p => p.stepname == id);
        }

        // POST api/values
        public ResponseOrder Post([FromBody] ResponseOrder value)
        {
            return value;
        }

        // PUT api/values/5
        public ResponseOrder Put(string id, [FromBody] ResponseOrder value)
        {
            return value;
        }

        // DELETE api/values/5
        public string Delete(string id)
        {
            return id;
        }
    }
}
