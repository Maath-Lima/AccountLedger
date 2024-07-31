namespace Account.Ledger.Api.Models.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract bool EntityValidation();
    }
}
