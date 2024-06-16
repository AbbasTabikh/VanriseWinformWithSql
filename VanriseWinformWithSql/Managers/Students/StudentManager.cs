using System.Data.SqlClient;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql.Managers.Students;

public class StudentManager
{
    private readonly StudentDataManager _studentDataManager;

    public StudentManager(string connectionString)
    {
        _studentDataManager = new StudentDataManager(connectionString);
    }

    public async Task<List<Student>> GetAll()
    {
        return await _studentDataManager.GetAll();
    }

    public async Task Insert(Student student)
    {
        await _studentDataManager.Insert(student);
    }

    public async Task Update(Student student)
    {
        await _studentDataManager.Update(student);
    }

    public async Task<List<Student>> GetFiltered(string filter)
    {
        return await _studentDataManager.GetFiltered(filter);
    }

    public async Task InsertWithSp(Student student)
    {
        var nameParam = new SqlParameter { ParameterName = "@Name", Value = student.Name };
        var genderParam = new SqlParameter { ParameterName = "@Gender", Value = student.Gender };
    
        await _studentDataManager.InsertWithSp(nameParam, genderParam);
    }

    public async Task UpdatetWithSp(Student student)
    {
        var nameParam = new SqlParameter { ParameterName = "@Name", Value = student.Name };
        var genderParam = new SqlParameter { ParameterName = "@Gender", Value = student.Gender };
        var idParam = new SqlParameter { ParameterName = "@Id", Value = student.Id };

        await _studentDataManager.UpdateWithSp(nameParam, genderParam, idParam);
    }

    public async Task<List<Student>> GetFilteredWithSp(string filterValue)
    {
        var filterParam = new SqlParameter { ParameterName = "@filterValue", Value = filterValue };

        return await _studentDataManager.GetWithSp(filterParam);
    }

    public async Task<List<Student>> GetAllWithSp()
    {
        return await _studentDataManager.GetWithSp(null);
    }


}
