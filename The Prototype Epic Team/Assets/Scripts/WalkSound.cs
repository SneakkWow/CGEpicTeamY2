using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private AudioSource walkAudioSource; // Assign this in the Inspector
    public AudioClip walkClip; // Assign your walking sound clip in the Inspector

    public FirstPersonController player;

    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isWalking && !isPlaying)
        {
            // Play the walking sound
            walkAudioSource.clip = walkClip; // Set the audio clip
            walkAudioSource.loop = true; // Loop the sound
            walkAudioSource.Play(); // Play the sound
            isPlaying = true;
            //player.isWalking = true; // Set walking state
        }
        else
        {
            // Stop walking sound if not moving forward
            if (!player.isWalking)
            {
                walkAudioSource.Stop(); // Stop the walking sound
                isPlaying = false;
                //player.isWalking = false; // Reset walking state
            }
        }
    }
}
