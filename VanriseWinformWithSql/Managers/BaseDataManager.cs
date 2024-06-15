namespace VanriseWinformWithSql.Managers;

public abstract class BaseDataManager
{
    protected readonly string _connectionString;

    public BaseDataManager(string connectionString)
    {
        _connectionString = connectionString;
    }

}
