namespace GraphQLApi.Entities
{


    public class Course
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public int Duration { get; set; }
        public String Level { get; set; }
        public PaymentType PaymentType { get; set; }
        public String Instructor { get; set; }

        // public List<Section> Sections { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
