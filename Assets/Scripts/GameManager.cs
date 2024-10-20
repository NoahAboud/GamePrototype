using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject boss;
    public GameObject player;
    public GameObject victoryScreenUI;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (victoryScreenUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);

        boss.GetComponent<RockShooting>().enabled = false;
        player.GetComponent<playercontroller>().enabled = false;
       

    }

    public void victoryScreen()
    {
        victoryScreenUI.SetActive(true);

        boss.GetComponent<RockShooting>().enabled = false;
        player.GetComponent<playercontroller>().enabled = false;
    }

    
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quit()
    {
        Application.Quit();
    }
 
}
