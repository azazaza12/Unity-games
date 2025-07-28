using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public Animator LogoText;
    public static bool isGameStarted = false;
    public GameObject scoreText;

    public void PlayGame()
    {
        isGameStarted = true;
        LogoText.SetBool("isGameStart", true);
        GetComponent<Animator>().enabled = true;
        scoreText.SetActive(true);
    }
}
