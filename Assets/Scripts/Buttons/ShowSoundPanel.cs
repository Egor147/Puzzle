using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSoundPanel : MonoBehaviour
{
    [SerializeField]private GameObject SoundPanel;

    public void OnClick(){
        //Активировать панель
        SoundPanel.SetActive(true);
    }
}
