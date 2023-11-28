using System;
using UnityEngine;

namespace CircleHit
{
    public class InputManager : MonoBehaviour
    {
        private PlayerMovement _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerMovement>();

        }

        private void Update()
        {
            if(_player is null) return;
            if (Input.touchCount>0 && (Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
            {
                _player.Rotate(); 
            }
        }
    }
}