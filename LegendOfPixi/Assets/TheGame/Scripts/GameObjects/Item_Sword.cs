public class Item_Sword : Collectible
{
    public void Start()
    {
        if (SaveGameDataSingleton.instance.inventory.sword)
        {
            Destroy(gameObject);
        }
    }

    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameDataSingleton.instance.inventory.sword = true;
        SaveGameDataSingleton.instance.RecordDestroy(gameObject, true);
    }
}
