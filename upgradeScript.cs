using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class upgradeScript : MonoBehaviour {
    public Button ratingUgr;
    public Button insightUgr;
    public Text ugrText;
    public string insightText;
    public Text ugrMon;
    public Button staffU1;
	void Start () {
        ratingUgr = GameObject.Find("ratingsUpgrade").GetComponent<Button>();
        ratingUgr.onClick.AddListener(ratingIncrease);
        insightUgr = GameObject.Find("insightUgr").GetComponent<Button>();
        insightUgr.onClick.AddListener(insightInc);
        ugrText = insightUgr.GetComponentInChildren<Text>();
        ugrMon = GameObject.Find("ugrCash").GetComponent<Text>();
        staffU1 = GameObject.Find("staffU1").GetComponent<Button>();
        staffU1.onClick.AddListener(staffUpgrade1);

    }
	
	
	void Update () {
        if (PlayerStats.money < 1000)
        {
            ratingUgr.interactable = false;
        }else if(PlayerStats.money >= 1000) { 
            ratingUgr.interactable = true;
    }
        if(PlayerStats.money < 1000)
        {
            staffU1.interactable = false;
        }else
        {
            staffU1.interactable = true;
        }
        insightUpgrades();
        ugrText.text = insightText;
        ugrMon.text = "Money: " + "$" +PlayerStats.money;

	}
    void ratingIncrease()
    {
        PlayerStats.money -= 1000;
        PlayerStats.ratings += 100;
    }
    void insightInc()
    {
        
        if (PlayerStats.insightlevel == 1)
        {
            PlayerStats.money -= 2500;
        }else if(PlayerStats.insightlevel == 2)
        {
            PlayerStats.money -= 5000;
        }
        else if (PlayerStats.insightlevel == 3)
        {
            PlayerStats.money -= 10000;
        }
        else if (PlayerStats.insightlevel == 4)
        {
            PlayerStats.money -= 20000;
        }
        PlayerStats.insightlevel += 1;
    }
    void insightUpgrades()
    {
        if (PlayerStats.insightlevel == 1)
        {
            if (PlayerStats.money < 2500)
            {
                insightUgr.interactable = false;
                insightText = "Upgrade Insight Lvl \n Cost: 2500";

            }
            else if (PlayerStats.money >= 2500)
            {
                insightUgr.interactable = true;
                insightText = "Upgrade Insight Lvl \n Cost: 2500";
            }
        }
        else if (PlayerStats.insightlevel == 2)
        {
            if (PlayerStats.money < 5000)
            {
                insightUgr.interactable = false;
                insightText = "Upgrade Insight Lvl \n Cost: 5000";
            }
            else if (PlayerStats.money >= 5000)
            {
                insightUgr.interactable = true;
                insightText = "Upgrade Insight Lvl \n Cost: 5000";
            }
        }
        else if (PlayerStats.insightlevel == 3)
        {
            if (PlayerStats.money < 10000)
            {
                insightUgr.interactable = false;
                insightText = "Upgrade Insight Lvl \n Cost: 10000";
            }
            else if (PlayerStats.money >= 5000)
            {
                insightUgr.interactable = true;
                insightText = "Upgrade Insight Lvl \n Cost: 10000";
            }
        }
        else if (PlayerStats.insightlevel == 4)
        {
            if (PlayerStats.money < 20000)
            {
                insightUgr.interactable = false;
                insightText = "Upgrade Insight Lvl \n Cost: 20000";
            }
            else if (PlayerStats.money >= 20000)
            {
                insightUgr.interactable = true;
                insightText = "Upgrade Insight Lvl \n Cost: 20000";
            }
        }
        if (PlayerStats.insightlevel > 4)
        {
            insightUgr.interactable = false;
            insightText = "Insight Level too high";

        }
    }
    void staffUpgrade1()
    {
        PlayerStats.staffApproval += 1;
        PlayerStats.money -= 1000;
    }
}
