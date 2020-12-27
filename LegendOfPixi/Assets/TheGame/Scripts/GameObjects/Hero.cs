using TheGame.Scripts.Rendering;
using UnityEngine;

public class Hero : TheGameObject
{
    public RuntimeAnimatorController BasicSkin;
    public RuntimeAnimatorController ShieldSkin;

    /// <summary>
    /// Visualization of stroke animation without shield.
    /// </summary>
    public SpriteSet EmptyActionSkin;
    /// <summary>
    /// Visualization of stroke animation with shield.
    /// </summary>
    public SpriteSet ShieldActionSkin;

    private ContactFilter2D _triggerContactFilter2D;

    protected override void Awake()
    {
        base.Awake();

        _triggerContactFilter2D = new ContactFilter2D();
        _triggerContactFilter2D.useTriggers = true;
    }

    private void Update()
    {
        var found = _boxCollider.OverlapCollider(_triggerContactFilter2D, _colliders);
        for (int i = 0; i < found; i++)
        {
            var foundCollider = _colliders[i];
            if (foundCollider.isTrigger)
            {
                foreach (Collectible collectible in foundCollider.GetComponents<Collectible>())
                {
                    collectible.OnCollect();
                }
            }
        }

        if (SaveGameDataSingleton.instance.inventory.shield)
        {
            _anim.runtimeAnimatorController = ShieldSkin;
        }
        else
        {
            _anim.runtimeAnimatorController = BasicSkin;
        }
    }

    /// <summary>
    /// Reaction on action key.
    /// </summary>
    public void PerformAction()
    {
        if (!SaveGameDataSingleton.instance.inventory.sword)
        {
            return;
        }

        _anim.enabled = false;
        var renderer = GetComponent<SpriteRenderer>();

        AnimationEventDelegate.WhenTimelineEventReached += ResetSkin;

        if (SaveGameDataSingleton.instance.inventory.shield)
        {
            ShieldActionSkin.Apply(renderer, Mathf.RoundToInt(_anim.GetFloat("lookAt")));
        }
        else
        {
            EmptyActionSkin.Apply(renderer, Mathf.RoundToInt(_anim.GetFloat("lookAt")));
        }


        Sword sword = GetComponentInChildren<Sword>();
        sword.Stroke();
    }

    private void ResetSkin()
    {
        _anim.enabled = true;
        AnimationEventDelegate.WhenTimelineEventReached -= ResetSkin;
    }
}
