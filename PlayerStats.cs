using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    public static int insightlevel = 3;
    public Text TVratings;
    public Text cash;
    public static int ratings = 0;
    public static int money = 2500;
    public Text turn;
    public static int turns = 1;
    public static int staffApproval = 50;
    public Text approval;
    
    public int Precip;
	void Start () {
        
        

        cash = GameObject.Find("money").GetComponent<Text>();
        TVratings = GameObject.Find("ratings").GetComponent<Text>();
        turn = GameObject.Find("turns").GetComponent<Text>();
        approval = GameObject.Find("staffapproval").GetComponent <Text>();
        
	}
	
	
	void Update () {
        
        TVratings.text = "Ratings: " + ratings;
        cash.text = "Money: " + " $"+money;
        turn.text = "Turn: " + turns;
        approval.text = "Staff Aprroval: " + staffApproval;
        
	}
}
