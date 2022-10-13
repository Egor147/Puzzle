using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Данный класс выставляет сохранённую ранее громкость
public class CheckSavedVolume : MonoBehaviour
{
    void Start()
    {
        //Проверка наличия уже сохранённых настроек звука
        if (PlayerPrefs.HasKey("SoundVolume"))
            //меняем значение слайдера на уже сохранённые ранее
            GetComponentInParent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundVolume");
    }

}
