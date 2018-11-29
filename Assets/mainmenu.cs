using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainmenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Button").GetComponent<Button>().onClick.AddListener(click);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void click()
    {
        SceneManager.LoadScene("main");
    }
}
