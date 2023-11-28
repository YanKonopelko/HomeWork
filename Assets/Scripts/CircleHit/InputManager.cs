using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CircleHit
{
    public class InputManager : MonoBehaviour
    {
        private PlayerMovement _player;
        private int uiMask = 5;
        [SerializeField] GraphicRaycaster m_Raycaster;
        PointerEventData m_PointerEventData;
        [SerializeField] EventSystem m_EventSystem;
        private void Start()
        {
            _player = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the game object
            if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
                m_PointerEventData.position = Input.GetTouch(0).position;
            else if(Input.GetMouseButtonDown(0))
                m_PointerEventData.position = Input.mousePosition;
            
            m_PointerEventData.position = Input.mousePosition;
            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
 
            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);
 
            
            if ((Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) && results.Count < 1)
            {
                _player.Rotate(); 
            }
        }
    }
}