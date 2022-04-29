using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;


namespace GraphQLClient
{
    public class GraphQLCourseClient
    {
        public static async Task GetCoursesHttp()
        {
            var graphQLClient = new GraphQLHttpClient(
                "https://localhost:7060/graphql/getcourses", new NewtonsoftJsonSerializer());

            var qString = "{courses{instructor,title,ratings{studentName,review}}}";

            var response = await graphQLClient.HttpClient.GetAsync($"https://localhost:7060/graphql/getcourses?query={qString}");

            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }

        public static async Task GetByIdCoursesHttp(long id)
        {
            var graphQLClient = new GraphQLHttpClient(
                "https://localhost:7060/graphql/getcourses", new NewtonsoftJsonSerializer());

            //var qString = "{courses{instructor,title,ratings{studentName,review}}}";

            var qString = "{course (id : " + id + "){instructor,title,ratings{studentName,review}}}";

            var response = await graphQLClient.HttpClient.GetAsync($"https://localhost:7060/graphql/getcourses?query={qString}");

            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }
    }
}
