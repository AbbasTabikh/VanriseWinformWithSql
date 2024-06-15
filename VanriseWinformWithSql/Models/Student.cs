#nullable disable
using VanriseWinformWithSql.Enums;

namespace VanriseWinformWithSql.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public Gender Gender { get; set; }
}
