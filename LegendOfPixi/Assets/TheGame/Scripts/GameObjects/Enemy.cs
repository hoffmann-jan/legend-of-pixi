using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnHitBySword()
    {
        Destroy(gameObject);
    }
}
