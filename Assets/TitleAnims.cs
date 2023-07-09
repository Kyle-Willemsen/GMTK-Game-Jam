using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Animator anim;
    private Vector3 origScale;
    public Vector3 highlightedScale;

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = highlightedScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = origScale;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        origScale = new Vector3(1, 1, 1);
        //highlightedScale = new Vector3(2, 2, 2);
        
    }
}
