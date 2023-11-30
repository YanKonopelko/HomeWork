using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SquareShift
{
    public class Point : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ShapeShiftScene.Instance.AddScore(1);
                SelfDesroy();
            }
        }

        void SelfDesroy()
        {
            // await Task.Delay(1);
            SoundManager.instance.PlayAtPoint(SoundManager.SoundType.CollectSound,transform.position);
            Destroy(gameObject);
        }
    }
}
