namespace GraphQLApi.Entities
{
    public abstract class Lecture
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public int SeqNo { get; set; }
        public String Name { get; set; }

    }
}
