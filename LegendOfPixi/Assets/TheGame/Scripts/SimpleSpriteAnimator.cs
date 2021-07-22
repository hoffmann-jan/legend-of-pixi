using System.Collections;
using UnityEngine;

public class SimpleSpriteAnimator : MonoBehaviour
{
    public bool Loop = true;
    public bool PlayDisabled = false;

    /// <summary>
    /// Frames which are shown.
    /// </summary>
    public Sprite[] Frames = new Sprite[0];

    /// <summary>
    /// Frames which are shown.
    /// </summary>
    public Sprite[] FramesDisabledStyle = new Sprite[0];

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

        do
        {
            if (PlayDisabled)
            {
                for (int i = 0; i < FramesDisabledStyle.Length; i++)
                {
                    renderer.sprite = FramesDisabledStyle[i];
                    yield return new WaitForSeconds(
                        ((Duration / FramesDisabledStyle.Length)
                          * Duration)
                          + 1);
                }
            }
            else
            {
                for (int i = 0; i < Frames.Length; i++)
                {
                    renderer.sprite = Frames[i];
                    yield return new WaitForSeconds(Duration / Frames.Length);
                }
            }
        }
        while (enabled && Loop);

        Destroy(gameObject);
    }
}
