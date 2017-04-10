using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    
    public Text value;
    int precipVal;
    public Button inc;
    public Button dec;
    public Button enter;

    
    
    void Start () {

        inc = GameObject.Find("increase").GetComponent<Button>();
        inc.onClick.AddListener(increaseValue);
        value = GameObject.Find("Inputs").GetComponent<Text>();
        dec = GameObject.Find("decrease").GetComponent<Button>();
        dec.onClick.AddListener(decreaseValue);
        enter = GameObject.Find("enter").GetComponent<Button>();
        enter.onClick.AddListener(compareValues);
       
        




    }
	
	
	void Update () {
        
        value.text = "Input: " + precipVal;
        
    }
    void increaseValue()
    {
        
        precipVal += 1;
        if(precipVal > 10)
        {
            precipVal = 10;
        }

    }
    void decreaseValue()
    {

        
        if (precipVal == 0)
        {
            precipVal -= 0;
        }else if(precipVal > 0)
        {
            precipVal -= 1;
        }

    }
    void compareValues() { 
        if (precipVal == WeatherController.n)
        {
            PlayerStats.ratings += 5;
        }else if (precipVal != WeatherController.n)
        {
            PlayerStats.ratings -= 5;
        }
    }
}
