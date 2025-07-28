using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public bool isMainScene;
    public float timeToSpawnFrom = 3f, timeToSpawnTo = 5.5f;
    public GameObject[] cars;
    private int countCars=0;
    private Coroutine bottomCars, leftCars, rightCars, upCars;
    private bool isLoseOnce;
    public GameObject canvasLosePanel;
    public Text nowScore, topScore, coinsCount;
    void Start()
    {
        CarController.isLose = false;
        CarController.countCars = 0;
        if(isMainScene)
        {
            timeToSpawnFrom = 4f; timeToSpawnTo = 6.5f;
        }
        bottomCars = StartCoroutine(BottomCars() );
        leftCars = StartCoroutine(LeftCars() );
        rightCars = StartCoroutine(RightCars() );
        upCars = StartCoroutine(UpCars() );
    }

    private void Update()
    {
        if(CarController.isLose && !isLoseOnce)
        {
            StopCoroutine(bottomCars);
            StopCoroutine(leftCars);
            StopCoroutine(rightCars);
            StopCoroutine(upCars);

            nowScore.text = "<color=#EA5200>Score: </color>" + CarController.countCars;
            /*PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("coins", 0);*/
            if(PlayerPrefs.GetInt("score") < CarController.countCars)
            {
                PlayerPrefs.SetInt("score", CarController.countCars);
            }
            topScore.text = "Top: " + PlayerPrefs.GetInt("score").ToString();
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + CarController.countCars);
            coinsCount.text = PlayerPrefs.GetInt("coins").ToString();

            
            canvasLosePanel.SetActive(true);
            isLoseOnce = true;
        }
    }


    IEnumerator BottomCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-3, 0.02f, -37.27f),  180);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds( timeToSpawn );

        }
    }

    IEnumerator LeftCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-97, 0.02f, -4.6f),  270);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds( timeToSpawn );

        }
    }


    IEnumerator RightCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(27, 0.02f, 1.65f),  90);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds( timeToSpawn );

        }
    }


    IEnumerator UpCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-9.73f, 0.02f, 64.23f),  0, true);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds( timeToSpawn );

        }
    }


    void SpawnCar(Vector3 pos, float rotationY, bool isMoveFromUp = false)
    {
        countCars++;
        GameObject newObj = Instantiate(cars[Random.Range(0, cars.Length)], pos, Quaternion.Euler(0, rotationY, 0)) as GameObject;
        newObj.name = "Car" + countCars;

        int random = isMainScene ? 1 : Random.Range(1,4);
        if(isMainScene)
        {
            newObj.GetComponent<CarController>().speed = 9f;
        }
        switch (random)
        {
            case 1: 
                //Move right
                newObj.GetComponent<CarController>().rightTurn = true;
                break;
            case 2: 
                //Move left
                newObj.GetComponent<CarController>().leftTurn = true;
                if(isMoveFromUp)
                {
                    newObj.GetComponent<CarController>().moveFromUp = true;
                }
                break;
            case 3: 
                //Move forward
                break;

        }
    }
}
