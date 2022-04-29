using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using GraphQLApi.Entities;
using GraphQLApi.Queries;
using Microsoft.AspNetCore.Mvc;


namespace GraphQLApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        [Route("getcourses")]
        public async Task<string> GetCourses([FromQuery]string query)
        {
            var schema = Schema.For(@"
                    type Query {
                                   courses : [Course!]  
                                   course (id : ID!) : Course
                                                                                                            
                                 }
                    enum PaymentType {
                                        FREE ,
                                        PAID
                                  }
                    type Course {
                                    title: String!
                                    duration: Int
                                    level : String!
                                    instructor: String
                                    paymentType : PaymentType
                                    ratings : [Rating]
                                }
                    type Rating
                                {   
                                    studentName : String
                                    stars : Int
                                    review : String
                                }", builder =>
            {
                builder.Types.Include<Course>();
                builder.Types.Include<Query>();

            });

            var json = await schema.ExecuteAsync(options =>
            {
                options.Query = query;
            });

            return json;

        }
    }
}
