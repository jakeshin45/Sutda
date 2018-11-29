using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TEXT_UPDATE_1 : MonoBehaviour {

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
        instruction.text = PlayerStatus.rank_name.ToString();
    }

    public void UpdatText_2()
    {
        instruction.text = "";

    }
}
