public class SavePoint : Collectible
{
    public override void OnCollect()
    {
        base.OnCollect();

        SaveGameDataSingleton.instance.Save();
        gameObject.SetActive(false);
    }
}
