using System.Data.SqlClient;
using VanriseWinformWithSql.Extensions;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql.Managers.Students;

public class StudentDataManager : BaseDataManager
{
    public StudentDataManager(string connectionString) : base(connectionString)
    {
    }

    public async Task<List<Student>> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var command = new SqlCommand("SELECT Id, Name, Gender From students", connection);
        List<Student> students = [];
        Student? student = null;

        using var reader = await command.ExecuteReaderAsync();
        while (reader.Read())
        {
            student = reader.ToStudent();
            students.Add(student);
        }
        await connection.CloseAsync();
        return students;
    }

    public async Task Insert(Student student)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var command = new SqlCommand("INSERT INTO Students (Name, Gender) VALUES (@Name, @Gender)", connection);
        command.Parameters.AddWithValue("@Name", student.Name);
        command.Parameters.AddWithValue("@Gender", student.Gender);
        await command.ExecuteNonQueryAsync();
    }

    public async Task Update(Student student)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var command = new SqlCommand("Update students SET Name = @Name, Gender = @Gender WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", student.Id);
        command.Parameters.AddWithValue("@Name", student.Name);
        command.Parameters.AddWithValue("@Gender", student.Gender);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<Student>> GetFiltered(string filter)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var command = new SqlCommand("SELECT Id, Name, Gender FROM students WHERE CAST(Id AS NVARCHAR) LIKE @filter OR Name LIKE @filter OR " +
            "CASE WHEN Gender = 0 THEN 'Male' WHEN Gender = 1 THEN 'Female' END LIKE @filter", connection);
        command.Parameters.AddWithValue("@filter", '%' +  filter + '%');
        
        using var reader = await command.ExecuteReaderAsync();
        List<Student> students = [];
        Student? student;
        while (reader.Read())
        {
            student = reader.ToStudent();
            students.Add(student);
        }
        await connection.CloseAsync();
        return students;
    }

    public async Task<int> InsertWithSp(params SqlParameter[] sqlParameters)
    {
        return await ExecuteNonQuery(Resources.AddStudentProcedureName, sqlParameters);
    }

    public async Task<int> UpdateWithSp(params SqlParameter[] sqlParameters)
    {
        return await ExecuteNonQuery(Resources.UpdateStudentProcedureName, sqlParameters);
    }

    public async Task<List<Student>> GetWithSp(params SqlParameter[]? sqlParameters)
    {
        if (sqlParameters is null)
        {
            return await GetSpItems<Student>(Resources.GetAllStudents, null);
        }
        return await GetSpItems<Student>(Resources.GetFilteredStudents, sqlParameters!);
    }
}
