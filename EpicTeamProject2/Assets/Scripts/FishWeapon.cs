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
    public void Attack(GameObject target)
    {
        //* Deal damage
       // if (target.TryGetComponent(out Enemy enemy))
       // {
       //     enemy.TakeDamage(damage);
       // }
        // Play flopping sound
        //audioSource.PlayOneShot(floppingSound);
    }

}