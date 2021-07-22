public class Item_Shield : Collectible
{
    public void Start()
    {
        if (SaveGameDataSingleton.instance.inventory.shield)
        {
            Destroy(gameObject);
        }
    }

    public override void OnCollect()
    {
        base.OnCollect();

        SaveGameDataSingleton.instance.inventory.shield = true;
        SaveGameDataSingleton.instance.RecordDestroy(gameObject, true);
    }
}
