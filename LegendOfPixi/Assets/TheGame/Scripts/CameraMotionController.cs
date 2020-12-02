using UnityEngine;

/// <summary>
/// Controller wich keep the hero always in screen.
/// </summary>
public class CameraMotionController : MonoBehaviour
{
    public Hero Hero;

    private void Update()
    {
        Vector3 heroPosition = Hero.transform.position;
        heroPosition.z = transform.position.z;
        transform.position = heroPosition;
    }
}
