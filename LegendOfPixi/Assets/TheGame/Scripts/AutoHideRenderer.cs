using UnityEngine;

/// <summary>
/// Deactivates the renderer for the gameobject at start.
/// </summary>
public class AutoHideRenderer : MonoBehaviour
{
    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
}
