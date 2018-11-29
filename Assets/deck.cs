using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour {

    public status Player;
    public Enemy_Status Enemy_1;
    public Enemy_Status Enemy_2;
    public Enemy_Status Enemy_3;
    
    public UI_Card_1 card1_UI;
    public UI_Card_2 card2_UI;
    public TEXT_UPDATE_1 text1_UI;
    public TEXT_UPDATE_2 text2_UI;
    public Go_Button button1;
    public Stop_Button button2;

    public List<GameObject> Card_Deck = new List<GameObject>();
    public List<GameObject> Secret_Deck = new List<GameObject>();

    public GamePlay gaming;
    
    public List<int> Card_Number = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    
    // Use this for initialization
    void Start() {
        //Distribute_Number();
        //StartCoroutine(Rotation_1());


    }

    // Update is called once per frame
    void Update() {

    }

    public void Distribute_Number()
    {
        int randomIndex = Random.Range(0, Card_Number.Count);
        Player.Card_1 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);
        
        randomIndex = Random.Range(0, Card_Number.Count);
        Enemy_1.Card_1 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);

        randomIndex = Random.Range(0, Card_Number.Count);
        Enemy_2.Card_1 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);

        randomIndex = Random.Range(0, Card_Number.Count);
        Enemy_3.Card_1 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);
        
        randomIndex = Random.Range(0, Card_Number.Count);
        Player.Card_2 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);
        
        randomIndex = Random.Range(0, Card_Number.Count);
        Enemy_1.Card_2 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);

        randomIndex = Random.Range(0, Card_Number.Count);
        Enemy_2.Card_2 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);

        randomIndex = Random.Range(0, Card_Number.Count);
        Enemy_3.Card_2 = Card_Number[randomIndex];
        Card_Number.RemoveAt(randomIndex);
        
        Calculate_Rank();
    }

    public void Calculate_Rank()
    {
        Player.Calc_Rank();
        Enemy_1.Calc_Rank();
        Enemy_2.Calc_Rank();
        Enemy_3.Calc_Rank();
    }
    
    public IEnumerator Generate_Player_First_Card()
    {
        GameObject card_1;
        card_1 = Instantiate(Card_Deck[Player.Card_1 - 1], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_player_first(1, card_1));
        yield return new WaitForSeconds(1f);
    }
    
    public IEnumerator move_to_player_first(float seconds, GameObject card_1)
    {
        float elapsedTime = 0;
        Vector3 startingPos = card_1.gameObject.transform.position;
        Vector3 endPos = card_1.gameObject.transform.position + new Vector3(4.05f, -8.49f, 0);
        while (elapsedTime < seconds)
        {
            card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        card_1.gameObject.transform.position = endPos;
        card1_UI.UpdatePicture();
    }

    public IEnumerator Generate_Enemy_One_First_Card()
    {
        GameObject enemy_card_1;
        enemy_card_1 = Instantiate(Card_Deck[Enemy_1.Card_1 - 1], transform.position, transform.rotation) as GameObject;
        //enemy_card_1 = Instantiate(Secret_Deck[0], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_enemy_one_first(1, enemy_card_1));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_enemy_one_first(float seconds, GameObject enemy_card_1)
    {
       // yield return new WaitForSeconds(1f);
        float elapsedTime = 0;
        Vector3 startingPos = enemy_card_1.gameObject.transform.position;
        Vector3 endPos = enemy_card_1.gameObject.transform.position + new Vector3(4.05f, 8.49f, 0);
        while (elapsedTime < seconds)
        {
            enemy_card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enemy_card_1.gameObject.transform.position = endPos;

    }

    public IEnumerator Generate_Enemy_Second_First_Card()
    {
        GameObject enemy_card_1;
        //enemy_card_1 = Instantiate(Secret_Deck[2], transform.position, transform.rotation) as GameObject;
        enemy_card_1 = Instantiate(Card_Deck[Enemy_2.Card_1 - 1], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_enemy_two_first(1, enemy_card_1));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_enemy_two_first(float seconds, GameObject enemy_card_1)
    {
       // yield return new WaitForSeconds(2f);
        float elapsedTime = 0;
        Vector3 startingPos = enemy_card_1.gameObject.transform.position;
        Vector3 endPos = enemy_card_1.gameObject.transform.position + new Vector3(-6.61f, 8.49f, 0);
        while (elapsedTime < seconds)
        {
            enemy_card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enemy_card_1.gameObject.transform.position = endPos;
    }

    public IEnumerator Generate_Enemy_Third_First_Card()
    {
        GameObject enemy_card_1;
        //enemy_card_1 = Instantiate(Secret_Deck[4], transform.position, transform.rotation) as GameObject;
        enemy_card_1 = Instantiate(Card_Deck[Enemy_3.Card_1 - 1], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_enemy_three_first(1, enemy_card_1));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_enemy_three_first(float seconds, GameObject enemy_card_1)
    {
       // yield return new WaitForSeconds(3f);
        float elapsedTime = 0;
        Vector3 startingPos = enemy_card_1.gameObject.transform.position;
        Vector3 endPos = enemy_card_1.gameObject.transform.position + new Vector3(-6.61f, -8.49f, 0);
        while (elapsedTime < seconds)
        {
            enemy_card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enemy_card_1.gameObject.transform.position = endPos;
    }

    public IEnumerator Generate_Player_Second_Card()
    {
        GameObject card_2;
        card_2 = Instantiate(Card_Deck[Player.Card_2 - 1], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_player_second(1, card_2));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_player_second(float seconds, GameObject card_2)
    {
        float elapsedTime = 0;
        Vector3 startingPos = card_2.gameObject.transform.position;
        Vector3 endPos = card_2.gameObject.transform.position + new Vector3(7.4f, -8.49f, 0);
        while (elapsedTime < seconds)
        {
            card_2.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        card_2.gameObject.transform.position = endPos;
        card2_UI.UpdatePicture();
        text1_UI.UpdateText();
        text2_UI.UpdateText();
        
    }

    public IEnumerator Generate_Enemy_One_Second_Card()
    {
        GameObject enemy_card_1;
        enemy_card_1 = Instantiate(Secret_Deck[1], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_enemy_one_second(1, enemy_card_1));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_enemy_one_second(float seconds, GameObject enemy_card_1)
    {
        // yield return new WaitForSeconds(1f);
        float elapsedTime = 0;
        Vector3 startingPos = enemy_card_1.gameObject.transform.position;
        Vector3 endPos = enemy_card_1.gameObject.transform.position + new Vector3(7.4f, 8.49f, 0);
        while (elapsedTime < seconds)
        {
            enemy_card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enemy_card_1.gameObject.transform.position = endPos;
    }

    public IEnumerator Generate_Enemy_Second_Second_Card()
    {
        GameObject enemy_card_1;
        enemy_card_1 = Instantiate(Secret_Deck[3], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_enemy_two_second(1, enemy_card_1));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_enemy_two_second(float seconds, GameObject enemy_card_1)
    {
        // yield return new WaitForSeconds(2f);
        float elapsedTime = 0;
        Vector3 startingPos = enemy_card_1.gameObject.transform.position;
        Vector3 endPos = enemy_card_1.gameObject.transform.position + new Vector3(-3.2f, 8.49f, 0);
        while (elapsedTime < seconds)
        {
            enemy_card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enemy_card_1.gameObject.transform.position = endPos;
    }

    public IEnumerator Generate_Enemy_Third_Second_Card()
    {
        GameObject enemy_card_1;
        enemy_card_1 = Instantiate(Secret_Deck[5], transform.position, transform.rotation) as GameObject;
        StartCoroutine(move_to_enemy_three_second(1, enemy_card_1));
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator move_to_enemy_three_second(float seconds, GameObject enemy_card_1)
    {
        // yield return new WaitForSeconds(3f);
        float elapsedTime = 0;
        Vector3 startingPos = enemy_card_1.gameObject.transform.position;
        Vector3 endPos = enemy_card_1.gameObject.transform.position + new Vector3(-3.2f, -8.49f, 0);
        while (elapsedTime < seconds)
        {
            enemy_card_1.gameObject.transform.position = Vector3.Lerp(startingPos, endPos, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enemy_card_1.gameObject.transform.position = endPos;
    }

    public IEnumerator Rotation_1() // Player - Enemy1 - Enemy2 - Enemy3
    {
        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if(gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_Second_Card());
            yield return new WaitForSeconds(1f);
        }
        //button1.change_button_status();
        //button2.change_button_status();

        /*
        Enemy_1.Calc_Decision();
        Enemy_2.Calc_Decision();
        Enemy_3.Calc_Decision();*/

    }

    public IEnumerator Rotation_2() // Enemy1 - Enemy2 - Enemy3 - Player
    {



        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_Second_Card());
            yield return new WaitForSeconds(1f);
        }
        /*
        Enemy_1.Calc_Decision();
        Enemy_2.Calc_Decision();
        Enemy_3.Calc_Decision();
        */
    }

    public IEnumerator Rotation_3() // Enemy2 - Enemy3 - Player - Enemy1
    {


        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[3] == true)
        {

            StartCoroutine(Generate_Enemy_Third_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        /*
        Enemy_1.Calc_Decision();
        Enemy_2.Calc_Decision();
        Enemy_3.Calc_Decision();
        */

    }

    public IEnumerator Rotation_4() // Enemy3 - Player - Enemy1 - Enemy2
    {

        if (gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_First_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[3] == true)
        {
            StartCoroutine(Generate_Enemy_Third_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[0] == true)
        {
            StartCoroutine(Generate_Player_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[1] == true)
        {
            StartCoroutine(Generate_Enemy_One_Second_Card());
            yield return new WaitForSeconds(1f);
        }

        if (gaming.active[2] == true)
        {
            StartCoroutine(Generate_Enemy_Second_Second_Card());
            yield return new WaitForSeconds(1f);
        }









        /*
        Enemy_1.Calc_Decision();
        Enemy_2.Calc_Decision();
        Enemy_3.Calc_Decision();
        */
    }

}
