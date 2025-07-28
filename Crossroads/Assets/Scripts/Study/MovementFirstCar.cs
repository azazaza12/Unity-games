using UnityEngine;

public class MovementFirstCar : MonoBehaviour
{
    public GameObject canvasFirst, secondCar, canvasSecond;
    private bool isFirst;
    private CarController _controller;


    void Start()
    {
        _controller = GetComponent<CarController>();
    }

    void Update()
    {
        if(transform.position.x < 4f && !isFirst)
        {
            isFirst = true;
            _controller.speed = 0;
            canvasFirst.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        //неправильное условие с позицией
        //if(!isFirst || transform.position.x > 4.5f) return;
        if(!isFirst) return;
        _controller.speed = 15f;
        canvasFirst.SetActive(false);
        canvasSecond.SetActive(true);
        secondCar.GetComponent<CarController>().speed = 12f;   
    }
}
