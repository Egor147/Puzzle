using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Класс, отвечающий за перетаскивание объектов
public class UIDragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Текущий слот
    public UIDropSlot currentSlot;

    // Канвас
    private Canvas canvas;
    // UI рейкастер
    private GraphicRaycaster graphicRaycaster;
    //Скрипт проверки победы игрока или же его ошибки
    
    [SerializeField]private UIItemCheckTag uiItemCheckTagScript;

    private void Start(){
        uiItemCheckTagScript = GetComponent<UIItemCheckTag>();
    }

    //Метод вызывается, когда пользователь касается экрана
    public void OnBeginDrag(PointerEventData eventData)
    {

        //Перемещение объекта за пальцем
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;

        // подключаем нужные UI элементы
        if (!canvas)
        {
            canvas = GetComponentInParent<Canvas>();
            graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
        }

        //Удаление родительского элемента
        transform.SetParent(canvas.transform, true);
        // Делаем перетаскиваемый элемент последним в иерархии дочерних объектов канваса
        //Для того, чтобы он отрисовывался последним и был поверх всех остальных объектов
        transform.SetAsLastSibling();
    }

    //Метод вызывается, когда пользователь водит пальцем по экрану
    public void OnDrag(PointerEventData eventData)
    {
        // Перемещение объекта за пальцем
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
    }

    //Метод вызывается в конце соприкосновения пальца и экрана
    public void OnEndDrag(PointerEventData eventData)
    {
        // Мы должны выполнить проверку, можем ли мы положить объект в новый слот
        var results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);

        foreach (var hit in results)
        {
            // Если мы нашли нужный слот
            var slot = hit.gameObject.GetComponent<UIDropSlot>();
            if (slot)
            {
                // Проверяем не занят ли он
                if (!slot.SlotFilled)
                {
                    // Меняем референсы
                    currentSlot.currentItem = null;
                    currentSlot = slot;
                    currentSlot.currentItem = this;
                }

                // В остальных случаях мы должны остановить выполнение цикла
                break;
            }
        }

        // Смена родительского объекта
        transform.SetParent(currentSlot.transform);
        // Выставление объекта по центру
        transform.localPosition = Vector3.zero;

        uiItemCheckTagScript.StartСhecking();
    }
}
