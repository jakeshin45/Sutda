using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking_System : MonoBehaviour
{

    public GameObject HelpUI;
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
    public GameObject temp12;
    public int checker;
    // Use this for initialization
    void Start()
    {
        checker = 0;
        GameObject.Find("Help").GetComponent<Button>().onClick.AddListener(TaksOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaksOnClick()
    {
        if (checker == 0)
        {
            HelpUI.SetActive(true);
            checker = 1;
            temp1.SetActive(false);
            temp2.SetActive(false);
            temp3.SetActive(false);
            temp4.SetActive(false);
            temp5.SetActive(false);
            temp6.SetActive(false);
            temp7.SetActive(false);
            temp8.SetActive(false);
            temp9.SetActive(false);
            temp10.SetActive(false);
            temp11.SetActive(false);
            temp12.SetActive(false);
        }

        else if(checker == 1)
        {
            HelpUI.SetActive(false);
            checker = 0;
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
        }

    }

}
