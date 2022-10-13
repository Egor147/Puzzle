using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSoundControl : MonoBehaviour
{
    //Источник звука
    private AudioSource audioSourceComponent;
    //Слайдер
    private Slider sliderComponent;
    //Текст на всплывающей панели
    [SerializeField]private TMP_Text panelText;

    private void Start(){
        //Подключаем все необходимые компоненты
        audioSourceComponent = GetComponentInParent<AudioSource>();
        sliderComponent = GetComponent<Slider>();

        //Так как громкость изначально уже настроена под сохранённую ранее, нам остаётся настроить значение слайдера
        sliderComponent.value = audioSourceComponent.volume;

        //Сразу указываем нужный текст, преобразовывая значение слайдера в целое число, а затем в нужную строку
        SetText("Звук: " + ((int)(sliderComponent.value*100)).ToString() + "%");
    }

    //Метод, вызываемый при изменении значения слайдера
    public void changeVolume()
    {
        //Меняем значение громкости
        audioSourceComponent.volume = sliderComponent.value;
        //Меняем значение текста
        SetText("Звук: " + ((int)(sliderComponent.value*100)).ToString() + "%");
    }

    private void SetText(string needText){
        panelText.text = needText;
    }

}
