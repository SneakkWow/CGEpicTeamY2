using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWeapon : MonoBehaviour
{
    public float explosionDelay = 3.0f;
    public float explosionRadius = 5.0f;
    public LayerMask enemyLayer;
    public GameObject explosionEffect;

    void Throw()
    {
        Invoke(nameof(Explode), explosionDelay);
    }

    void Explode()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);
        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent(out EnemyHealth target))
            {
                target.TakeDamage(target.health);
            }
        }

        Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
