using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHighlight : MonoBehaviour
{
    private Renderer buttonRenderer;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            buttonRenderer.material.color = Color.green;  // Highlight color
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            buttonRenderer.material.color = Color.white;  // Default color
    }
}
