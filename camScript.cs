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


	void Start () {
        
        
        ugr = GameObject.Find("Upgrades").GetComponent<Button>();
        ugr.onClick.AddListener(upgradeClicked);
        main = GameObject.Find("mainmenu").GetComponent<Button>();
        main.onClick.AddListener(MainmenuClick);
        ugrClick = false;
        MaxY = 10f;
        camPosY = 0f;


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
        

        
    }
    void upgradeClicked()
    {
        
        ugrClick = true;
        mainclick = false;

        camMovLerp = 0;


    }
    void MainmenuClick()
    {
        ugrClick = false;
        mainclick = true;

        camMovLerp = 1;
        

        Debug.Log(camPosY);
        
        
    }
}
