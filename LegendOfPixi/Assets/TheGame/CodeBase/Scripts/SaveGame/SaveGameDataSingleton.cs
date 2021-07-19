public class SaveGameDataSingleton
{
    public static SaveGameDataSingleton instance = new SaveGameDataSingleton();

    public Inventory inventory = new Inventory();

    public Health health = new Health();

    public SaveGameDataSingleton()
    {
        inventory = new Inventory();
    }

}
