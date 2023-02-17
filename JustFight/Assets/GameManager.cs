using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;

    [SerializeField] GameObject playerOneScoreText;
    [SerializeField] GameObject playerTwoScoreText;

    [SerializeField] Sprite playerOneSprite;
    [SerializeField] Sprite playerTwoSprite;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        // Check for input to go back to main menu
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void WinSenario(string playerWinner)
    {
        

        if (playerWinner == "PlayerOneScoreText")
        {
            SceneManager.LoadScene("WinScenePlayerOne");
        }
        else
        {
            SceneManager.LoadScene("WinScenePlayerTwo");

        }



    }
    public void StealScore(int score)
    {
        Debug.Log("Player died");
        // Checks if player one still exists and if the other player does not
        if (!playerTwo.gameObject.activeInHierarchy)
        {
            Debug.Log("Player 1 took score");

            // 'Steals' the other players score
            playerOne.GetComponent<CoinCollector>().coins = score;

            // Reset other players score
            playerTwo.GetComponent<CoinCollector>().coins = 0;
            playerTwoScoreText.GetComponent<TextNumbers>().counter = 0;
        }
        

        // Checks if player one still exists and if the other player does not
        if (!playerOne.gameObject.activeInHierarchy)
        {
            Debug.Log("Player 1 took score");
            
            // 'Steals' the other players score
            playerTwo.GetComponent<CoinCollector>().coins = score;

            // Reset other players score
            playerOne.GetComponent<CoinCollector>().coins = 0;
            playerOneScoreText.GetComponent<TextNumbers>().counter = 0;



        }

    }

}
