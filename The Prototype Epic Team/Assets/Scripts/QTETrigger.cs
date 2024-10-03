using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    public QTEManager qteManager;
    public DoorMovement doorMovement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            qteManager.StartQTE();
        }
    }
}
