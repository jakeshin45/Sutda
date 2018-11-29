using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Go_Button : MonoBehaviour {

    public GamePlay gaming;
    public Money money;
    public GameObject money_pic;
    public AudioClip Call_Sound;

    
	void Start () {
        /*
        GameObject.Find("Go_Button").GetComponentInChildren<Text>().text = "Go";
        */
        // GameObject.Find("Call_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Call_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Call_Button").GetComponent<Button>().onClick.AddListener(TaksOnClick);
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    void TaksOnClick()
    {
        change_button_status_false();
        //Debug.Log(money.bet_money);
        //pop_up_go();
        GameObject money_1;
        money_1 = Instantiate(money_pic, money.transform.position, money.transform.rotation);
        StartCoroutine(throw_money(0.5f, money_1));
        money.BetMoney();

        /*
        if (gaming.how_many_survive != 1)
            StartCoroutine(gaming.Enemy_1_makes_decision());
            */
        //Enemy2 Decision Making call하기
        if (gaming.winner != 1)
            StartCoroutine(gaming.Enemy_1_makes_decision());

        else
            StartCoroutine(gaming.Check_Winner());

    }

    public IEnumerator throw_money(float seconds, GameObject moneypack)
    {
        float elapsedTime = 0;
        Vector3 startingPos = moneypack.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Call_Sound, Camera.main.transform.position);

       
            endPos = moneypack.gameObject.transform.position + new Vector3(-8.85f, 7f, 0);
       //     endPos

        while (elapsedTime < seconds)
        {
            moneypack.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        moneypack.gameObject.transform.position = endPos;


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

    public void pop_up_go()
    {
        /*
        Vector3 new_position = new Vector3(GameObject.Find("Go-Button-Player").gameObject.transform.position.x,
                                            GameObject.Find("Go-Button-Player").gameObject.transform.position.y,
                                            GameObject.Find("Go-Button-Player").gameObject.transform.position.z + 100);
        GameObject.Find("Go-Button-Player").gameObject.transform.position = new_position;
        GameObject.Find("Go_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Stop_Button").GetComponent<Button>().interactable = false;
        gaming.player_decision = 1;
        */
    }


}
