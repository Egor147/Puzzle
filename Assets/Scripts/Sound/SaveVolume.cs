using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Данный класс сохраняет поставленный уровень громкости
public class SaveVolume : MonoBehaviour
{
    //Компонент, проигрывающий музыку
    [SerializeField]private AudioSource audioSourceComponent;

    //метод, срабатывающий по нажатию на кнопку "Сохранить"
    public void OnClick(){
        //Перезапись сохранения (А если ещё ни разу не сохраняли, то создание нового сохранения под ключём "SoundVolume")
        PlayerPrefs.SetFloat("SoundVolume", audioSourceComponent.volume);
    }
}
