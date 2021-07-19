public class Item_Hearth : Collectible
{
    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameDataSingleton.instance.health.Change(+1);
        Destroy(gameObject);
    }
}
