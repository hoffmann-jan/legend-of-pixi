public class Item_Hearth : Collectible
{
    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameDataSingleton.instance.health.Change(+1);
        SaveGameDataSingleton.instance.RecordDestroy(gameObject, true);
    }
}
