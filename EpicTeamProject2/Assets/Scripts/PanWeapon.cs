using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanWeapon : MonoBehaviour
{
    public int damage = 15;
    //public AudioClip bellSound;
    //private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Attack(GameObject target)
    {
        if (target.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.TakeDamage(damage);
        }

        //audioSource.PlayOneShot(bellSound);
    }
}
