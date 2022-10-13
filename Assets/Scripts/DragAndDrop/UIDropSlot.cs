using UnityEngine;

//Класс, показывающий занят ли слот
public class UIDropSlot : MonoBehaviour
{
    //Текущий элемент
    public UIDragItem currentItem;

    // Возвращает сигнал о том, занят ли слот
    public bool SlotFilled => currentItem;
}
