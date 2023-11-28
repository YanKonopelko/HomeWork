using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CircleHit
{
    public class CircleHitScene : MonoBehaviour
    {
        public static CircleHitScene Instance;
        private int curentScore = 0;
        private int maxScore;
        private bool isPaused = false;
        private void Start()
        {
            Instance = this;
            maxScore = PlayerPrefs.HasKey("BestScore")?PlayerPrefs.GetInt("BestScore"):0;
        }

        public void Lose()
        {
            ScenesManager.instance.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void AddScore(int Score){
            curentScore += Score;
            UIManager.Instance.UpdateScoreText(curentScore,false);
            if(curentScore > maxScore){
                maxScore = curentScore;
                UIManager.Instance.UpdateScoreText(curentScore,true);

                PlayerPrefs.SetInt(PlayerPrefs.GetString("LastGame") + "BestScore",maxScore);
                PlayerPrefs.SetInt("IsNewRecord",1);

            }
        }

        public void Pause()
        {
            isPaused = !isPaused;
            UIManager.Instance.Pause(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }

        public void ToMenu()
        {
            ScenesManager.instance.LoadScene("MainMenu");
        }
    }
}