using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour {

    public int Card_1;
    public int Card_2;
    public int Rank;
    public string rank_name;

	// Use this for initialization
	void Start () {
        Card_1 = 0;
        Card_2 = 0;
        Rank = 0;
        rank_name = " ";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Calc_Rank()
    {
        if ((Card_1 == 3 && Card_2 == 8) || (Card_1 == 8 && Card_2 == 3))
        {
            Rank = 1;
            rank_name = "3/8 Gwang Tang";
        }
        else if ((Card_1 == 1 && Card_2 == 8) || (Card_1 == 8 && Card_2 == 1))
        {
            Rank = 2;
            rank_name = "1/8 Gwang Tang";
        }
        else if ((Card_1 == 1 && Card_2 == 3) || (Card_1 == 3 && Card_2 == 1))
        {
            Rank = 3;
            rank_name = "1/3 Gwang Tang";
        }
        else if ((Card_1 == 10 && Card_2 == 20) || (Card_1 == 20 && Card_2 == 10))
        {
            Rank = 4;
            rank_name = "10 Tang";
        }
        else if ((Card_1 == 9 && Card_2 == 19) || (Card_1 == 19 && Card_2 == 9))
        {
            Rank = 5;
            rank_name = "9 Tang";
        }
        else if ((Card_1 == 8 && Card_2 == 18) || (Card_1 == 18 && Card_2 == 8))
        {
            Rank = 6;
            rank_name = "8 Tang";
        }
        else if ((Card_1 == 7 && Card_2 == 17) || (Card_1 == 17 && Card_2 == 7))
        {
            Rank = 7;
            rank_name = "7 Tang";
        }
        else if ((Card_1 == 6 && Card_2 == 16) || (Card_1 == 16 && Card_2 == 6))
        {
            Rank = 8;
            rank_name = "6 Tang";
        }
        else if ((Card_1 == 5 && Card_2 == 15) || (Card_1 == 15 && Card_2 == 5))
        {
            Rank = 9;
            rank_name = "5 Tang";
        }
        else if ((Card_1 == 4 && Card_2 == 14) || (Card_1 == 14 && Card_2 == 4))
        {
            Rank = 10;
            rank_name = "4 Tang";
        }
        else if ((Card_1 == 3 && Card_2 == 13) || (Card_1 == 13 && Card_2 == 3))
        {
            Rank = 11;
            rank_name = "3 Tang";
        }
        else if ((Card_1 == 2 && Card_2 == 12) || (Card_1 == 12 && Card_2 == 2))
        {
            Rank = 12;
            rank_name = "2 Tang";
        }
        else if ((Card_1 == 1 && Card_2 == 11) || (Card_1 == 11 && Card_2 == 1))
        {
            Rank = 13;
            rank_name = "1 Tang";
        }
        else if ((Card_1 == 1 && Card_2 == 2) || (Card_1 == 1 && Card_2 == 12) || (Card_1 == 11 && Card_2 == 2) || (Card_1 == 11 && Card_2 == 12) ||
                 (Card_1 == 2 && Card_2 == 1) || (Card_1 == 2 && Card_2 == 11) || (Card_1 == 12 && Card_2 == 1) || (Card_1 == 12 && Card_2 == 11))
        {
            Rank = 14;
            rank_name = "One/Two";
        }
        else if ((Card_1 == 1 && Card_2 == 4) || (Card_1 == 1 && Card_2 == 14) || (Card_1 == 11 && Card_2 == 4) || (Card_1 == 11 && Card_2 == 14) ||
                 (Card_1 == 4 && Card_2 == 1) || (Card_1 == 4 && Card_2 == 11) || (Card_1 == 14 && Card_2 == 1) || (Card_1 == 14 && Card_2 == 11))
        {
            Rank = 15;
            rank_name = "One/Four";
        }
        else if ((Card_1 == 1 && Card_2 == 9) || (Card_1 == 1 && Card_2 == 19) || (Card_1 == 11 && Card_2 == 9) || (Card_1 == 11 && Card_2 == 19) ||
                 (Card_1 == 9 && Card_2 == 1) || (Card_1 == 9 && Card_2 == 11) || (Card_1 == 19 && Card_2 == 1) || (Card_1 == 19 && Card_2 == 11))
        {
            Rank = 16;
            rank_name = "One/Nine";
        }
        else if ((Card_1 == 1 && Card_2 == 10) || (Card_1 == 1 && Card_2 == 20) || (Card_1 == 11 && Card_2 == 10) || (Card_1 == 11 && Card_2 == 20) ||
                 (Card_1 == 10 && Card_2 == 1) || (Card_1 == 10 && Card_2 == 11) || (Card_1 == 20 && Card_2 == 1) || (Card_1 == 20 && Card_2 == 11))
        {
            Rank = 17;
            rank_name = "One/Ten";
        }
        else if ((Card_1 == 4 && Card_2 == 10) || (Card_1 == 4 && Card_2 == 20) || (Card_1 == 14 && Card_2 == 10) || (Card_1 == 14 && Card_2 == 20) ||
                 (Card_1 == 10 && Card_2 == 4) || (Card_1 == 10 && Card_2 == 14) || (Card_1 == 20 && Card_2 == 4) || (Card_1 == 20 && Card_2 == 14))
        {
            Rank = 18;
            rank_name = "Four/Ten";
        }
        else if ((Card_1 == 4 && Card_2 == 6) || (Card_1 == 4 && Card_2 == 16) || (Card_1 == 14 && Card_2 == 6) || (Card_1 == 14 && Card_2 == 16) ||
                 (Card_1 == 6 && Card_2 == 4) || (Card_1 == 6 && Card_2 == 14) || (Card_1 == 16 && Card_2 == 4) || (Card_1 == 16 && Card_2 == 14))
        {
            Rank = 19;
            rank_name = "Four/Six";
        }

        else
        {
            int kket = (Card_1 + Card_2) % 10;

            switch (kket)
            {
                case 9:
                    Rank = 20;
                    rank_name = "9 Clutter";
                    break;
                case 8:
                    Rank = 21;
                    rank_name = "8 Clutter";
                    break;
                case 7:
                    Rank = 22;
                    rank_name = "7 Clutter";
                    break;
                case 6:
                    Rank = 23;
                    rank_name = "6 Clutter";
                    break;
                case 5:
                    Rank = 24;
                    rank_name = "5 Clutter";
                    break;
                case 4:
                    Rank = 25;
                    rank_name = "4 Clutter";
                    break;
                case 3:
                    Rank = 26;
                    rank_name = "3 Clutter";
                    break;
                case 2:
                    Rank = 27;
                    rank_name = "2 Clutter";
                    break;
                case 1:
                    Rank = 28;
                    rank_name = "1 Clutter";
                    break;
                case 0:
                    Rank = 29;
                    rank_name = "Empty Box";
                    break;
            }
        }
    }
}
