using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CircleHit
{
    public class CircleHitScene : MonoBehaviour
    {
        public static CircleHitScene Instance;

        private void Start()
        {
            Instance = this;
        }

        public void Lose()
        {
            // ScenesManager.instance.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}