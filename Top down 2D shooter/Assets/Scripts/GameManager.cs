using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Car shooter level 1");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Car shooter level 2");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
	
}
