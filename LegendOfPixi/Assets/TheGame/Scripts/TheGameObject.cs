using UnityEngine;

public class TheGameObject : MonoBehaviour
{
    /// <summary>
    /// Size of a pixel in unit units.
    /// </summary>
    private const float PixelFraction = 1.0f / 16.0f;

    /// <summary>
    /// <see cref="BoxCollider2D"/> pointer for collision detection.
    /// </summary>
    private BoxCollider2D _boxCollider;
    /// <summary>
    /// Temporary memory for <see cref="IsColliding"/>.
    /// </summary>
    private Collider2D[] _colliders;

    private Animator _anim;

    /// <summary>
    /// Move which should be made in this Frame.
    /// </summary>
    public Vector3 change;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _colliders = new Collider2D[10];
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
    /// Checks, if this objects <see cref="BoxCollider2D"/> has a collision
    /// with other <see cref="Collider2D"/>'s.
    /// </summary>
    /// <returns>True, if colliding; else false.</returns>
    protected bool IsColliding()
    {
        _boxCollider.OverlapCollider(new ContactFilter2D(), _colliders);
        return _boxCollider.OverlapCollider(new ContactFilter2D(), _colliders) > 0;
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
        }

        change = Vector3.zero;
    }
}
