using System;
using UnityEngine;

namespace CircleHit
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private bool isForward;
        [SerializeField] private float moveSpeed;
        private Transform _transform;
        [SerializeField] private Transform target;
        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            var modifier = isForward ? 1 : -1;
            _transform.RotateAround(target.position,new Vector3(0,0,1),moveSpeed*Time.deltaTime*modifier);
        }

        public void Rotate()
        {
            isForward = !isForward;
        }
    }
}