/// <summary>
/// Collectable gem script.
/// </summary>
public class Gem : Collectible
{
    public bool RecordDestroy = false;

    public override void OnCollect()
    {
        base.OnCollect();

        SaveGameDataSingleton.instance.inventory.gems++;
        SaveGameDataSingleton.instance.RecordDestroy(gameObject, RecordDestroy);
    }
}
