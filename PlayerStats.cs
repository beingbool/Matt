using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

    public int insightlevel;
    public Text TVratings;
    public static int ratings = 100;
    
    public int Precip;
	void Start () {
        insightlevel = 4;
        
        
        TVratings = GameObject.Find("ratings").GetComponent<Text>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        
        TVratings.text = "Ratings: " + ratings;
	}
}
