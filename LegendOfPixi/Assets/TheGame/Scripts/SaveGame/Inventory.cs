/// <summary>
/// Storage for collectable saveable items.
/// </summary>
[System.Serializable]
public class Inventory
{
    /// <summary>
    /// Count of collected gems.
    /// </summary>
    public int gems = 0;
    /// <summary>
    /// Has shield.
    /// </summary>
    public bool shield = false;
    /// <summary>
    /// Hero has sword.
    /// </summary>
    public bool sword = false;
}
