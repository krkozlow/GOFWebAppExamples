using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbAbstractFactory;
using DbCommandFactory;
using DbConnectionFactory;
using Microsoft.AspNetCore.Mvc;
using QueryBuilder;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IQueryBuilder _queryBuilder;
        private IDbConnectionFactory _connectionFactory;
        private IDbCommandFactory _commandFactory;

        public ValuesController(IQueryBuilder queryBuilder,
                                IDbConnectionFactory connectionFactory,
                                IDbCommandFactory commandFactory)
        {
            _queryBuilder = queryBuilder;
            _connectionFactory = connectionFactory;
            _commandFactory = commandFactory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = new List<Object>();
            var connection = DbAbstractFactory.DbAbstractFactory.ConnectionFactory(_connectionFactory).Create("connectionString");
            var query = _queryBuilder
                        .Table("User")
                        .Columns(new string[] { "Name", "LastName" })
                        .Top(10)
                        .OrderBy("Name")
                        .Distinct()
                        .Descending();

            var command = DbAbstractFactory.DbAbstractFactory.CommandFactory(_commandFactory).CreateSelectCommand(connection, query);
            var reader = command.ExecuteReader();
            var rowIndex = 0;
            while (reader.NextResult())
            {
                var row = (IDataRecord)reader;
                result.Add(row[rowIndex]);
                rowIndex++;
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
