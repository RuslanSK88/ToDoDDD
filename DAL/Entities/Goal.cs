
namespace DAL.Entities;

public class Goal : BaseEntity
{
    public string Name { get; set; } = null!;
    public Guid StatusId { get; set; }
    public virtual Status? Status { get; set; }
    public Guid PriorityId { get; set; }
    public virtual Priority? Priority { get; set; }
}
