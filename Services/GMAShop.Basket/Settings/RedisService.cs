using StackExchange.Redis;

namespace GMAShop.Basket.Settings;

public class RedisService
{
    private readonly string _host;
    private readonly int _port;
    private ConnectionMultiplexer _connection;

    public RedisService(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public void Connect()
    {
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints = { $"{_host}:{_port}" },
            AbortOnConnectFail = false
        };

        _connection = ConnectionMultiplexer.Connect(configurationOptions);
    }

    public IDatabase GetDb(int db = 1) => _connection.GetDatabase(0);
}