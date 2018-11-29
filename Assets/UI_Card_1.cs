using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Card_1 : MonoBehaviour {

    Image myImageComponent;
    public status PlayerStatus;
    public List<Sprite> Sprites = new List<Sprite>();

	// Use this for initialization
	void Start () {
        myImageComponent = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePicture()
    {
        //GameObject.Find("CardUI1").GetComponentInChildren<Image>().sprite = TempCard;
        myImageComponent.sprite = Sprites[PlayerStatus.Card_1 - 1];
        myImageComponent.color = new Color(myImageComponent.color.r, myImageComponent.color.g, myImageComponent.color.b, 1f);
    }

    public void UpdatePicture_2()
    {
        myImageComponent.sprite = null;
        myImageComponent.color = new Color(myImageComponent.color.r, myImageComponent.color.g, myImageComponent.color.b, 1f);
    }
}
