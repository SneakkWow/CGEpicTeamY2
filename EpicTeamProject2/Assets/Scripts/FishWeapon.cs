using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWeapon : MonoBehaviour
{
    public int damage = 10;
    //public AudioClip floppingSound;
    //private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Attack(GameObject target)
    {
        // Deal damage
        if (target.TryGetComponent(out EnemyHealth enemy))
         {
            enemy.TakeDamage(damage);
            Debug.Log("Attacked enemy with fish");
         }
        else
        {
            Debug.LogWarning("Attack Faied");
        }
        // Play flopping sound
        //audioSource.PlayOneShot(floppingSound);
    }

}
