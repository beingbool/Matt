using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class upgradeScript : MonoBehaviour {
    public Button ratingUgr;
	void Start () {
        ratingUgr = GameObject.Find("ratingsUpgrade").GetComponent<Button>();
        ratingUgr.onClick.AddListener(ratingIncrease);
    }
	
	
	void Update () {
        if (PlayerStats.money < 1000)
        {
            ratingUgr.interactable = false;
        }else if(PlayerStats.money >= 1000) { 
            ratingUgr.interactable = true;
    }
		
	}
    void ratingIncrease()
    {
        PlayerStats.money -= 1000;
        PlayerStats.ratings += 100;
    }
}
