using System.Data;
using System.Data.SqlClient;
using VanriseWinformWithSql.Extensions;
using VanriseWinformWithSql.Models;

namespace VanriseWinformWithSql.Managers;

public abstract class BaseDataManager
{
    protected readonly string _connectionString;

    public BaseDataManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected async Task<int> ExecuteNonQuery(string stroredProcedureName, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var command = new SqlCommand(stroredProcedureName, connection)
        {
            CommandType = CommandType.StoredProcedure
        };

        // this function retrieves the set of parameters required by the stored procedure(bt7otton bl command.Parameters)
        // first index of parameters retreived is the return type of the stored procedure
        SqlCommandBuilder.DeriveParameters(command);

        foreach (var parameter in parameters)
        {
            if (command.Parameters.Contains(parameter.ParameterName))
            {
                command.Parameters[parameter.ParameterName].Value = parameter.Value;
            }

            else
                throw new ArgumentException("Provided parameter doesn't exist");
        }

        var result = await command.ExecuteNonQueryAsync();
        await connection.CloseAsync();
        return result;
    }


    protected async Task<List<T>> GetSpItems<T>(string stroredProcedureName, params SqlParameter[]? parameters) where T : ModelBase, new()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        var command = new SqlCommand(stroredProcedureName, connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        

        // if the are no parameters provided, just call the stored procedures directly ignore hawde
        if(parameters is not null)
        {
            SqlCommandBuilder.DeriveParameters(command);

            foreach (var parameter in parameters)
            {
                if (command.Parameters.Contains(parameter.ParameterName))
                {
                    command.Parameters[parameter.ParameterName].Value = parameter.Value;
                }
            }
        }
       
        using var reader = await command.ExecuteReaderAsync();
        List<T> result = [];
        T? entity;
        while (reader.Read())
        {
            entity = reader.To<T>();
            result.Add(entity);
        }
        return result;
    }
}
