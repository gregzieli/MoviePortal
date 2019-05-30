namespace WebAppReact.Domain.Models.JoinTables
{
    public class ActorMovie
    {
        public int MovieId { get; private set; }

        public int ActorId { get; private set; }

        public Movie Movie { get; set; }

        public Actor Actor { get; set; }
    }
}
