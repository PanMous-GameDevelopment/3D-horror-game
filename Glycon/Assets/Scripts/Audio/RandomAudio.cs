using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public List<AudioClip> soundList; // Creates a list with audio.
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSound());
    }

    IEnumerator PlayRandomSound()
    { // Plays a random audio from the list.
        while (true)
        {
            yield return new WaitForSeconds(90f);
            int randomIndex = Random.Range(0, soundList.Count);
            audioSource.PlayOneShot(soundList[randomIndex]);
        }
    }
}
