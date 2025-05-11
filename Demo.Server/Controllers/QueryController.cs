using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Server.Data;
using SqlToTableData.Sqlite;

namespace Demo.Server.Controllers
{
    /// <summary>
    /// Controller for executing SQL queries against the SQLite database using SqlToTableData package.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SampleDbContext _context;
        private readonly DataProducer _dataProducer;

        public QueryController(SampleDbContext context, IConfiguration config   )
        {
            _context = context;
            _config = config;

            _dataProducer = new DataProducer(_config.GetConnectionString("SQLite"));
        }

        /// <summary>
        /// Execute a SQL query and return the result as a table (2D array).
        /// </summary>
        /// <param name="id">Query ID from queries table</param>
        /// <param name="parameters">Optional parameters to replace in the query string</param>
        /// <returns>2D array of data, first row is always an array of strings containing column names</returns>
        // GET: api/Query/1
        [HttpGet("{id}")]
        public async Task<IResult> GetTable(long id, [FromQuery] string? parameters)
        {
            string query = await _context.Queries.Where(q => q.Id == id).Select(q => q.Sql).FirstAsync();

            if (parameters != null)
            {
                // As this is just an example, these are not real parameterized queries and we are not doing any validation or sanitization of the parameters 
                var splitParams = parameters.Split(',');
                for (int i = 0; i < splitParams.Length; i++)
                {
                    string fromReplace = "{" + i + "}";
                    string toReplace = splitParams[i];

                    query = query.Replace(fromReplace, toReplace);
                }
            }

            // Execute the query and get the result as a table (2D array)
            var result = _dataProducer.GetTable(query);

            return Results.Ok(result);
        }

        /// <summary>
        /// Execute a SQL query and return the result as an JSON string
        /// </summary>
        /// <param name="id">Query ID from queries table</param>
        /// <param name="parameters">Optional parameters to replace in the query string</param>
        /// <returns>JSON string representing 2D array of data</returns>
        // GET: api/Query/json/1
        [HttpGet("json/{id}")]
        public async Task<IActionResult> GetJson(long id, [FromQuery] string? parameters)
        {
            string query = await _context.Queries.Where(q => q.Id == id).Select(q => q.Sql).FirstAsync();

            if (parameters != null)
            {
                // As this is just an example, these are not real parameterized queries and we are not doing any validation or sanitization of the parameters 
                var splitParams = parameters.Split(',');
                for (int i = 0; i < splitParams.Length; i++)
                {
                    string fromReplace = "{" + i + "}";
                    string toReplace = splitParams[i];

                    query = query.Replace(fromReplace, toReplace);
                }
            }

            var result = _dataProducer.GetJson(query);

            return Content(content: result, contentType: "application/json");
        }

    }
}
