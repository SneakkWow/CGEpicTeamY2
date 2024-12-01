using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public string weaponName;
    public GameObject weaponPrefab1;
    public GameObject weaponPrefab2;

    private bool isPlayerNearby = false;

    //private enemyCollide enemyCollide;
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
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
       if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
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

        weaponPrefab1.SetActive(true);

        weaponPrefab2.SetActive(false);
    }

   // void Drop()
    //{

    //}
}
