public sealed class Allure
{
    public static Allure Instance => GetInstance();
    
    public void Save(SaveData data)
    {

    }

    public PlayerProfile LoadPlayerProfile()
    {
        return new PlayerProfile();
    }

    private Allure()
    {
        _Save = new Save();
    }

    private Save _Save;

    private static Allure _Instance;
    private static Allure GetInstance()
    {
        if(_Instance != null)
        {
            return _Instance;
        }

        _Instance = new Allure();

        return _Instance;
    }
}
