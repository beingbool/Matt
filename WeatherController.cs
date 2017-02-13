using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeatherController : MonoBehaviour {

    public Text currentWeather;
    public string precip;
    public int s;
    public Text wind;

    public Text value;// this line and below are for buttons
    int precipVal;
    public Button inc;
    public Button dec;
    public Button enter;

    public static int n;
    
    public int a;
    
    
        void Start() {
        
        GameObject player = GameObject.Find("Player");
        PlayerStats stats = player.GetComponent<PlayerStats>();
        int i = stats.insightlevel;
        


        currentWeather = GameObject.Find("weather").GetComponent<Text>();
        n = precipitation();
        


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


        
        Debug.Log("i:" + i);
        Debug.Log("n" + n);
        inc = GameObject.Find("increase").GetComponent<Button>();
        inc.onClick.AddListener(increaseValue);
        value = GameObject.Find("Inputs").GetComponent<Text>();
        dec = GameObject.Find("decrease").GetComponent<Button>();
        dec.onClick.AddListener(decreaseValue);
        enter = GameObject.Find("enter").GetComponent<Button>();
        enter.onClick.AddListener(compareValues);


        currentWeather.text = "Precipitation: " + precip;
       
    }

    // Update is called once per frame
    void Update() {


        value.text = "Value: " + precipVal;




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
        if (precipVal == n)
        {
            ratingIncrease();
        }
        else if (precipVal != n)
        {
            if (PlayerStats.ratings > 0)
            {
                ratingDecrease(precipVal, n);
            }else
            {
                PlayerStats.ratings -= 0;
            }
        }
        hardRestartGame();
        
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
            
            PlayerStats.ratings -= tempN1;
            PlayerStats.money+=((PlayerStats.ratings / 2));
        }else if(precipVal> n)
        {
            
            PlayerStats.ratings -= tempN2;
        }
    }
    void ratingIncrease()
    {
        PlayerStats.ratings += (n + 5);
        PlayerStats.money +=PlayerStats.ratings;
    }
}


