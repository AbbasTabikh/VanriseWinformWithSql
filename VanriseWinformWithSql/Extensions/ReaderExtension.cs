#nullable disable
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

    public static T To<T>(this SqlDataReader reader) where T : ModelBase
    {
        if(typeof(T) == typeof(Student))
        {
            //T and Student are subclasses of type Modelbase,  and the return type is T which is a different class from Student, that's why i have to do this casting
            // ya3ne ( return something as <The_Type_That_You_Provided> which is T
            //ex : reader.ToAyyaShi() as T ( and T is provided by the caller )
            return reader.ToStudent() as T;
        }

        throw new TypeAccessException();
    }
}
