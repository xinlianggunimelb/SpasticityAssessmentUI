using FFTAICommunicationLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string value=INIFile.Read(Application.streamingAssetsPath+ "//ControlFunction//SuggestedValue.ini","M2", "Passive – Driver Position Control");
        print(value);
    }

    // Update is called once per frame
    void Update()
    {
        //print("FlagCalibration: "+DynaLinkHS.StatusFlag.FlagCalibration);
        //print("Flag: " + DynaLinkHS.StatusFlag);
    }
}
