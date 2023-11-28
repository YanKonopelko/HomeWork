using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CircleHit
{
    public class CircleHitScene : MonoBehaviour
    {
        public static CircleHitScene Instance;
        private curentScore = 0;
        private maxScore;
        private void Start()
        {
            Instance = this;
            maxScore = PlayerPrefs.HasKey("BestScore")?PlayerPrefs.GetInt("BestScore"):0;
        }

        public void Lose()
        {
            // ScenesManager.instance.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void AddScore(int Score){
            curentScore += Score;
            if(curentScore > maxScore){
                maxScore = curentScore;
                PlayerPrefs.SetInt("BestScore",maxScore);
            }
            UIManager.Instance.UpdateScoreText(curentScore,maxScore);
        }
    }
}