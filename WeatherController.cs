using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeatherController : MonoBehaviour {

    public Text currentWeather;
    public string precip;
    public int s;
    

    public Text value;// this line and below are for buttons
    int precipVal;
    public Button inc;
    public Button dec;
    public Button enter;
    bool inRange;
    public Button next;

    public int w; //random value for the wind
    public int windGint; // number for the wind that the player will guess 
    public Text currentWind;
    public Text playerWind;
    public Button none;
    public Button lo;
    public Button med;
    public Button high;
    public Text plusCash;
    public int plusMoney;
    public int windMoney;
    public int totalPlus;
    public bool varCounter1, varCounter2;

    public static int n;
    public int r1;
    public int r2;
    int i;
    
    
    public int a;
    
    
        void Start() {
        varCounter1 = false;
        varCounter2 = false;
        
        i = PlayerStats.insightlevel;


        plusCash = GameObject.Find("plusCash").GetComponent<Text>();
        currentWeather = GameObject.Find("weather").GetComponent<Text>();
        playerWind = GameObject.Find("windGuess").GetComponent<Text>();
        n = precipitation();
        w = windy();

        precip = r1 + "-" + r2;// range that is displayed to the player



        
        
        Debug.Log("n" + n);
        Debug.Log("w: " + w);
        inc = GameObject.Find("increase").GetComponent<Button>();
        inc.onClick.AddListener(increaseValue);
        value = GameObject.Find("Inputs").GetComponent<Text>();
        dec = GameObject.Find("decrease").GetComponent<Button>();
        dec.onClick.AddListener(decreaseValue);
        enter = GameObject.Find("enter").GetComponent<Button>();
        enter.onClick.AddListener(compareValues);
        none = GameObject.Find("none").GetComponent<Button>();
        none.onClick.AddListener(noWind);
        lo = GameObject.Find("low").GetComponent<Button>();
        lo.onClick.AddListener(lowWind);
        med = GameObject.Find("mid").GetComponent<Button>();
        med.onClick.AddListener(midWind);
        high = GameObject.Find("high").GetComponent<Button>();
        high.onClick.AddListener(highWind);
        next = GameObject.Find("restart").GetComponent<Button>();
        next.onClick.AddListener(hardRestartGame);
        enter.interactable = false;
        next.interactable = false;

        currentWeather.text = "Precipitation: " + precip;
        Debug.Log("i: " + i);
        Debug.Log("r1: " + r1);
        Debug.Log("r2: " + r2);
    }

    // Update is called once per frame
    void Update() {


        value.text = "Value: " + precipVal;
        plusCash.text = "+" + totalPlus;
        if(varCounter1 == true && varCounter2 == true)
        {
            enter.interactable = true;
        }else
        {
            enter.interactable = false;
        }
        
        
    }
    public int precipitation()
    {
        r1 = Random.Range(0, (i + 1));
        r2 = Random.Range((9-i), 10);
        n = Random.Range(r1, r2);
        return n;
    }
    void increaseValue()
    {

        
        if (precipVal >= 10)
        {
            precipVal =0;
        }else if(precipVal != 10)
        {
            precipVal += 1;
        }
        if (varCounter1 == false)
        {
            varCounter1 = true;
        }
        Debug.Log(precipVal);
    }
    void decreaseValue()
    {


        if (precipVal <=0)
        {
            precipVal = 10;
        }
        else if (precipVal > 0)
        {
            precipVal -= 1;
        }
        if (varCounter1 == false)
        {
            varCounter1 = true;
        }
        Debug.Log(precipVal);

    }
    void compareValues()
    {
        nCheck();
        if (inRange == false)
        {
            if (precipVal == n)
            {
                PlayerStats.ratings += ((n*3) + 10);
                plusMoney = (100 + (PlayerStats.ratings * 2));
                PlayerStats.money += plusMoney;
            }
            else if (precipVal != n)
            {
                if (PlayerStats.ratings > 0)
                {
                    ratingDecrease(precipVal, n);
                }
                else
                {
                    PlayerStats.ratings = 0;
                }
            }
            
        }else if(inRange == true)
        {
            PlayerStats.ratings += (n + 10);
            plusMoney = (100 + (PlayerStats.ratings));
            PlayerStats.money += plusMoney;
        }
        if(windGint == w)
        {
            PlayerStats.ratings += (w * 10);
            windMoney = (w * 10);
            PlayerStats.money += windMoney;
        }
        else
        {
            if (PlayerStats.ratings > 0)
            {
                PlayerStats.ratings -= (w * 10);
            }else if(PlayerStats.ratings < 0)
            {
                PlayerStats.ratings = 0;
            }
        }
        varCounter1 = false;
        varCounter2 = false;
        next.interactable = true;
        
        totalPlus = (windMoney + plusMoney);
        
    }
    void hardRestartGame()
    {
        PlayerStats.turns += 1;
        PlayerStats.staffApproval -= (PlayerStats.turns / 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        next.interactable = false;
    }
    void ratingDecrease(int q, int j)
    {
        int tempN1 = j - q;
        int tempN2 = q - j;
        if (n > precipVal) {
            
            PlayerStats.ratings -= (tempN1+10);
            PlayerStats.money+=((PlayerStats.ratings / 2));
        }else if(precipVal> n)
        {
            
            PlayerStats.ratings -= tempN2;
        }
    }
    void nCheck()
    {
        if(n == (precipVal - 1) || n == (precipVal + 1))
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
    public int windy()
    {
        w = Random.Range(1, 4);
        return w;
    }
    void noWind()
    {
        windGint = 1;
        playerWind.text = "No Wind";

        if (varCounter2 == false){
            varCounter2 = true;
        }
    }
    void lowWind()
    {
        windGint = 2;
        playerWind.text = "Low Wind";
 if( varCounter2 == false)
        {
            varCounter2 = true;
        }
    }
    void midWind()
    {
        windGint = 3;
        playerWind.text = "Medium Wind";
        if (varCounter2 == false)
        {
            varCounter2 = true;
        }
    }
    void highWind()
    {
        windGint = 4;
        playerWind.text = "High Wind";
        if (varCounter2 == false)
        {
            varCounter2 = true;
        }
    }

}


