using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collectible : MonoBehaviour
{
    protected virtual void Awake()
    {
        if (!GetComponent<BoxCollider2D>().isTrigger)
        {
            Debug.LogError($"BoxCollider of {gameObject.name} is not a trigger!");
        }
    }

    public virtual void OnCollect()
    {

    }
}
