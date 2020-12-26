using System;
using UnityEngine;
using UnityEngine.Animations;

namespace TheGame.Scripts.Rendering
{
    /// <summary>
    /// Container for a set of sprites.
    /// </summary>
    [Serializable]
    public class SpriteSet
    {
        /// <summary>
        /// Not mirrored.
        /// </summary>
        public Sprite Down;
        /// <summary>
        /// Not mirrored.
        /// </summary>
        public Sprite Left;
        /// <summary>
        /// Not mirrored.
        /// </summary>
        public Sprite Up;
        /// <summary>
        /// Mirrored.
        /// </summary>
        public Sprite Right;

        /// <summary>
        /// Sets the sprite according to the look at direction.
        /// </summary>
        /// <param name="renderer">Sprite renderer.</param>
        /// <param name="lookAt">Value of viewing direction (0=down;1=left;2=up;3=right).</param>
        public void Apply(SpriteRenderer renderer, int lookAt)
        {
            renderer.flipX = false;

            if (lookAt == 0)
            {
                renderer.sprite = Down;
            }
            else if (lookAt == 1)
            {
                renderer.sprite = Left;
            }
            else if (lookAt == 2)
            {
                renderer.sprite = Up;
            }
            else if (lookAt == 3)
            {
                renderer.sprite = Right;
                renderer.flipX = true;
            }
        }
    }


}