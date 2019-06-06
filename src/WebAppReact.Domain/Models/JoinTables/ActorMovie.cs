namespace WebAppReact.Domain.Models.JoinTables
{
    public class ActorMovie
    {
        public int MovieId { get; private set; }

        public int ActorId { get; private set; }

        public virtual Movie Movie { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
