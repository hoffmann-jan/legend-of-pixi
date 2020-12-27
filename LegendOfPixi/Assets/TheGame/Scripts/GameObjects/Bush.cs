using System.Collections;
using UnityEngine;

public class Bush : MonoBehaviour
{
    /// <summary>
    /// Frame which are shown when the bush is destructing.
    /// </summary>
    public Sprite[] DestructionFrames = new Sprite[0];

    /// <summary>
    /// Length of destruction play time.
    /// </summary>
    public float Duration = 0.5f;

    private bool _isAnimationPlaying = false;

    public void OnHitBySword()
    {
        if (!_isAnimationPlaying)
        {
            StartCoroutine(PlayDestructionAnimation());
        }
    }

    protected IEnumerator PlayDestructionAnimation()
    {
        _isAnimationPlaying = true;

        var spawner = GetComponent<RandomSpawn>();
        if (spawner != null)
        {
            var item = spawner.Spawn();
            if (item != null)
            {
                item.transform.position = transform.position;
            }
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < DestructionFrames.Length; i++)
        {
            renderer.sprite = DestructionFrames[i];
            yield return new WaitForSeconds(Duration / DestructionFrames.Length);
        }

        Destroy(gameObject);
    }

}
