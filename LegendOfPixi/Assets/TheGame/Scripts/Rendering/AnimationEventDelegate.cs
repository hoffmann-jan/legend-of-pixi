using UnityEngine;

/// <summary>
/// Forwards events on timeline.
/// </summary>
public class AnimationEventDelegate : MonoBehaviour
{
    /// <summary>
    /// Defines structure of function pointers. 
    /// </summary>
    public delegate void Callback();

    /// <summary>
    /// 'List' of functions with structure of <see cref="Callback"/>, which are called
    /// when on timeline event occurs.
    /// </summary>
    public static event Callback WhenTimelineEventReached;

    public void OnTimelineEvent()
    {
        WhenTimelineEventReached?.Invoke();
    }
}
