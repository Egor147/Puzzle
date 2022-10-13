using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Класс, отвечающий за проверку победы или ошибки игрока
public class UIItemCheckTag : MonoBehaviour
{
    //Панель появляющаяя после победы/поражения игрока
    [SerializeField]private GameObject EndGamePanel;
    //Скрипт, отвечающий за анимацию победы
    [SerializeField]private WinAnimation winAnimationScript;
    //Текст на всплывающей панели
    [SerializeField]private TMP_Text panelText;

    //Метод, вызываемый после запуска игры
    private void Start(){
        //Подключение нужного скрипта
        winAnimationScript = GetComponent<WinAnimation>();
    }

    public void StartСhecking(){
        //Проверка тега родительского объекта. Loose-ошибка, Win-победа.
        if (transform.parent.gameObject.CompareTag("Loose")){
            //Забираем у игрока возможность двигать объект
            Destroy(GetComponent<UIDragItem>());
            //Установка нужного текста
            SetText("ОШИБКА"); 
            //Активация панели
            EndGamePanel.SetActive(true);
        }
        else if (transform.parent.gameObject.CompareTag("Win")){
            //Забираем у игрока возможность двигать объект
            Destroy(GetComponent<UIDragItem>());
            //Установка нужного текста
            SetText("ПОБЕДА");
            //Запуск анимации победы
            winAnimationScript.StartAnimation();
            //Запуск корутины, делающей экран победы активным с нужной задержкой, чтобы он появился только после анимации
            StartCoroutine(Wining());
        }
    }

    //Корутина, делающая панель победы активной после анимации исчезновения
    private IEnumerator Wining(){
        //Ожидание
        yield return new WaitForSeconds(3);
        EndGamePanel.SetActive(true);
    }

    //Метод, меняющий текст панели на нужный
    private void SetText(string needText){
        panelText.text = needText;
    }
}
