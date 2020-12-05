/// <summary>
/// Collectable gem script.
/// </summary>
public class Gem : Collectible
{
    public override void OnCollect()
    {
        base.OnCollect();

        SaveGameDataSingleton.instance.inventory.gems++;
        Destroy(gameObject);
    }
}
