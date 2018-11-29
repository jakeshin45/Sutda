using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_the_game : MonoBehaviour
{
    /*
    public GameObject temp1;
    public GameObject temp2;
    public GameObject temp3;
    public GameObject temp4;
    public GameObject temp5;
    public GameObject temp6;

    public GameObject temp7;
    public GameObject temp8;
    public GameObject temp9;
    public GameObject temp10;
    public GameObject temp11;
    public GameObject temp12;*/
    public GamePlay gaming;

    public GameObject StartUI;


    // Use this for initialization
    void Start()
    {
        GameObject.Find("Start_Button").GetComponent<Button>().onClick.AddListener(TaksOnClick);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaksOnClick()
    {
        /*
        temp1.SetActive(true);
        temp2.SetActive(true);
        temp3.SetActive(true);
        temp4.SetActive(true);
        temp5.SetActive(true);
        temp6.SetActive(true);
        temp7.SetActive(true);
        temp8.SetActive(true);
        temp9.SetActive(true);
        temp10.SetActive(true);
        temp11.SetActive(true);
        temp12.SetActive(true);
        */
        //StartCoroutine(gaming.Start_Game());

        StartUI.SetActive(false);

    }
}