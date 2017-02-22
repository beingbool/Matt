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

    public static int n;
    
    public int a;
    
    
        void Start() {



        int i = PlayerStats.insightlevel;


        plusCash = GameObject.Find("plusCash").GetComponent<Text>();
        currentWeather = GameObject.Find("weather").GetComponent<Text>();
        playerWind = GameObject.Find("windGuess").GetComponent<Text>();
        n = precipitation();
        w = windy();
        


        if (i > 0) {// determines range and what is displayed to the player
            if ((n - i) < 0)
            {
                precip = "0" + "-" + (n + i);
            } else if ((n + i) > 10)
            {
                precip = (n - i) + "-" + "10";
            }
            else
            {
                precip = (n - i) + "-" + (n + i);
            }
        } else if (i == 0)
        {
            precip = n + " ";
        }


        
        
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
        enter.interactable = true;

        currentWeather.text = "Precipitation: " + precip;
       
    }

    // Update is called once per frame
    void Update() {


        value.text = "Value: " + precipVal;
        plusCash.text = "+" + totalPlus;
        

    }
    public int precipitation()
    {

        n = Random.Range(0, 10);
        return n;
    }
    void increaseValue()
    {

        
        if (precipVal == 10)
        {
            precipVal +=0;
        }else if(precipVal != 10)
        {
            precipVal += 1;
        }

    }
    void decreaseValue()
    {


        if (precipVal == 0)
        {
            precipVal -= 0;
        }
        else if (precipVal > 0)
        {
            precipVal -= 1;
        }

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
                    PlayerStats.ratings -= 0;
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
            PlayerStats.ratings -= (w * 10);
            
        }
        enter.interactable = false;
        totalPlus = (windMoney + plusMoney);
        
    }
    void hardRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    }
    void lowWind()
    {
        windGint = 2;
        playerWind.text = "Low Wind";
    }
    void midWind()
    {
        windGint = 3;
        playerWind.text = "Medium Wind";
    }
    void highWind()
    {
        windGint = 4;
        playerWind.text = "High Wind";
    }

}


