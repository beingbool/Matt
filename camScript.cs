using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camScript : MonoBehaviour {

    float camMovLerp= 0f;
    bool ugrClick;
    public Button ugr;
    float MaxY;
    public Button main;
    bool mainclick;
    float camPosY;
    float camPosX = 0;
    float MaxX= 0;
    public Button staffs;
    bool staffClick;
    public Button main2;
    bool main2click;




    void Start () {
        
        
        ugr = GameObject.Find("Upgrades").GetComponent<Button>();
        ugr.onClick.AddListener(upgradeClicked);
        main = GameObject.Find("mainmenu").GetComponent<Button>();
        main.onClick.AddListener(MainmenuClick);
        ugrClick = false;
        MaxY = 10f;
        camPosY = 0f;
        staffs = GameObject.Find("staff").GetComponent<Button>();
        staffs.onClick.AddListener(staffClicked);
        main2 = GameObject.Find("main2").GetComponent<Button>();
        main2.onClick.AddListener(main2Click);


    }
	

	void Update () {

        transform.position = new Vector3(Mathf.Lerp(camPosX, MaxX, Mathf.Clamp( camMovLerp,0,1)), Mathf.Lerp(camPosY, MaxY, Mathf.Clamp(camMovLerp, 0, 1)), 0);
        if(ugrClick == true)
        {
            camMovLerp += 1f * Time.fixedDeltaTime;

            
        }
        if(mainclick)
        {
            
            camMovLerp -= 1f * Time.fixedDeltaTime;

            
        }
        if (staffClick)
        {
            camMovLerp += 1f * Time.fixedDeltaTime;
        }
        if (main2click)
        {
            camMovLerp -= 1f * Time.fixedDeltaTime;
        }



    }
    void upgradeClicked()
    {
        
        ugrClick = true;
        mainclick = false;
        staffClick = false;
        main2click = false;
        MaxY = 10f;

        camMovLerp = 0;


    }
    void MainmenuClick()
    {
        ugrClick = false;
        mainclick = true;
        staffClick = false;
        main2click = false;
        camMovLerp = 1;
        MaxY = 10f;




    }
    void staffClicked()
    {
        ugrClick = false;
        mainclick = false;
        staffClick = true;
        main2click = false;
        camMovLerp = 0;
        MaxY = -10f; 
    }
    void main2Click()
    {
        ugrClick = false;
        mainclick = false;
        staffClick = false;
        main2click = true;
        camMovLerp = 1;
        MaxY = -10f;
    }

}
