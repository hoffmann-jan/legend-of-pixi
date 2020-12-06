using UnityEngine;

public class Hero : TheGameObject
{
    public RuntimeAnimatorController BasicSkin;
    public RuntimeAnimatorController ShieldSkin;

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
}
