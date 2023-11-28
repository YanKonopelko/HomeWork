using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SquareShift
{
    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update


        // Update is called once per frame
        void Update()
        {

        }

        public void Kill()
        {
            ShapeShiftScene.Instance.Lose();
        }


    }
}