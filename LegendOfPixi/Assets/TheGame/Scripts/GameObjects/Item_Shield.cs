public class Item_Shield : Collectible
{
    public override void OnCollect()
    {
        base.OnCollect();

        SaveGameDataSingleton.instance.inventory.shield = true;
        Destroy(gameObject);
    }
}
