using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCard_1 : MonoBehaviour {

    public List<GameObject> Card_Deck = new List<GameObject>();
    public Enemy_Status enemy;
    public int card_number;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("GoGwangRyul").GetComponent<Enemy_Status>();
    }

    public void Open_Card()
    {
        GameObject card_1;
        card_number = enemy.Card_1;
        card_1 = Instantiate(Card_Deck[enemy.Card_1 - 1], transform.position, transform.rotation) as GameObject;
        card_1.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
}
