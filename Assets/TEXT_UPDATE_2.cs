using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEXT_UPDATE_2 : MonoBehaviour {

    public status PlayerStatus;
    Text instruction;
    // Use this for initialization
    void Start()
    {
        instruction = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText()
    {
        instruction.text = instruction.text + PlayerStatus.Rank.ToString() + "/29";
    }

    public void UpdateText_2()
    {
        instruction.text = "Your Card Rank: ";
    }
}

