﻿using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities;

public class Course: Entity, IAggregateRoot
{
    public Course(int departmentId, string name)
    {
        DepartmentId = departmentId;
        Name = name;
    }

    public int DepartmentId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    public Department Department { get; private set; }
}
