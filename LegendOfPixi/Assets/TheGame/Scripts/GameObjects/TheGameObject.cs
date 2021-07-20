using System.Collections;
using UnityEngine;

public class TheGameObject : MonoBehaviour
{
    /// <summary>
    /// Size of a pixel in unit units.
    /// </summary>
    private const float PixelFraction = 1.0f / 16.0f;
    
    /// <summary>
    /// Objects animator component.
    /// </summary>
    protected Animator _anim;

    /// <summary>
    /// <see cref="BoxCollider2D"/> pointer for collision detection.
    /// </summary>
    protected BoxCollider2D _boxCollider;
    /// <summary>
    /// Temporary memory for <see cref="IsColliding"/>.
    /// </summary>
    protected Collider2D[] _colliders;

    private ContactFilter2D _obstacleFilter2d;

    /// <summary>
    /// Move which should be made in this Frame.
    /// </summary>
    public Vector3 change;

    protected virtual void Awake()
    {
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _colliders = new Collider2D[10];
        _obstacleFilter2d = new ContactFilter2D();
    }

    /// <summary>
    /// Round to a pixel art pixel.
    /// </summary>
    /// <param name="value">Step.</param>
    /// <returns>Exact step in pixel art grid.</returns>
    protected float RoundToPixelGrid(float value)
    {
        return Mathf.Ceil(value / PixelFraction) * PixelFraction;
    }


    /// <summary>
    /// Count of detected collision in last check.
    /// </summary>
    protected int _foundCollisions;

    /// <summary>
    /// Checks, if this objects <see cref="BoxCollider2D"/> has a collision
    /// with other <see cref="Collider2D"/>'s.
    /// </summary>
    /// <returns>True, if colliding; else false.</returns>
    protected bool IsColliding()
    {
        _foundCollisions = _boxCollider.OverlapCollider(_obstacleFilter2d, _colliders);
        return _foundCollisions > 0;
    }

    private void LateUpdate()
    {
        _anim.SetFloat("change_x", change.x);
        _anim.SetFloat("change_y", change.y);

        if (change.x >= 1f)
        {
            _anim.SetFloat("lookAt", 3f);
        }
        else if (change.x <= -1f)
        {
            _anim.SetFloat("lookAt", 1f);
        }
        else if (change.y >= 1f)
        {
            _anim.SetFloat("lookAt", 2f);
        }
        else if (change.y <= -1f)
        {
            _anim.SetFloat("lookAt", 0f);
        }

        float step = RoundToPixelGrid(1f * Time.deltaTime);
        var oldPosition = transform.position;
        transform.position += change * step;

        if (IsColliding())
        {
            transform.position = oldPosition;

            for (int i = 0; i < _foundCollisions; i++)
            {
                var touchableBlocker = _colliders[i].GetComponent<TouchableBlocker>();
                if (touchableBlocker != null)
                {
                    touchableBlocker.OnTouch();
                }
            }
        }

        change = Vector3.zero;
    }

    /// <summary>
    /// Calculates the center of tile in which
    /// the game object is.
    /// Can be used to snap a object to the grid.
    /// </summary>
    /// <returns>Center of tile.</returns>
    public Vector3 GetFullTilePosition()
    {
        var pos = transform.position;
        pos.x = Mathf.FloorToInt(pos.x);
        pos.y = Mathf.CeilToInt(pos.y);

        pos.x += 0.5f;
        pos.y -= 0.5f;

        return pos;
    }

    /// <summary>
    /// Pushes the game object to the deltaX/deltaY
    /// far away tile. 
    /// </summary>
    /// <param name="deltaX">Tile count, to push for horizontal.</param>
    /// <param name="deltaY">Tile count, to push for vertical.</param>
    public void PushByTiles(float deltaX, float deltaY)
    {
        var tilePosition = GetFullTilePosition();

        tilePosition.x += deltaX;
        tilePosition.y += deltaY;

        var oldPosition = GetFullTilePosition();
        transform.position = tilePosition;

        if (IsColliding())
        {
            transform.position = oldPosition;
        }
        else
        {
            StartCoroutine(AnimateMoveTowards(oldPosition, tilePosition));
        }
    }

    /// <summary>
    /// Pushes the hero away from the given object.
    /// </summary>
    /// <param name="deflector"></param>
    public void PushAwayFrom(MonoBehaviour deflector, bool topLeftAnchor)
    {
        Vector3 diff;
        if (topLeftAnchor)
        {
            diff = transform.position - (deflector.transform.position + new Vector3(0.5f, -0.5f, 0f));
        }
        else
        {
            diff = transform.position - deflector.transform.position;
        }

        PushByTiles(diff.x, diff.y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="from"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    private IEnumerator AnimateMoveTowards(Vector3 from, Vector3 target)
    {
        float duration = 0.1f;

        for (float t = 0f; t < 1f; t += Time.deltaTime/duration)
        {
            transform.position = Vector3.Lerp(from, target, t);
            yield return new WaitForEndOfFrame();
        }

    }

    /// <summary>
    /// Let figure blink.
    /// </summary>
    /// <param name="times">How often.</param>
    public void Flicker(int times)
    {
        StartCoroutine(AnimateFlicker(times));
    }

    /// <summary>
    /// Animates flicker.
    /// </summary>
    /// <param name="times">Repetitions.</param>
    /// <returns><see cref="IEnumerator"/></returns>
    private IEnumerator AnimateFlicker(int times)
    {
        var renderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < times; i++)
        {
            renderer.color = Color.red;
            yield return new WaitForSecondsRealtime(0.05f);
            renderer.color = Color.white;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

}
