using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWeapon : MonoBehaviour
{
    public int damage = 10;
    public AudioClip floppingSound;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        // Deal damage
        if (other.CompareTag("Enemy"))
         {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                audioSource.PlayOneShot(floppingSound);
                Debug.Log("Attacked enemy with fish");
            }
            else
            {
                Debug.LogWarning("EnemyHealth component not found on Enemy");
           }
         }
        else
        {
            Debug.LogWarning("Attack Failed");
        }
        // Play flopping sound
        //audioSource.PlayOneShot(floppingSound);
    }

}
