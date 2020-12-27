using UnityEngine;

/// <summary>
/// Healt of the hero.
/// </summary>
public class Health
{
    private int _current = 5;

    /// <summary>
    /// Actual health value. If it sink to zero then the hero will die.
    /// </summary>
    public int Current => _current;

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
        _current = Mathf.Clamp(Current + delta, 0, Max);
    }

}
