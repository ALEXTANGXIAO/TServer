public class BaseClsTemplate<T>
{
    protected static T m_imp;

    /**
     * 注册处理函数
     */
    public static void RegistImp(T imp)
    {
        m_imp = imp;
    }
}