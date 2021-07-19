using UnityEngine;

/// <summary>
/// Computes user inputs which should control the a hero
/// and provides to a hero script.
/// </summary>
public class HeroInputController : MonoBehaviour
{
    /// <summary>
    /// Pointer to the hero script which should be controlled.
    /// </summary>
    public Hero hero;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            hero.change.x = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            hero.change.x = -1;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            hero.change.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            hero.change.y = -1;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            hero.PerformAction();
        }
    }
}
