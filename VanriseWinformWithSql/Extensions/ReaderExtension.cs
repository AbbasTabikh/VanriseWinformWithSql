using System.Data.SqlClient;
using VanriseWinformWithSql.Enums;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql.Extensions;

public static class ReaderExtension
{
    public static Student ToStudent(this SqlDataReader reader)
    {
        return new Student
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Gender = (Gender) reader.GetInt32(2)
        };
    }
}
