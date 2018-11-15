using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    Self_Hand,
    Self_Field,
    Enemy_Hand,
    Enemy_Field
}

public class DropPlaceScript : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    public FieldType Type;

    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.Self_Field)
            return;
        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
        if (card)
            card.DefaultParent = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || Type==FieldType.Enemy_Field || Type == FieldType.Enemy_Hand)
            return;

        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card)
            card.DefaultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();

        if (card && card.DefaultTempCardParent == transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }
}
