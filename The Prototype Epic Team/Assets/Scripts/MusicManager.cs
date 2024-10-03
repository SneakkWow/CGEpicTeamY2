using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips; // Array to hold your music clips
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (musicClips.Length > 0)
        {
            PlayMusic(0); // Start with the first music clip
        }
    }

    public void PlayMusic(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= musicClips.Length) return;

        // Stop current music and play new one
        StartCoroutine(FadeOutAndPlay(clipIndex));
    }

    private IEnumerator FadeOutAndPlay(int newClipIndex)
    {
        // Fade out current music
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * 0.5f; // Adjust fade-out speed
            yield return null;
        }

        audioSource.Stop();
        audioSource.clip = musicClips[newClipIndex];
        audioSource.volume = 0.4f; // Reset volume
        audioSource.Play();
    }
}
