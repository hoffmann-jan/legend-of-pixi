using System;
using UnityEngine;

/// <summary>
/// Detects overlaying collider without the
/// physic engine (rigidbody) und calls registered
/// callbacks in case of collision.
/// </summary>
public class CollisionDetector : MonoBehaviour
{
    /// <summary>
    /// <see cref="BoxCollider2D"/> pointer for collision detection.
    /// </summary>
    protected BoxCollider2D _boxCollider;
    /// <summary>
    /// Temporary memory for <see cref="IsColliding"/>.
    /// </summary>
    protected Collider2D[] _colliders;

    protected int _foundCollisions;

    private ContactFilter2D _obstacleFilter2d;

    /// <summary>
    /// Describes the function which should be called on collision.
    /// </summary>
    /// <param name="collider"></param>
    public delegate void Callback(Collider2D collider);

    /// <summary>
    /// Single memory slot of a function (from 'delegate Callback')
    /// which will be called on collision.
    /// </summary>
    public Callback WhenCollisionDetected;

    protected virtual void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _colliders = new Collider2D[10];
        _obstacleFilter2d = new ContactFilter2D();
    }

    protected void Update()
    {
        if (WhenCollisionDetected == null)
        {
            Debug.LogWarning("Collision detector disabled! No Callback found!");
            enabled = false;
        }
        else if (IsColliding())
        {
            for (int i = 0; i < _foundCollisions; i++)
            {
                WhenCollisionDetected(_colliders[i]);
            }
        }
    }

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

}
