using ServerApp;
using SocketServer;

public class Singleton<T> where T : new()
{
    public static T _instance;

    public static T Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
    public static bool OnInit()
    {
        if (null == _instance)
        {
            _instance = new T();
            return true;
        }
        else
        {
            Debug.LogError("HAD INIT");
            return true;
        }
    }
}