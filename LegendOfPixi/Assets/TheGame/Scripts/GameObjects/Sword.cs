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

    public CollisionDetector CollisionDetector;

    /// <summary>
    /// Unity Message.
    /// </summary>
    protected void Awake()
    {
        SetVisible(false);
        CollisionDetector.WhenCollisionDetected = OnCollisionDetected;
    }

    public void OnEnable()
    {
        AnimationEventDelegate.WhenTimelineEventReached += OnTimelineEvent;
    }

    public void OnDisable()
    {
        AnimationEventDelegate.WhenTimelineEventReached -= OnTimelineEvent;
    }

    private void OnCollisionDetected(Collider2D collider)
    {
        Debug.Log("Sword has hit" + collider);

        Bush bush = collider.GetComponent<Bush>();
        if (bush != null)
        {
            bush.OnHitBySword();
        }
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

        float scaleX = 1f;
        float rotateZ = 0f;

        if (lookAt == 0)
        {
            rotateZ = 90f;
        }
        else if (lookAt == 1)
        {

        }
        else if (lookAt == 2)
        {
            rotateZ  = -90f;
        }
        else if (lookAt == 3)
        {
            scaleX = -1f;
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, rotateZ);
        transform.localScale = new Vector3(scaleX, 1f, 1f);

        SetVisible(true);
        Anim.SetTrigger("OnStroke");
    }

    public void OnTimelineEvent()
    {
        SetVisible(false);
    }
}
