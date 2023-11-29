using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SquareShift
{
    public class Point : MonoBehaviour
    {

        // Update is called once per frame
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().Kill();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ShapeShiftScene.Instance.AddScore(1);
                SelfDesroy();
            }
        }

        async void SelfDesroy()
        {
            await Task.Delay(1);
            Destroy(gameObject);
        }
    }
}
