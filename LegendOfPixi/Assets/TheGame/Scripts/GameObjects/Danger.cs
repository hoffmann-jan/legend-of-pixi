using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Danger : TouchableBlocker
{
    /// <summary>
    /// Time of last hit.
    /// </summary>
    private float lastHit = 0f;

    /// <summary>
    /// If true objects anchor is top-left, otherwise objects anchor is in the middle. 
    /// </summary>
    public bool TopLeftAnchor = false;

    public override void OnTouch()
    {
        base.OnTouch();
        bool shieldProtection = SaveGameDataSingleton.instance.inventory.shield;

        if ((Time.time - lastHit) > 1f)
        {
            int flickerTimes = 5;
            if (shieldProtection)
            {
                flickerTimes = 1;
            }
            else
            {
                SaveGameDataSingleton.instance.health.Change(-1);
            }
            lastHit = Time.time;

            var hero = FindObjectOfType<Hero>();
            hero.PushAwayFrom(this, TopLeftAnchor);
            hero.Flicker(flickerTimes);
        }

    }
}
