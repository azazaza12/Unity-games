using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondCar : MonoBehaviour
{
    void OnDestroy()
    {
        SceneManager.LoadScene("Game");
    }
}
