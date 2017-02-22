using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class upgradeScript : MonoBehaviour {
    public Button ratingUgr;
    public Button insightUgr;
	void Start () {
        ratingUgr = GameObject.Find("ratingsUpgrade").GetComponent<Button>();
        ratingUgr.onClick.AddListener(ratingIncrease);
        insightUgr = GameObject.Find("insightUgr").GetComponent<Button>();
        insightUgr.onClick.AddListener(insightInc);
       

    }
	
	
	void Update () {
        if (PlayerStats.money < 1000)
        {
            ratingUgr.interactable = false;
        }else if(PlayerStats.money >= 1000) { 
            ratingUgr.interactable = true;
    }

		if(PlayerStats.money < 2500)
        {
            insightUgr.interactable = false;
        }else if (PlayerStats.money >= 2500)
        {
            insightUgr.interactable = true;
        }
	}
    void ratingIncrease()
    {
        PlayerStats.money -= 1000;
        PlayerStats.ratings += 100;
    }
    void insightInc()
    {
        PlayerStats.insightlevel += 1;
        PlayerStats.money -= 2500;
    }
}
