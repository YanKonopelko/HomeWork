using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleHit
{
    public class Player : MonoBehaviour
    {
        public void Kill()
        {
            CircleHitScene.Instance.Lose();
        }
        
    }
}