using System.Collections;
using UnityEngine;

public class SimpleSpriteAnimator : MonoBehaviour
{
    /// <summary>
    /// Frames which are shown.
    /// </summary>
    public Sprite[] Frames = new Sprite[0];

    /// <summary>
    /// Length of destruction play time.
    /// </summary>
    public float Duration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    protected IEnumerator PlayAnimation()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (enabled)
        {
            for (int i = 0; i < Frames.Length; i++)
            {
                renderer.sprite = Frames[i];
                yield return new WaitForSeconds(Duration / Frames.Length);
            }
        }
    }
}
