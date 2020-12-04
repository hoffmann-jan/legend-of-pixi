public class SaveGameDataSingleton
{
    public static SaveGameDataSingleton instance = new SaveGameDataSingleton();

    public Inventory inventory = new Inventory();

    public SaveGameDataSingleton()
    {
        inventory = new Inventory();
    }

}
