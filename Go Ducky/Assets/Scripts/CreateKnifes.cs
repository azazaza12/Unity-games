using System;
using System.Collections;
using UnityEngine;

public class CreateKnifes : MonoBehaviour
{
    public float WaitTime = 2f;
    public GameObject knife;
    private bool isSpawn = false;
    //private float gameDuration = 0f;
    void Update()
    {
        if(StartGame.isGameStarted && !isSpawn)
        {
            isSpawn = true;
            StartCoroutine(Spawn());
        }

    }

    IEnumerator Spawn()
    {
        while(true)
        {
            if(!StartGame.isGameStarted) break;
            WaitTime = Math.Max(1.0f, (float)(Math.Atan(1/(0.015*MoveBackground.gameDuration)) + 0.5));
            Debug.Log("Wait time:" + WaitTime);
            Instantiate(
                knife, 
                new Vector2(7f, UnityEngine.Random.Range(-3.1f, 1.68f)), 
                Quaternion.Euler(new Vector3(0,0,-45)));
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
