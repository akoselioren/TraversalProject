namespace TraversalProject.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
