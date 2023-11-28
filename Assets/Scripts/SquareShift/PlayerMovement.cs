using UnityEngine;

namespace SquareShift
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        public float horizontalMoveSpeed = 5;
        private float curenthorizontalMoveSpeed = 5;

        public float verticalMoveSpeed = 5;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            InputManager.onMove += Move;
        }

        private void OnDisable()
        {
            InputManager.onMove -= Move;
        }

        // Update is called once per frame
        void Update()
        {
            _rigidbody2D.velocity = new Vector2(curenthorizontalMoveSpeed, verticalMoveSpeed);
        }

        private void Move(float x)
        {
            curenthorizontalMoveSpeed = horizontalMoveSpeed * x;
        }
    }
}