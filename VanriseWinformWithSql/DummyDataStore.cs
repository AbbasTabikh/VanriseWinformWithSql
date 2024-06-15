using Bogus;
using VanriseWinformWithSql.Enums;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql;

public class DummyDataStore
{
    private static readonly Faker<Student> _faker = new Faker<Student>()
        .RuleFor(x => x.Id, x => x.IndexFaker + 1)
        .RuleFor(x => x.Name, x => x.Person.FirstName + " " + x.Person.LastName)
        .RuleFor(x => x.Gender, x => x.PickRandom<Gender>());

    private List<Student> Students { get; set; }

    public DummyDataStore(int numberOfRecords)
    {
        Students = _faker.Generate(numberOfRecords);
    }

    public List<Student> Get()
    {
        return Students;
    }

    public List<Student> GetFiltered(string filterValue)
    {
        var result = Students
            .Where(x => x.Gender.ToString().Contains(filterValue, StringComparison.InvariantCultureIgnoreCase) ||
            x.Id.ToString().Contains(filterValue) ||
            x.Name.Contains(filterValue, StringComparison.InvariantCultureIgnoreCase));

        return result.ToList();
    }
    public void Add(Student student)
    {
        student.Id = Students.Count + 1;
        Students.Add(student);
    }

    public void Remove(Student student)
    {
        Students.Remove(student);
    }
}
