using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action<float> onMove;

    private Vector3 mousePos;

    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            float x = Input.touches[0].deltaPosition.x;
            onMove?.Invoke(x);
            if(x>0)
                onMove?.Invoke(1);
            else
                onMove?.Invoke(-1);
        }
        else
        {
            dir = 0;
        }
        if ( Input.GetMouseButton(0))
        {
            float x = (Input.mousePosition - mousePos).x;
            mousePos = Input.mousePosition;
            if (x != 0)
            {
                if (x > 0)
                    dir = 1;
                else
                    dir = -1;
            }
            else
            {
                dir = 0;

            }
        }
        else
        {
            dir = 0;
        }
        onMove?.Invoke(dir);

    }
}
