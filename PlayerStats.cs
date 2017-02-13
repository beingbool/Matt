using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    public int insightlevel;
    public Text TVratings;
    public Text cash;
    public static int ratings = 0;
    public static int money = 0;
    
    public int Precip;
	void Start () {
        insightlevel = 3;

        cash = GameObject.Find("money").GetComponent<Text>();
        TVratings = GameObject.Find("ratings").GetComponent<Text>();

        Debug.Log(insightlevel);
	}
	
	// Update is called once per frame
	void Update () {
        
        TVratings.text = "Ratings: " + ratings;
        cash.text = "Money: " + money;
	}
}
