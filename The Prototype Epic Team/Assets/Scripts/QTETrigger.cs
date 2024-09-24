using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    public QTEManager qteManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(qteManager != null)
            {
                qteManager.StartQTE();
            }
        }
    }
}
