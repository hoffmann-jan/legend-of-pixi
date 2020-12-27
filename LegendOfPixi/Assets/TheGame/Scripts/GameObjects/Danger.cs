using UnityEngine;

public class Danger : TouchableBlocker
{
    /// <summary>
    /// Time of last hit.
    /// </summary>
    private float lastHit = 0f;

    public override void OnTouch()
    {
        base.OnTouch();

        if ((Time.time - lastHit) > 1f)
        {
            SaveGameDataSingleton.instance.health.Change(-1);
            lastHit = Time.time;

            var hero = FindObjectOfType<Hero>();
            hero.PushAwayFrom(this);
            hero.Flicker(5);
        }

    }
}
