using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasButtons : MonoBehaviour
{
    public Sprite Btn, BtnPressed;
    private UnityEngine.UI.Image image;


    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void PlayGame()
    {
        PlayerPrefs.SetString("first game", "");
        if(PlayerPrefs.GetString("first game") == "No")
        {
            StartCoroutine(LoadScene("Game"));
        }
        else
        {
            PlayerPrefs.SetString("first game", "No");
            StartCoroutine(LoadScene("Study"));
        }
    }


    public void RestartGame()
    {
        StartCoroutine(LoadScene("Game"));
        
    }

    IEnumerator LoadScene(string name)
    {
        float fadeTime = Camera.main.GetComponent<Fading>().Fade(1f);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(name);
    }

    public void SetPressedButton()
    {
        image.sprite = BtnPressed;
        transform.GetChild(0).localPosition -= new Vector3(0,5f,0);
    }

    public void SetDefaultButton()
    {
        image.sprite = Btn;
        transform.GetChild(0).localPosition += new Vector3(0,5f,0);
    }


    
}
