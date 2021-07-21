using UnityEngine;

/// <summary>
/// Healt of the hero.
/// </summary>
[System.Serializable]
public class Health
{
    /// <summary>
    /// Actual health value. If it sink to zero then the hero will die.
    /// </summary>
    public int Current = 5;

    /// <summary>
    /// Upper limit.
    /// </summary>
    public int Max = 5;

    /// <summary>
    /// Adds health point in given limits.
    /// </summary>
    /// <param name="delta">Diff.</param>
    public void Change(int delta)
    {
        Current = Mathf.Clamp(Current + delta, 0, Max);
    }

}
