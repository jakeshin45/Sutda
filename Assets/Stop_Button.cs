using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stop_Button : MonoBehaviour {

    public GamePlay gaming;
    public AudioClip Die_Sound;

    // Use this for initialization
    void Start () {
        /*
        GameObject.Find("Stop_Button").GetComponentInChildren<Text>().text = "Stop";
        GameObject.Find("Stop_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Stop_Button").GetComponent<Button>().onClick.AddListener(TaksOnClick);
        */
        GameObject.Find("Die_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Die_Button").GetComponent<Button>().onClick.AddListener(TaksOnClick);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void TaksOnClick()
    {
        AudioSource.PlayClipAtPoint(Die_Sound, Camera.main.transform.position);

        change_button_status_false();
        //pop_up_stop();
        //gaming.startgame();
        gaming.active[0] = false;
        gaming.how_many_survive--;
        //Enemy1 decisionmaking call하기

        /*
        if (gaming.how_many_survive != 1)
            StartCoroutine(gaming.Enemy_1_makes_decision());
            */

        if (gaming.winner != 1)
            StartCoroutine(gaming.Enemy_1_makes_decision());

        else
            StartCoroutine(gaming.Check_Winner());
    }


    public void change_button_status_true()
    {
        GameObject.Find("Call_Button").GetComponent<Button>().interactable = true;
        GameObject.Find("Die_Button").GetComponent<Button>().interactable = true;
        GameObject.Find("Double_Button").GetComponent<Button>().interactable = true;
    }

    public void change_button_status_false()
    {
        GameObject.Find("Call_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Die_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Double_Button").GetComponent<Button>().interactable = false;
    }
    /*
    public void pop_up_stop()
    {
        Vector3 new_position = new Vector3(GameObject.Find("Stop-Button-Player").gameObject.transform.position.x,
                                            GameObject.Find("Stop-Button-Player").gameObject.transform.position.y,
                                            GameObject.Find("Stop-Button-Player").gameObject.transform.position.z + 100);
        GameObject.Find("Stop-Button-Player").gameObject.transform.position = new_position;
        GameObject.Find("Go_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Stop_Button").GetComponent<Button>().interactable = false;
        gaming.player_decision = 0;
    }*/
}
