namespace Owl.Overdrive.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public long CreatedById { get; set; }
        public long LastUpdatedById { get; set; }

        // Reference to User Table
        public User? CreatedBy { get; set; }
        public User? LastUpdatedBy { get; set; }


        public void SetCreateBy(long userId)
        {
            CreatedById = userId;
            LastUpdatedById = userId;
            Created = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }

        public void SetlastUpdatedBy(long userId)
        {
            LastUpdatedById = userId;
            LastUpdated = DateTime.UtcNow;
        }
    }
}
