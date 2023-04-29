﻿
namespace DAL.Entities;

public class Priority : BaseEntity
{
    public string Name { get; set; }
    public Guid TaskId { get; set; }
    public virtual Goal? Task { get; set; }
}
