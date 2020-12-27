using UnityEngine;

/// <summary>
/// Random item spawner.
/// </summary>
public class RandomSpawn : MonoBehaviour
{
    /// <summary>
    /// List of possible objects.
    /// </summary>
    public GameObject[] PossibleObjects = new GameObject[0];

    /// <summary>
    /// Maybe returns null.
    /// </summary>
    /// <returns>Null or <see cref="GameObject"/>.</returns>
    public GameObject Spawn()
    {
        int index = Random.Range(0, PossibleObjects.Length);
        var template = PossibleObjects[index];

        if (template == null)
        {
            return null;
        }
        
        return Instantiate(template);
    }

}
