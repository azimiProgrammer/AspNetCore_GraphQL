using GraphQLClient;

await GraphQLCourseClient.GetCoursesHttp();

Console.WriteLine("--------------------------- id = 1 --------------------------------");

await GraphQLCourseClient.GetByIdCoursesHttp(1);

Console.ReadLine();