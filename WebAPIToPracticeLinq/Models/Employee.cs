using System;
using System.Collections.Generic;

namespace WebAPIToPracticeLinq.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Empname { get; set; }

    public string? Empcode { get; set; }

    public string? EmailAddress { get; set; }

    public string? MobileNumber { get; set; }

    public int? DesignationId { get; set; }

    public double? Salary { get; set; }

    public virtual Designation? Designation { get; set; }
}
