using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnokacFade : MonoBehaviour
{
    public Image img;
    public float fadeInTime = 3f;
    public float stayOnScreenTime = 2f;
    public float fadeOutTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        img.color = new Color(1, 1, 1, 0);
        FadeInFunction();
        Invoke("FadeOutFunction", fadeInTime+stayOnScreenTime);
        Invoke("NextScene", fadeInTime+stayOnScreenTime+fadeOutTime);
    }

    void NextScene()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void FadeOutFunction()
	{
        StartCoroutine(FadeOut());
    }

    void FadeInFunction()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
	{
        for (float i = 0; i <= fadeInTime; i += Time.deltaTime)   // i <= 1  -- over 1 second
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i/fadeInTime);
            yield return null;
        }
    }

    IEnumerator FadeOut()
	{
        for (float i = fadeOutTime; i >= 0; i -= Time.deltaTime)
        {
            img.color = new Color(1, 1, 1, i/fadeOutTime);
            yield return null;
        }
    }
}
