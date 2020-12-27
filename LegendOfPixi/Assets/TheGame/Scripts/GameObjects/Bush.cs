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

    public void OnHitBySword()
    {
        StartCoroutine(PlayDestructionAnimation());
    }

    protected IEnumerator PlayDestructionAnimation()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < DestructionFrames.Length; i++)
        {
            renderer.sprite = DestructionFrames[i];
            yield return new WaitForSeconds(Duration / DestructionFrames.Length);
        }

        Destroy(gameObject);
    }

}
