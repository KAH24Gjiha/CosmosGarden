using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupController : MonoBehaviour, IPointerClickHandler
{
    public GameObject popup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.tag == "eventPop")
            popup.SetActive(false);
    }

    public void SetPopLast()
    {
        popup.transform.SetAsLastSibling();
    }
}
