using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

    public AudioClip Double_Sound;
    public AudioClip Call_Sound;
    public AudioClip Die_Sound;


    public int bet = 100;
    public Text bet_UI;
    public Text total_price_UI;
    public int total_money_this_pan = 0;

    public GameObject GameOverContainer;

    public int round = 1;

    public status Player;
    public Enemy_Status Enemy1;
    public Enemy_Status Enemy2;
    public Enemy_Status Enemy3;

    public Money Player_Money;
    public Money Enemy1_Money;
    public Money Enemy2_Money;
    public Money Enemy3_Money;

    public deck deck_info;

    public int winner;
    public bool[] active = new bool[] { false, false, false, false };
    public int how_many_survive = 0;

    public Go_Button Call_Button;
    public Stop_Button Die_Button;
    public Double_Button Db_Button;

    public GameObject money_pic;

    
    public UI_Card_1 card1UI;
    public UI_Card_2 card2UI;
    public TEXT_UPDATE_2 ranking_card;
    public TEXT_UPDATE_1 ranking_comb;
    
    // Use this for initialization
    void Start() {
        winner = 4;
        update_betting_price();
        update_total_price();
       StartCoroutine(Start_Game());

    }

    public void update_betting_price()
    {
        bet_UI.text = bet.ToString();
    }

    public void update_total_price()
    {
        total_price_UI.text = total_money_this_pan.ToString();
    }

    // Update is called once per frame
    void Update() {

    }

    public IEnumerator Start_Game()
    {
        status_refresh();

        //If Player does not have a money anymore Game is over

        if (Enemy1_Money.money <= 0)
        {
            active[1] = false;
            how_many_survive--;
        }

        if (Enemy2_Money.money <= 0)
        {
            active[2] = false;
            how_many_survive--;
        }

        if (Enemy3_Money.money <= 0)
        {
            active[3] = false;
            how_many_survive--;
        }

        if (Player_Money.money <= 0)
            GameOverContainer.SetActive(true);


        //If we can proceed the game, shuffle and distribute Card. Order depends on the who is the winner at the last stage.
        else
        {
            deck_info.Distribute_Number();
            PickRotation();
        }

        Debug.Log("hELLO2");

        yield return new WaitForSeconds(8.5f);

        Debug.Log("hELLO3");


        if (how_many_survive == 1)
        {
            StartCoroutine(Check_Winner());
        }

        else
        {
            if (winner == 4)
            {
                Situation_Player_First();
            }

            else if (winner == 3)
            {
                Situation_Enemy_3_First();
            }

            else if (winner == 2)
            {
                Situation_Enemy_2_First();
            }

            else
            {
                Situation_Enemy_1_First();
            }
        }
    }

    public void Situation_Player_First()
    {
        if (active[0] == true)
            StartCoroutine(Player_makes_decision());
        else
            StartCoroutine(Enemy_1_makes_decision());
    }

    public void Situation_Enemy_3_First()
    {
        Debug.Log("hELLO");
        if (active[3] == true)
            StartCoroutine(Enemy_3_makes_decision());
        else
            StartCoroutine(Player_makes_decision());
    }

    public void Situation_Enemy_2_First()
    {
        if (active[2] == true)
            StartCoroutine(Enemy_2_makes_decision());
        else
            StartCoroutine(Enemy_3_makes_decision());
    }

    public void Situation_Enemy_1_First()
    {
        if (active[1] == true)
            StartCoroutine(Enemy_1_makes_decision());
        else
            StartCoroutine(Enemy_2_makes_decision());
    }

    public IEnumerator Player_makes_decision()
    {
        if(active[0] == true && Player_Money.money > 0)
        {
            Call_Button.change_button_status_true();

            if(how_many_survive == 1)
                GameObject.Find("Die_Button").GetComponent<Button>().interactable = false;

        }
        yield return null;
    }

    public IEnumerator Enemy_1_makes_decision()
    {
        if (active[1] == true && Enemy1_Money.money > 0)
        {
            yield return new WaitForSeconds(2f);
            if (how_many_survive == 1)
                Enemy1.decision = 1;
            else
            {
                Enemy1.Calc_Decision();
            }
            if (Enemy1.decision == 0)
            {
                StartCoroutine(Enemy_1_throw_double(0.5f));
            }

            else if (Enemy1.decision == 1)
            {
                StartCoroutine(Enemy_1_throw_money(0.5f));
            }

            else if (Enemy1.decision == 2)
            {
                AudioSource.PlayClipAtPoint(Die_Sound, Camera.main.transform.position);
                active[1] = false;
                how_many_survive--;
            }
        }

        if (winner != 2)
            yield return StartCoroutine(Enemy_2_makes_decision());

        else
            yield return StartCoroutine(Check_Winner());

        yield return null;
    }

    public IEnumerator Enemy_2_makes_decision()
    {
        if (active[2] == true && Enemy2_Money.money > 0)
        {
            yield return new WaitForSeconds(3f);
            Enemy2.update_judgement();
            if (how_many_survive == 1)
                Enemy2.decision = 1;
            else
                Enemy2.Calc_Decision();

            if (Enemy2.decision == 0)
            {
                StartCoroutine(Enemy_2_throw_double(1f));
            }

            else if (Enemy2.decision == 1)
            {
                StartCoroutine(Enemy_2_throw_money(1f));
            }

            else if (Enemy2.decision == 2)
            {
                AudioSource.PlayClipAtPoint(Die_Sound, Camera.main.transform.position);

                active[2] = false;
                how_many_survive--;
            }
        }

        if (winner != 3)
            yield return StartCoroutine(Enemy_3_makes_decision());

        else
            yield return StartCoroutine(Check_Winner());
    }

    public IEnumerator Enemy_3_makes_decision()
    {
        if (active[3] == true && Enemy3_Money.money > 0)
        {
            yield return new WaitForSeconds(3f);
            Enemy3.update_judgement();
            if (how_many_survive == 1)
                Enemy3.decision = 1;
            else
                Enemy3.Calc_Decision();


            if (Enemy3.decision == 0)
            {
                StartCoroutine(Enemy_3_throw_double(1f));
            }

            else if (Enemy3.decision == 1)
            {
                StartCoroutine(Enemy_3_throw_money(1f));
            }

            else if (Enemy3.decision == 2)
            {
                AudioSource.PlayClipAtPoint(Die_Sound, Camera.main.transform.position);

                active[3] = false;
                how_many_survive--;
            }
        }

        if (winner != 4)
            yield return StartCoroutine(Player_makes_decision());

        else
            yield return StartCoroutine(Check_Winner());
    }

    public IEnumerator Enemy_1_throw_money(float seconds)
    {
        Enemy1_Money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, Enemy1_Money.transform.position, Enemy1_Money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Call_Sound, Camera.main.transform.position);


            endPos = money_pack_1.gameObject.transform.position + new Vector3(-8.85f, -7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        update_betting_price();
        yield return null;
    }

    public IEnumerator Enemy_1_throw_double(float seconds)
    {
        Enemy1_Money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, Enemy1_Money.transform.position, Enemy1_Money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Double_Sound, Camera.main.transform.position);


            endPos = money_pack_1.gameObject.transform.position + new Vector3(-8.85f, -7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Enemy1_Money.BetMoney();
        GameObject money_pack_2;
        money_pack_2 = Instantiate(money_pic, Enemy1_Money.transform.position, Enemy1_Money.transform.rotation);
        float elapsedTime_2 = 0;

        Vector3 startingPos_2 = money_pack_2.gameObject.transform.position;
        Vector3 endPos_2;


            endPos_2 = money_pack_2.gameObject.transform.position + new Vector3(-9.85f, -6.75f, 0);

        while (elapsedTime_2 < seconds)
        {
            money_pack_2.gameObject.transform.position = Vector3.Lerp(startingPos_2, endPos_2, elapsedTime_2 / seconds);
            elapsedTime_2 += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        bet = bet * 2;
        update_betting_price();

        yield return null;
    }



    public IEnumerator Enemy_2_throw_money(float seconds)
    {
        Enemy2_Money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, Enemy2_Money.transform.position, Enemy2_Money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Call_Sound, Camera.main.transform.position);


            endPos = money_pack_1.gameObject.transform.position + new Vector3(7.00f, -7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        update_betting_price();
        yield return null;
    }

    public IEnumerator Enemy_2_throw_double(float seconds)
    {
        Enemy2_Money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, Enemy2_Money.transform.position, Enemy2_Money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Double_Sound, Camera.main.transform.position);


            endPos = money_pack_1.gameObject.transform.position + new Vector3(7.00f, -7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Enemy2_Money.BetMoney();
        GameObject money_pack_2;
        money_pack_2 = Instantiate(money_pic, Enemy2_Money.transform.position, Enemy2_Money.transform.rotation);
        float elapsedTime_2 = 0;

        Vector3 startingPos_2 = money_pack_2.gameObject.transform.position;
        Vector3 endPos_2;

        endPos_2 = money_pack_2.gameObject.transform.position + new Vector3(8.00f, -6.75f, 0);

        while (elapsedTime_2 < seconds)
        {
            money_pack_2.gameObject.transform.position = Vector3.Lerp(startingPos_2, endPos_2, elapsedTime_2 / seconds);
            elapsedTime_2 += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        bet = bet * 2;
        update_betting_price();

        yield return null;
    }




    public IEnumerator Enemy_3_throw_money(float seconds)
    {
        Enemy3_Money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, Enemy3_Money.transform.position, Enemy3_Money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Call_Sound, Camera.main.transform.position);

            endPos = money_pack_1.gameObject.transform.position + new Vector3(8.00f, 7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        update_betting_price();
        yield return null;
    }

    public IEnumerator Enemy_3_throw_double(float seconds)
    {
        Enemy3_Money.BetMoney();
        GameObject money_pack_1;
        money_pack_1 = Instantiate(money_pic, Enemy3_Money.transform.position, Enemy3_Money.transform.rotation);
        float elapsedTime = 0;

        Vector3 startingPos = money_pack_1.gameObject.transform.position;
        Vector3 endPos;

        AudioSource.PlayClipAtPoint(Double_Sound, Camera.main.transform.position);


            endPos = money_pack_1.gameObject.transform.position + new Vector3(8.00f, 7f, 0);

        while (elapsedTime < seconds)
        {
            money_pack_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Enemy3_Money.BetMoney();
        GameObject money_pack_2;
        money_pack_2 = Instantiate(money_pic, Enemy3_Money.transform.position, Enemy3_Money.transform.rotation);
        float elapsedTime_2 = 0;

        Vector3 startingPos_2 = money_pack_2.gameObject.transform.position;
        Vector3 endPos_2;


            endPos_2 = money_pack_2.gameObject.transform.position + new Vector3(9.85f, 6.75f, 0);

        while (elapsedTime_2 < seconds)
        {
            money_pack_2.gameObject.transform.position = Vector3.Lerp(startingPos_2, endPos_2, elapsedTime_2 / seconds);
            elapsedTime_2 += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        bet = bet * 2;
        update_betting_price();

        yield return null;
    }

    public IEnumerator Check_Winner()
    {
        yield return new WaitForSeconds(3f);

        GameObject[] moneydelete = GameObject.FindGameObjectsWithTag("money");
        for (int i = 0; i < moneydelete.Length; i++)
        {
            Destroy(moneydelete[i]);
        }


        GameObject card_1;

        if (active[1] == true)
        {
            Vector3 new_position = new Vector3(GameObject.Find("Card-Secret-Enemy1-2(Clone)").gameObject.transform.position.x,
                                        GameObject.Find("Card-Secret-Enemy1-2(Clone)").gameObject.transform.position.y,
                                        GameObject.Find("Card-Secret-Enemy1-2(Clone)").gameObject.transform.position.z);

            card_1 = Instantiate(deck_info.Card_Deck[Enemy1.Card_2 - 1], new_position, transform.rotation) as GameObject;
        }

        if (active[2] == true)
        {
            Vector3 new_position_2 = new Vector3(GameObject.Find("Card-Secret-Enemy1-4(Clone)").gameObject.transform.position.x,
                                GameObject.Find("Card-Secret-Enemy1-4(Clone)").gameObject.transform.position.y,
                                GameObject.Find("Card-Secret-Enemy1-4(Clone)").gameObject.transform.position.z);

            card_1 = Instantiate(deck_info.Card_Deck[Enemy2.Card_2 - 1], new_position_2, transform.rotation) as GameObject;
        }

        if(active[3] == true)
        {
            Vector3 new_position_3 = new Vector3(GameObject.Find("Card-Secret-Enemy1-6(Clone)").gameObject.transform.position.x,
                                GameObject.Find("Card-Secret-Enemy1-6(Clone)").gameObject.transform.position.y,
                                GameObject.Find("Card-Secret-Enemy1-6(Clone)").gameObject.transform.position.z);

            card_1 = Instantiate(deck_info.Card_Deck[Enemy3.Card_2 - 1], new_position_3, transform.rotation) as GameObject;
        }



        if (how_many_survive == 1)
        {
            if(active[0] == true)
            {
                winner = 1;
                Player_Money.money += total_money_this_pan;
                Player_Money.money_UI.text = Player_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();
            }

            else if(active[1] == true)
            {
                winner = 2;
                Enemy1_Money.money += total_money_this_pan;
                Enemy1_Money.money_UI.text = Enemy1_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();
            }

            else if(active[2] == true)
            {
                winner = 3;
                Enemy2_Money.money += total_money_this_pan;
                Enemy2_Money.money_UI.text = Enemy2_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();
            }

            else if(active[3] == true)
            {
                winner = 4;
                Enemy3_Money.money += total_money_this_pan;
                Enemy3_Money.money_UI.text = Enemy3_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();
            }
        }

        else
        {
            int current_rank = 99;

            if(active[0] == true)
            {
                if(Player.Rank < current_rank)
                {
                    current_rank = Player.Rank;
                    winner = 1;
                }
            }

            if(active[1] == true)
            {
                if(Enemy1.Rank < current_rank)
                {
                    current_rank = Enemy1.Rank;
                    winner = 2;
                }
            }
            
            if(active[2] == true)
            {
                if(Enemy2.Rank < current_rank)
                {
                    current_rank = Enemy2.Rank;
                    winner = 3;
                }
            }

            if(active[3] == true)
            {
                if(Enemy3.Rank < current_rank)
                {
                    current_rank = Enemy3.Rank;
                    winner = 4;
                }
            }


            if(winner == 1)
            {
                Player_Money.money += total_money_this_pan;
                Player_Money.money_UI.text = Player_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();
            }

            else if(winner == 2)
            {
                Enemy1_Money.money += total_money_this_pan;
                Enemy1_Money.money_UI.text = Enemy1_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();

            }
            else if(winner == 3)
            {
                Enemy2_Money.money += total_money_this_pan;
                Enemy2_Money.money_UI.text = Enemy2_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();

            }
            else if(winner == 4)
            {
                Enemy3_Money.money += total_money_this_pan;
                Enemy3_Money.money_UI.text = Enemy3_Money.money.ToString();
                total_money_this_pan = 0;
                update_total_price();
            }
        }

        yield return new WaitForSeconds(10f);

        Destroy(GameObject.Find("Card-Secret-Enemy1-2(Clone)"));
        Destroy(GameObject.Find("Card-Secret-Enemy1-4(Clone)"));
        Destroy(GameObject.Find("Card-Secret-Enemy1-6(Clone)"));


        GameObject[] card_delete = GameObject.FindGameObjectsWithTag("cards");
        
        for (int i = 0; i < card_delete.Length; i++)
        {
            Destroy(card_delete[i]);
        }

        
        card1UI.UpdatePicture_2();
        card2UI.UpdatePicture_2();
        ranking_card.UpdateText_2();
        ranking_comb.UpdatText_2();
        
        bet = 100;
        update_betting_price();


        deck_info.Card_Number.Clear();
        for(int i = 0; i < 20; i++)
        {
            deck_info.Card_Number.Add(i + 1);
        }
        yield return Start_Game();
    }


    public void status_refresh()
    {
        for(int i = 0; i < 4; i++)
        {
            if(active[i] == true)
            {
                continue;
            }

            else
            {
                if(i == 0)
                {
                    if(Player_Money.money >= 0)
                    {
                        how_many_survive = how_many_survive + 1;

                        active[i] = true;
                    }
                }

                else if(i == 1)
                {
                    if(Enemy1_Money.money >= 0)
                    {
                        active[i] = true;
                        how_many_survive++;
                    }
                }

                else if(i == 2)
                {
                    if(Enemy2_Money.money >= 0)
                    {
                        active[i] = true;
                        how_many_survive++;
                    }
                }

                else if(i == 3)
                {
                    if(Enemy3_Money.money >= 0)
                    {
                        active[i] = true;
                        how_many_survive++;
                    }
                }
            }
        }
    }

    public void PickRotation()
    {
        if(winner == 4)
        {
            StartCoroutine(deck_info.Rotation_1());
        }

        else if(winner == 1)
        {
            StartCoroutine(deck_info.Rotation_2());
        }

        else if(winner == 2)
        {
            StartCoroutine(deck_info.Rotation_3());
        }

        else if(winner == 3)
        {
            StartCoroutine(deck_info.Rotation_4());
        }
            
    }

        /*
        while(Player_Money.money > 0)
        {
            Debug.Log("Hello");
        }*/

        //GameOverContainer.SetActive(true);
    }

    /*
    public void startgame()
    {
        StartCoroutine(Enemy_Decision());
    }

    public IEnumerator Enemy_Decision()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(Enemy_1_Decision());
        yield return new WaitForSeconds(3f);
        StartCoroutine(Enemy_2_Decision());
        yield return new WaitForSeconds(3f);
        StartCoroutine(Enemy_3_Decision());
        //yield return new WaitForSeconds(3f);
        StartCoroutine(Determine_Winner());
        //StartCoroutine(OpenCard());
        yield return new WaitForSeconds(3f);
        StartCoroutine(GameOver());

    }

    public IEnumerator GameOver()
    {
        if(winner == 1)
            GameOverContainer.GetComponentInChildren<Text>().text = "You win the game";
        else if(winner == 2)
            GameOverContainer.GetComponentInChildren<Text>().text = "Enemy1 win the game";
        else if (winner == 3)
            GameOverContainer.GetComponentInChildren<Text>().text = "Enemy2 win the game";
        else if (winner == 4)
            GameOverContainer.GetComponentInChildren<Text>().text = "Enemy3 win the game";


        GameOverContainer.SetActive(true);
        yield return null;
    }

    public IEnumerator Determine_Winner()
    {
        //yield return new WaitForSeconds(f);
        if (player_decision == 1 && enemy_1_decision == 0 && enemy_2_decision == 0 && enemy_3_decision == 0)
            max = 1;
        else if (player_decision == 0 && enemy_1_decision == 1 && enemy_2_decision == 0 && enemy_3_decision == 0)
            max = 2;
        else if (player_decision == 0 && enemy_1_decision == 0 && enemy_2_decision == 1 && enemy_3_decision == 0)
            max = 3;
        else if (player_decision == 0 && enemy_1_decision == 0 && enemy_2_decision == 0 && enemy_3_decision == 1)
            max = 4;
        else
        {
            int max_rank = 30;

            if (player_decision == 1)
            {
                if (max_rank > Player.Rank)
                {
                    max = 1;
                    max_rank = Player.Rank;
                }
            }

            if (enemy_1_decision == 1)
            {
                if (max_rank > Enemy1.Rank)
                {
                    max = 2;
                    max_rank = Enemy1.Rank;
                }
            }

            if(enemy_2_decision == 1)
            {
                if(max_rank > Enemy2.Rank)
                {
                    max = 3;
                    max_rank = Enemy2.Rank;
                }
            }

            if(enemy_3_decision == 1)
            {
                if(max_rank > Enemy3.Rank)
                {
                    max = 4;
                    max_rank = Enemy3.Rank;
                }
            }
        }

        winner = max;

        yield return new WaitForSeconds(1f);
    }

    public IEnumerator OpenCard()
    {
        opencard1.Open_Card();
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Enemy_1_Decision()
    {
        if(Enemy1.decision == 1)
        {
            enemy_1_decision = 1;
            Vector3 new_position = new Vector3(GameObject.Find("Go-Button-Enemy-1").gameObject.transform.position.x,
                                    GameObject.Find("Go-Button-Enemy-1").gameObject.transform.position.y,
                                    GameObject.Find("Go-Button-Enemy-1").gameObject.transform.position.z + 100);
            GameObject.Find("Go-Button-Enemy-1").gameObject.transform.position = new_position;

        }

        else
        {
            enemy_1_decision = 0;
            Vector3 new_position = new Vector3(GameObject.Find("Stop-Button-Enemy-1").gameObject.transform.position.x,
                        GameObject.Find("Stop-Button-Enemy-1").gameObject.transform.position.y,
                        GameObject.Find("Stop-Button-Enemy-1").gameObject.transform.position.z + 100);
            GameObject.Find("Stop-Button-Enemy-1").gameObject.transform.position = new_position;
        }

        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Enemy_2_Decision()
    {
        if (Enemy2.decision == 1)
        {
            enemy_2_decision = 1;
            Vector3 new_position = new Vector3(GameObject.Find("Go-Button-Enemy-2").gameObject.transform.position.x,
                        GameObject.Find("Go-Button-Enemy-2").gameObject.transform.position.y,
                        GameObject.Find("Go-Button-Enemy-2").gameObject.transform.position.z + 100);
            GameObject.Find("Go-Button-Enemy-2").gameObject.transform.position = new_position;
        }

        else
        {
            enemy_2_decision = 0;
            Vector3 new_position = new Vector3(GameObject.Find("Stop-Button-Enemy-2").gameObject.transform.position.x,
                                                GameObject.Find("Stop-Button-Enemy-2").gameObject.transform.position.y,
                                                GameObject.Find("Stop-Button-Enemy-2").gameObject.transform.position.z + 100);
            GameObject.Find("Stop-Button-Enemy-2").gameObject.transform.position = new_position;
        }

        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Enemy_3_Decision()
    {
        if (player_decision == 0 && enemy_1_decision == 0 && enemy_2_decision == 0)
        {
            enemy_3_decision = 1;
            Vector3 new_position = new Vector3(GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position.x,
                        GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position.y,
                        GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position.z + 100);
            GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position = new_position;
        }

        else if (Enemy3.decision == 1)
        {
            enemy_3_decision = 1;
            Vector3 new_position = new Vector3(GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position.x,
                        GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position.y,
                        GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position.z + 100);
            GameObject.Find("Go-Button-Enemy-3").gameObject.transform.position = new_position;
        }

        else if (Enemy3.decision == 0)
        {
            enemy_3_decision = 0;
            Vector3 new_position = new Vector3(GameObject.Find("Stop-Button-Enemy-3").gameObject.transform.position.x,
                                                GameObject.Find("Stop-Button-Enemy-3").gameObject.transform.position.y,
                                                GameObject.Find("Stop-Button-Enemy-3").gameObject.transform.position.z + 100);
            GameObject.Find("Stop-Button-Enemy-3").gameObject.transform.position = new_position;
        }

        yield return new WaitForSeconds(1f);
    }
    
}*/
