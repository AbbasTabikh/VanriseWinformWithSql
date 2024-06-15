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
}
