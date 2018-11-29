using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour {

    public int Card_1;
    public int Card_2;
    public int Rank;
    public float judgement;
    public int decision; // 0: Double, 1: Call, 2: Die
    public GamePlay deck_info;

	// Use this for initialization
	void Start () {
        Card_1 = 0;
        Card_2 = 0;
        Rank = 0;
        judgement = Random.Range(0, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void update_judgement()
    {
        judgement = Random.Range(0, 1.0f);
    }

    public void Calc_Decision()
    {
        if (Rank == 1 || Rank == 2 || Rank == 3 || Rank == 4 || Rank == 5) // 38 Gwang TANG, 18 GWNAG TANG, 13 GWANG TANG, JANG TANG, 9 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    decision = 0;
                    break;
                case 2:
                    decision = 0;
                    break;
                case 3:
                    decision = 1;
                    break;
            }

        }
        else if (Rank == 6) // 8 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    decision = 0;
                    break;
                case 2:
                    if (judgement >= 0.05)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                decision = 1;
                    break;
            }
        }
        else if (Rank == 7) // 7 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    decision = 0;
                    break;
                case 2:
                    if (judgement >= 0.10)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 8) // 6 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.025)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.20)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 9) // 5 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.05)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.30)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 10) // 4 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.075)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.4)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 11) // 3 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.10)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.5)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 12) // 2 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.125)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.60)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 13) // 1 Tang
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.15)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.70)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 3:
                    decision = 1;
                    break;
            }
        }
        else if (Rank == 14) // ali
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.5)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.75)
                        decision = 0;
                    else if (judgement < 0.75 && judgement >= 0.05)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.05)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }
        else if (Rank == 15) // doksa
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.55)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.9)
                        decision = 0;
                    else if (judgement < 0.85 && judgement >= 0.05)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.07)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }
        else if (Rank == 16) // 9 bbing
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.6)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.95)
                        decision = 0;
                    else if (judgement < 0.95 && judgement >= 0.05)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.09)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }
        else if (Rank == 17) // jjang bbing
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.65)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.98)
                        decision = 0;
                    else if (judgement < 0.98 && judgement >= 0.08)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.11)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }
        else if (Rank == 18) // jang ssa
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.70)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.98)
                        decision = 0;
                    else if (judgement < 0.98 && judgement >= 0.08)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.13)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 19) // seryuk
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.75)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.99)
                        decision = 0;
                    else if (judgement < 0.99 && judgement >= 0.09)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.15)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 20) // kaboh
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.90)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.95)
                        decision = 0;
                    else if (judgement < 0.95 && judgement >= 0.05)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.20)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 21) // 8 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.91)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.96)
                        decision = 0;
                    else if (judgement < 0.96 && judgement >= 0.46)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.20)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 22) // 7 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.92)
                        decision = 0;
                    else
                        decision = 1;
                    break;
                case 2:
                    if (judgement >= 0.97)
                        decision = 0;
                    else if (judgement < 0.97 && judgement >= 0.52)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.50)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 23) // 6 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.92)
                        decision = 0;
                    else if (judgement < 0.92 && judgement >= 0.50)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.98)
                        decision = 0;
                    else if (judgement < 0.98 && judgement >= 0.58)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.60)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 24) // 5 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.94)
                        decision = 0;
                    else if (judgement < 0.94 && judgement >= 0.64)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.99)
                        decision = 0;
                    else if (judgement < 0.99 && judgement >= 0.64)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.70)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 25) // 4 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.95)
                        decision = 0;
                    else if (judgement < 0.95 && judgement >= 0.75)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.70)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.80)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 26) // 3 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.96)
                        decision = 0;
                    else if (judgement < 0.96 && judgement >= 0.86)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.75)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.90)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 27) // 2 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.97)
                        decision = 0;
                    else if (judgement < 0.97 && judgement >= 0.92)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.80)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    if (judgement >= 0.95)
                        decision = 1;
                    else
                        decision = 2;
                    break;
            }
        }

        else if (Rank == 28) // 1 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.98)
                        decision = 0;
                    else if (judgement < 0.98 && judgement >= 0.95)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.85)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    decision = 2;
                    break;
            }
        }

        else if (Rank == 29) // 0 clutter
        {
            switch (deck_info.round)
            {
                case 1:
                    if (judgement >= 0.99)
                        decision = 0;
                    else if (judgement < 0.99 && judgement >= 0.98)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 2:
                    if (judgement >= 0.90)
                        decision = 1;
                    else
                        decision = 2;
                    break;
                case 3:
                    decision = 2;
                    break;
            }
        }
    }

    public void Calc_Rank()
    {
        if ((Card_1 == 3 && Card_2 == 8) || (Card_1 == 8 && Card_2 == 3))
            Rank = 1;
        else if ((Card_1 == 1 && Card_2 == 8) || (Card_1 == 8 && Card_2 == 1))
            Rank = 2;
        else if ((Card_1 == 1 && Card_2 == 3) || (Card_1 == 3 && Card_2 == 1))
            Rank = 3;
        else if ((Card_1 == 10 && Card_2 == 20) || (Card_1 == 20 && Card_2 == 10))
            Rank = 4;
        else if ((Card_1 == 9 && Card_2 == 19) || (Card_1 == 19 && Card_2 == 9))
            Rank = 5;
        else if ((Card_1 == 8 && Card_2 == 18) || (Card_1 == 18 && Card_2 == 8))
            Rank = 6;
        else if ((Card_1 == 7 && Card_2 == 17) || (Card_1 == 17 && Card_2 == 7))
            Rank = 7;
        else if ((Card_1 == 6 && Card_2 == 16) || (Card_1 == 16 && Card_2 == 6))
            Rank = 8;
        else if ((Card_1 == 5 && Card_2 == 15) || (Card_1 == 15 && Card_2 == 5))
            Rank = 9;
        else if ((Card_1 == 4 && Card_2 == 14) || (Card_1 == 14 && Card_2 == 4))
            Rank = 10;
        else if ((Card_1 == 3 && Card_2 == 13) || (Card_1 == 13 && Card_2 == 3))
            Rank = 11;
        else if ((Card_1 == 2 && Card_2 == 12) || (Card_1 == 12 && Card_2 == 2))
            Rank = 12;
        else if ((Card_1 == 1 && Card_2 == 11) || (Card_1 == 11 && Card_2 == 1))
            Rank = 13;
        else if ((Card_1 == 1 && Card_2 == 2) || (Card_1 == 1 && Card_2 == 12) || (Card_1 == 11 && Card_2 == 2) || (Card_1 == 11 && Card_2 == 12) ||
                 (Card_1 == 2 && Card_2 == 1) || (Card_1 == 2 && Card_2 == 11) || (Card_1 == 12 && Card_2 == 1) || (Card_1 == 12 && Card_2 == 11))
            Rank = 14;
        else if ((Card_1 == 1 && Card_2 == 4) || (Card_1 == 1 && Card_2 == 14) || (Card_1 == 11 && Card_2 == 4) || (Card_1 == 11 && Card_2 == 14) ||
                 (Card_1 == 4 && Card_2 == 1) || (Card_1 == 4 && Card_2 == 11) || (Card_1 == 14 && Card_2 == 1) || (Card_1 == 14 && Card_2 == 11))
            Rank = 15;
        else if ((Card_1 == 1 && Card_2 == 9) || (Card_1 == 1 && Card_2 == 19) || (Card_1 == 11 && Card_2 == 9) || (Card_1 == 11 && Card_2 == 19) ||
                 (Card_1 == 9 && Card_2 == 1) || (Card_1 == 9 && Card_2 == 11) || (Card_1 == 19 && Card_2 == 1) || (Card_1 == 19 && Card_2 == 11))
            Rank = 16;
        else if ((Card_1 == 1 && Card_2 == 10) || (Card_1 == 1 && Card_2 == 20) || (Card_1 == 11 && Card_2 == 10) || (Card_1 == 11 && Card_2 == 20) ||
                 (Card_1 == 10 && Card_2 == 1) || (Card_1 == 10 && Card_2 == 11) || (Card_1 == 20 && Card_2 == 1) || (Card_1 == 20 && Card_2 == 11))
            Rank = 17;
        else if ((Card_1 == 4 && Card_2 == 10) || (Card_1 == 4 && Card_2 == 20) || (Card_1 == 14 && Card_2 == 10) || (Card_1 == 14 && Card_2 == 20) ||
                 (Card_1 == 10 && Card_2 == 4) || (Card_1 == 10 && Card_2 == 14) || (Card_1 == 20 && Card_2 == 4) || (Card_1 == 20 && Card_2 == 14))
            Rank = 18;
        else if ((Card_1 == 4 && Card_2 == 6) || (Card_1 == 4 && Card_2 == 16) || (Card_1 == 14 && Card_2 == 6) || (Card_1 == 14 && Card_2 == 16) ||
                 (Card_1 == 6 && Card_2 == 4) || (Card_1 == 6 && Card_2 == 14) || (Card_1 == 16 && Card_2 == 4) || (Card_1 == 16 && Card_2 == 14))
            Rank = 19;
        else if ((Card_1 == 4 && Card_2 == 9) || (Card_1 == 4 && Card_2 == 19) || (Card_1 == 14 && Card_2 == 9) || (Card_1 == 14 && Card_2 == 19) ||
                 (Card_1 == 9 && Card_2 == 4) || (Card_1 == 9 && Card_2 == 14) || (Card_1 == 19 && Card_2 == 4) || (Card_1 == 19 && Card_2 == 14))
            Rank = 0;
        else
        {
            int kket = (Card_1 + Card_2) % 10;

            switch (kket)
            {
                case 9:
                    Rank = 20;
                    break;
                case 8:
                    Rank = 21;
                    break;
                case 7:
                    Rank = 22;
                    break;
                case 6:
                    Rank = 23;
                    break;
                case 5:
                    Rank = 24;
                    break;
                case 4:
                    Rank = 25;
                    break;
                case 3:
                    Rank = 26;
                    break;
                case 2:
                    Rank = 27;
                    break;
                case 1:
                    Rank = 28;
                    break;
                case 0:
                    Rank = 29;
                    break;
            }
        }
    }
}
