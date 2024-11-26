using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public string weaponName;
    public GameObject weaponPrefab;

    private bool isPlayerNearby = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PLayer"))
        {
            isPlayerNearby = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
       if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        } 

       //if (Input.GetKeyDown(KeyCode.Q))
       // {
        //    Drop();
        //}
    }

    void PickUp()
    {
        Destroy(gameObject);
    }

   // void Drop()
    //{

    //}
}
