using System;
using UnityEngine;

/// <summary>
/// Sword Weapon Controller.
/// </summary>
public class Sword : MonoBehaviour
{
    /// <summary>
    /// Sword animator pointer to handle sword rendering.
    /// </summary>
    public Animator Anim;

    /// <summary>
    /// Pointer to  animator of the figure, to get look direction.
    /// The animator have to save his look direction an parameter "lookAt".
    /// </summary>
    public Animator CharacterAnimator;
    
    /// <summary>
    /// Unity Message.
    /// </summary>
    protected void Awake()
    {
        SetVisible(false);
    }

    public void OnEnable()
    {
        AnimationEventDelegate.WhenTimelineEventReached += OnTimelineEvent;
    }

    public void OnDisable()
    {
        AnimationEventDelegate.WhenTimelineEventReached -= OnTimelineEvent;
    }

    /// <summary>
    /// Controls visibility of the sword due set active of the sword renderer object.
    /// (= the object which holds the Anim-Animator)
    /// </summary>
    /// <param name="visible">New visibility of the sword.</param>
    private void SetVisible(bool visible)
    {
        Anim.gameObject.SetActive(visible);
    }

    /// <summary>
    /// Processes a sword stroke.
    /// </summary>
    public void Stroke()
    {
        int lookAt = Mathf.RoundToInt(CharacterAnimator.GetFloat("lookAt"));

        if (lookAt == 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (lookAt == 1)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (lookAt == 2)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (lookAt == 3)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
        }

        SetVisible(true);
        Anim.SetTrigger("OnStroke");
    }

    public void OnTimelineEvent()
    {
        SetVisible(false);
    }
}
