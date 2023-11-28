using UnityEngine;

namespace SquareShift
{
    public class CameraController : MonoBehaviour
    {
        private float _Xoffset;

        [SerializeField] private Transform player;

        // Start is called before the first frame update
        void Start()
        {
            _Xoffset = player.position.x - transform.position.x;
        }

        // Update is called once per frame
        void Update()
        {
            var pos = player.position;
            pos.z = -10;
            pos.x = 0;
            transform.position = pos;
        }
    }
}