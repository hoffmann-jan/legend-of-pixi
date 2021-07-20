using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject ExplosionPrototype;

    public void OnHitBySword()
    {
        // RandomSpawn insert

        GameObject explosion = Instantiate(ExplosionPrototype, transform.parent);
        explosion.transform.position = transform.position;

        Destroy(gameObject);
    }
}
