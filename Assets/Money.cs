using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public int money;
    public Text money_UI;

    public GamePlay bet_money;
    // Use this for initialization
    void Start () {
        money = 10000;
        money_UI.text = money.ToString();
    }

    // Update is called once per frame
    void Update () {
	}

    public void BetMoney()
    {
        if (money < bet_money.bet)
        {
            //all in
            bet_money.total_money_this_pan += money;
            money = 0;
            money_UI.text = money.ToString();
            bet_money.update_total_price();
        }

        else
        {
            bet_money.total_money_this_pan += bet_money.bet;

            for (int i = 0; i < bet_money.bet; i++)
            {
                money -= 1;
                money_UI.text = money.ToString();
            }

            bet_money.update_total_price();
        }
    }
}
