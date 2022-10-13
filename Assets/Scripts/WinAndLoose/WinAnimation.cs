using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinAnimation : MonoBehaviour
{

    [SerializeField]private Image rightItemImg, leftItemImg, myItemImg;
    [SerializeField]private float speed;

    private float t = 0;

    private bool startAnimate = false;


    private void Start(){
        myItemImg = GetComponent<Image>();
    }

    //Метод, вызываемый из другого класса, начинающий победную анимацию
    public void StartAnimation(){
        startAnimate = true;
    }


    private void Update(){
        if (t<1f && startAnimate)
            ChangeColor();
    }

    private void ChangeColor(){
        t += speed*Time.deltaTime;
        Color newColor = Color.Lerp(myItemImg.color,new Color(myItemImg.color.r, myItemImg.color.g,myItemImg.color.b, 0),t);
        myItemImg.color = newColor;
        leftItemImg.color = myItemImg.color;
        rightItemImg.color = myItemImg.color;
    }
}

