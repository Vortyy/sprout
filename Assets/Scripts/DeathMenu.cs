using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] TimeCounter timeCounter;
    [SerializeField] TextMeshProUGUI timeScore;

    private void Start()
    {
        timeScore.text = "Time: " + (timeCounter.score / 60).ToString() + "m " + (timeCounter.score % 60).ToString() + "s";
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1); // Reloads the scene 1 with the game
    }
   public void MainMenu()
    {
        SceneManager.LoadScene(0); // Loads scene 0 with the main menu
    }
}
