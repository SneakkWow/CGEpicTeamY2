using UnityEngine;
using System.Collections;

public class DistanceTo: MonoBehaviour
{
    // detects when the other transform is closer than closeDistance
    // this is faster than using Vector3.magnitude
    public Transform other;
    public float closestDistance = 25.0f; //Right behind me
    public float closeDistance = 50.0f; //Is close
    public float farDistance = 75.0f; //Isn't close

    /*private AudioSource playerAudio;
    public AudioClip ambience;
    public AudioClip closestMusic;
    public AudioClip closeMusic;
    public AudioClip farMusic;*/

    public bool clipOneOn = false;
    public bool clipTwoOn = false;
    public bool clipThreeOn = false;
    public bool clipZeroOn = true;

    public MusicManager musicManager;
    void Start()
    {
        //playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (other)
        {
            Vector3 offset = other.position - transform.position;
            float sqrLen = offset.sqrMagnitude;

            // square the distance we compare with
            if (sqrLen < closestDistance * closestDistance)
            { 
                //Debug.Log("The other transform is so close to me!");
                if (!clipThreeOn)
                {
                    clipThreeOn = true;
                    musicManager.PlayMusic(3);
                    clipTwoOn = false;
}
                //playerAudio.Stop();
                //playerAudio.PlayOneShot(closestMusic, 0.7f);
            }
            else if (sqrLen < closeDistance * closeDistance)
            {
                //Debug.Log("The other transform is close to me!");
                if (!clipTwoOn)
                {
                    clipTwoOn = true;
                    musicManager.PlayMusic(2);
                    clipThreeOn = false;
                    clipOneOn = false;
                }
                //playerAudio.Stop();
                //playerAudio.PlayOneShot(closeMusic, 0.7f);
            }
            else if (sqrLen < farDistance * farDistance)
            {
                //Debug.Log("The other transform is far from me!");
                if (!clipOneOn)
                {
                    clipOneOn = true;
                    musicManager.PlayMusic(1);
                    clipTwoOn = false;
                    clipZeroOn = false;
                }
                //playerAudio.Stop();
                //playerAudio.PlayOneShot(closeMusic, 0.7f);
            }
            else
            {
                //Debug.Log("Im so safe right now");
                if (!clipZeroOn)
                {
                    clipZeroOn = true;
                    musicManager.PlayMusic(0);
                    clipOneOn = false;
                }
                //playerAudio.Stop();
                //playerAudio.PlayOneShot(ambience, 0.7f);
            }
        }
        
    }
}