#nullable disable
using VanriseWinformWithSql.Enums;

namespace VanriseWinformWithSql.Models;

public class Student : ModelBase
{
    public string Name { get; set; }    
    public Gender Gender { get; set; }
}
