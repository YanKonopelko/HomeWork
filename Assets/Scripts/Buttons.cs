using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour,IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData) =>
        SoundManager.instance.PlaySound(SoundManager.SoundType.ButtonSound);

}
