using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWeapon : MonoBehaviour
{
    public int damage = 25;

    public AudioClip deathSound;
    public AudioClip floppingSound;
    private AudioSource audioSource;

    private EnemyHealth enemyHealth;
    private Collider fishCollider;
    private float fishAttack = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        fishCollider = GetComponent<BoxCollider>();

        //fishCollider.enabled = false;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        fishCollider.enabled = true;

        yield return new WaitForSeconds(fishAttack);

        if (fishCollider != null)
        {
            fishCollider.enabled = false;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        // Deal damage
        if (other.CompareTag("Enemy"))
         {
            enemyHealth = other.GetComponent<EnemyHealth>();

            Debug.Log("Attacked enemy with fish");

            if (enemyHealth.GetHealth() > 0)
            {
                audioSource.PlayOneShot(floppingSound);
            }

            enemyHealth.TakeDamage(damage);

            if (enemyHealth.GetHealth() <= 0)
            {
                audioSource.PlayOneShot(deathSound);
            }
           
         }
       
        // Play flopping sound
        //audioSource.PlayOneShot(floppingSound);
    }

}
