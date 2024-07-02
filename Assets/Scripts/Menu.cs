using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayStory()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//Destroy(GameObject.FindGameObjectWithTag("Music"));
	}

    public void PlayEndless()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
