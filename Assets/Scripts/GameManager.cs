using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;



public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
   public bool Started { get; private set; }
   public bool GameOver { get; private set; }
   public int Score { get; private set; }
   public TMP_Text scoreText;

   void Start()
   {
      if (gameStartMessage != null)
         gameStartMessage.SetActive(true);
   }
   void Awake()
   { 
      
      if (Instance != null && Instance != this)
      {
         Destroy(gameObject);
         return;
         
      }

      Instance = this;
   }
   public GameObject gameOverMessage;
   public GameObject gameStartMessage;

   public void StartGame()
   {
      if (Started) return;
      Started = true;
      GameOver = false;
      if (gameStartMessage != null)
         gameStartMessage.SetActive(false);
      
   }
   
   public void SetGameOver()
   {
      if (GameOver) return;
      GameOver = true;
      Time.timeScale = 0f;
      if (gameOverMessage != null)
         gameOverMessage.SetActive(true);

   }

   public void Restart()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      if (gameOverMessage != null)
         gameOverMessage.SetActive(false);
   }
   
   public void AddScore(int value)
   {
      Score++;
      UpdateScoreUI();
   }

   void UpdateScoreUI()
   {
      {
         if (scoreText == null)
         {
            return;
         }
         scoreText.text = "Score: " + Score;
      }
   }
   
}
