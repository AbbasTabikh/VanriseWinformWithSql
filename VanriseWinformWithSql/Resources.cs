using System.Configuration;

namespace VanriseWinformWithSql;

public static class Resources
{
    public const string ConnectionString = "Data Source=ABBASS-LEGION\\SQLEXPRESS;Initial Catalog=vanriseDemoStudentdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    //For stored procedures
    public const string AddStudentProcedureName = "AddStudent";
    public const string UpdateStudentProcedureName = "UpdateStudent";
    public const string GetAllStudents = "GetAllStudents";
    public const string GetFilteredStudents = "GetFilteredStudents";
}
