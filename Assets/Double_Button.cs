using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Double_Button : MonoBehaviour {

    public int counter = 0;
    public GamePlay gaming;
    public Money money;
    public GameObject money_pic;
    public AudioClip Double_Sound;

    void Start () {
        GameObject.Find("Double_Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Double_Button").GetComponent<Button>().onClick.AddListener(TaksOnClick);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void TaksOnClick()
    {
        change_button_status_false();
        

//        GameObject money_1;
  //      money_1 = Instantiate(money_pic, money.transform.position, money.transform.rotation);
        StartCoroutine(throw_money(0.5f));


        /*
        if (gaming.how_many_survive != 1)
            StartCoroutine(gaming.Enemy_1_makes_decision());
            */

        /*
        GameObject money_2;
        money_2 = Instantiate(money_pic, money.transform.position, money.transform.rotation);
        StartCoroutine(throw_money(0.5f, money_1));
        money.BetMoney();
        money.BetMoney();
        */
        //Enemy2 Decision Making call하기

        if (gaming.winner != 1)
            StartCoroutine(gaming.Enemy_1_makes_decision());

        else
            StartCoroutine(gaming.Check_Winner());

    }

    public IEnumerator throw_money(float seconds)
    {
        money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, money.transform.position, money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Double_Sound, Camera.main.transform.position);


        if (gaming.round == 1)
            endPos = money_pack_1.gameObject.transform.position + new Vector3(-6.85f, 8f, 0);
        else if (gaming.round == 2)
            endPos = money_pack_1.gameObject.transform.position + new Vector3(-7.85f, 7.5f, 0);
        else
            endPos = money_pack_1.gameObject.transform.position + new Vector3(-8.85f, 7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        //yield return new WaitForSeconds(1f);

        money.BetMoney();

        GameObject money_pack_2;
        money_pack_2 = Instantiate(money_pic, money.transform.position, money.transform.rotation);
        float elapsedTime_2 = 0;

        Vector3 startingPos_2 = money_pack_2.gameObject.transform.position;
        Vector3 endPos_2;

        if (gaming.round == 1)
            endPos_2 = money_pack_2.gameObject.transform.position + new Vector3(-7.85f, 7.75f, 0);
        else if (gaming.round == 2)
            endPos_2 = money_pack_2.gameObject.transform.position + new Vector3(-8.85f, 7.25f, 0);
        else
            endPos_2 = money_pack_2.gameObject.transform.position + new Vector3(-9.85f, 6.75f, 0);

        while (elapsedTime_2 < seconds)
        {
            money_pack_2.gameObject.transform.position = Vector3.Lerp(startingPos_2, endPos_2, elapsedTime_2 / seconds);
            elapsedTime_2 += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        gaming.bet = gaming.bet * 2;
        gaming.update_betting_price();
        /*
        float elapsedTime = 0;
        Vector3 startingPos = moneypack.gameObject.transform.position;
        Vector3 endPos;

        if (gaming.round == 1)
            endPos = moneypack.gameObject.transform.position + new Vector3(-6.85f + (counter * -0.5f), 8f + (counter * -0.5f), 0);
        else if (gaming.round == 2)
            endPos = moneypack.gameObject.transform.position + new Vector3(-7.85f + (counter * -0.5f), 7.5f + (counter * -0.5f), 0);
        else
            endPos = moneypack.gameObject.transform.position + new Vector3(-8.85f + (counter * -0.5f), 7f + (counter * -0.5f), 0);
        //     endPos

        while (elapsedTime < seconds)
        {
            moneypack.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        moneypack.gameObject.transform.position = endPos;

        if (counter == 0)
            counter = 1;
        else if (counter == 1)
            counter = 0;*/

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
}
