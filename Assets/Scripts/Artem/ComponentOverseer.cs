using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentOverseer : MonoBehaviour
{
    public static ComponentOverseer Instance;
    public int overallPower;
    public string Layer0;
    public string Layer1;
    public string Layer2;
    public string Layer3;
    public string Layer4;
    public string Layer5;
    //private int minPowerUnit = 10;
    public bool Cheking = false;
    public bool printing;
    //public List<string> Layers = new List<string>();
    //public List<int> Components = new List<int>();

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }
    /*public void EnergyCheck()
    {
        if (Layer0 == "Layer0" )
        {
            overallPower += minPowerUnit;
        }
        if (Layer1 == "Layer1")
        {
            overallPower += minPowerUnit;
        }
        if (Layer2 == "Layer2")
        {
            overallPower += minPowerUnit;
        }
        if (Layer3 == "Layer3")
        {
            overallPower += minPowerUnit;
        }
        if (Layer4 == "Layer4")
        {
            overallPower += minPowerUnit;
        }
        if (Layer5 == "Layer5")
        {
            overallPower += minPowerUnit;
        }

    }*/
    private void Update()
    {
        /*Debug.Log("SolarPannel Power is - " + overallPower);
        if (Cheking)
        {
            overallPower = 0;
            Invoke("EnergyCheck", 1f);
            Cheking = false;

        }*/


    }
    

}
