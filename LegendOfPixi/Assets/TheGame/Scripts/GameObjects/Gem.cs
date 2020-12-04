using UnityEngine;

/// <summary>
/// Collectable gem script.
/// </summary>
public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Gem collected!");
        SaveGameDataSingleton.instance.inventory.gems++;
        Destroy(gameObject);
    }
}
