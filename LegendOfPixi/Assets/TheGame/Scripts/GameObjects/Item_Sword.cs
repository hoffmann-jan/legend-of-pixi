public class Item_Sword : Collectible
{
    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameDataSingleton.instance.inventory.sword = true;
        Destroy(gameObject);
    }
}
