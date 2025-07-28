using UnityEngine;
using System.Collections;

public class CreateSounds : MonoBehaviour
{
    public float WaitTime = 3f;
    private AudioSource sound;

    void Start () 
    {
        StartCoroutine(SpawnSound());
        sound = GetComponent<AudioSource>();
    }
    

    IEnumerator SpawnSound()
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitTime);
            if(StartGame.isGameStarted) sound.Play();
            
        }
    }
}

