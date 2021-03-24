//#define DEBUG

using CORC;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;


public enum TestStates
{
    NotInitialised,
    Initialised, //Robot is initialised and calibrated, ready to record
    MvtRecording,
    MvtRecorded, //Movement has been recorded and validated
    MvtTesting,
    MvtTested, //Movement has been tested and validated
    TrialInProgress, //Ongoing spasticity testing
    CountingDown,
    TrialFinished,
    MaxForceDetcted,
    MinJerkFailed
}


public class CenterControl : MonoBehaviour
{
    //UI elements
    public Button InitButton, RecordButton, TestButton, StartButton, ContinueButton, QuitButton;
    public Toggle EMGToggle;
    public InputField PatientIDInputField, SessionIDInputField;
    public Slider ProgressSlider;
    public Text SubjectInstructionsText, InstructionsText;

    public CORCM2 M2Robot;
    public DelsysEMG EMG;


    //Timing
    public long t0;
    public Timer timerBack, timerRecordBack, timerCountDown, timerRecordMvt, timerStart;
    public int CountDownSeconds;

    //Logging
    public StringBuilder csvcontent;
    public String CurrentCSVFilename = "";
    string csvpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "//SpasticityStudyData//" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");

    //Test logic and parameters
    public TestStates TestState;
	public double[] StateCompare = new double[2];
	
    private string communicationConfig;


    private void Start()
    {
        //初始化子线程中调用主线程的方法
        Loom.Initialize();
        //设置光标
        SettingCusor();
        //设置程序的帧率
        Application.targetFrameRate = 30;

        EMG = new DelsysEMG();

        TestState = TestStates.NotInitialised;

        //Logging
        Directory.CreateDirectory(csvpath);
        csvcontent = new StringBuilder();
        
        InitButton.onClick.AddListener(Init_cb);
        RecordButton.onClick.AddListener(RecordMvt_cb);
        TestButton.onClick.AddListener(Test_cb);
        StartButton.onClick.AddListener(Start_cb);
        ContinueButton.onClick.AddListener(Continue_cb);
        QuitButton.onClick.AddListener(Quit_cb);
        
        //RecordButton.onClick.AddListener(delegate { StartCoroutine(RecordMvt_cb()); } );
        //StartButton.onClick.AddListener(delegate { StartCoroutine(Start_cb()); } );
        //TestButton.onClick.AddListener(delegate { StartCoroutine(Test_cb()); }) ;
    }


    private void Update()
    {
        if (EMG.IsConnected())
        {
            EMG.Update();
            //EMGStateTxt.text = EMG.GetNbSensors() + "EMGs connected.";
            EMGToggle.GetComponentInChildren<Text>().text = EMG.GetNbSensors() + "EMGs connected.";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(0.1f, 1.0f, 0.1f);
        }
        else
        {
            //EMGStateTxt.text = "EMGs NOT connected.";
            EMGToggle.GetComponentInChildren<Text>().text = "EMGs NOT connected.";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(1.0f, 0.1f, 0.1f);
        }
       

	//TODO: test to remove
	if(true)
	{
		Debug.Log("state:" + M2Robot.State["S"][0]);
		Debug.Log(TestState);
	}	
	//TODO: test to remove
//	if(M2Robot.IsInitialised())
//	{
//		Debug.Log(M2Robot.State["X"][0]);
//	}
	

        //Save data
//        if (TestRunning)
//        {
//            csvcontent.AppendLine((float)((DateTime.Now.Ticks - t0) / (float)10000000) + "," + DynaLinkHS.StatusRobot.PositionDataJoint1.ToString() + "," + DynaLinkHS.StatusRobot.PositionDataJoint2 + "," + DynaLinkHS.StatusRobot.VelocityDataJoint1 + "," + DynaLinkHS.StatusRobot.VelocityDataJoint2 + "," + DynaLinkHS.StatusSensor.ADCSensor1.CalculateValue + "," + DynaLinkHS.StatusSensor.ADCSensor2.CalculateValue);
//        }

		if(true){
			StateCompare[0] = StateCompare[1];
			StateCompare[1] = M2Robot.State["S"][0];
		}
		
		
	if(StateCompare[1]==6 && (StateCompare[1]-StateCompare[0]!=0)){
		Debug.Log(1);
		StartCoroutine(CountDown());
		Debug.Log(4);
	}	
		
			
		IEnumerator CountDown()
		{ 	
			CountDownSeconds=3;
			while(CountDownSeconds>=1){
				Debug.Log(2);
				//Start movement at 0
				SubjectInstructionsText.text = CountDownSeconds.ToString();
				yield return new WaitForSeconds(1.0f);
				Debug.Log(3);
				//Decrease CountdownSeconds
				CountDownSeconds -= 1;
				Debug.Log("CountingDown:" +CountDownSeconds);
			}
		}
	

        switch((int)(M2Robot.State["S"][0]))
        {
			//case 0: CORC not calibrated
			//case 1: CORC calibrated
			case 2:
			    TestState = TestStates.MvtRecording;
			    SubjectInstructionsText.text = "Movement recording.";	
			    break;
			//case 3: recording finished but not returned		
			case 4:
			    TestState = TestStates.MvtRecorded;
			    SubjectInstructionsText.text = "Movement recorded. Test movement when ready.";	
			    break;		
			case 5:
			    TestState = TestStates.Initialised;
			    SubjectInstructionsText.text = "Incorrect movement. Please record again.";	
			    break;		
			case 6:
			    TestState = TestStates.MvtTesting;
			    SubjectInstructionsText.text = "Movement testing.";
			    break;
			//case 7: testing finished but not returned			
			case 8:
			    TestState = TestStates.MvtTested;
			    SubjectInstructionsText.text = "Movement tested. Start trial when ready.";	
			    break;
			case 9: //click reset/stop button
				TestState = TestStates.Initialised;
				SubjectInstructionsText.text = "Reset. Please record again.";	
			    break;
			case 11: //velocity 1
			    TestState = TestStates.TrialInProgress;
			    break;
			case 12: //velocity 2
			    TestState = TestStates.TrialInProgress;
			    break;
			case 13: //velocity 3
			    TestState = TestStates.TrialInProgress;
			    break;
			case 14: //velocity 4
			    TestState = TestStates.TrialInProgress;
			    break;
			case 15: //velocity 5
			    TestState = TestStates.TrialInProgress;
			    break;
			case 16: //velocity 6
			    TestState = TestStates.TrialInProgress;
			    break;
			case 17: //velocity 7
			    TestState = TestStates.TrialInProgress;
			    break;
			case 18: //velocity 8
			    TestState = TestStates.TrialInProgress;
			    break;
			case 19: //velocity 9
			    TestState = TestStates.TrialInProgress;
			    break;
			case 20:
			    TestState = TestStates.TrialFinished;
			    SubjectInstructionsText.text = "Trial finished! Thank you.";
			    break;			
			case 21: //max force detected before trial
			    TestState = TestStates.Initialised; 
			    //Debug.Log("Force: " + M2Robot.State["F"][0] + M2Robot.State["F"][1]);
				SubjectInstructionsText.text = "Force Safety Limit Reached! Please record again.";
			    break;
			case 22: //max force detected in trial
			    TestState = TestStates.MaxForceDetcted; 
			    //Debug.Log("Force: " + M2Robot.State["F"][0] + M2Robot.State["F"][1]);
				SubjectInstructionsText.text = "Force Safety Limit Reached! Relax and press continue when ready.";
			    break;
			case 23:
				TestState = TestStates.MinJerkFailed;
				SubjectInstructionsText.text = "Robot not back to starting point... Retry.";
				break;
			}


        //Update UI based on state
        switch(TestState)
        {
            case TestStates.NotInitialised:
                InitButton.interactable = true;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;   
                QuitButton.interactable = false;
                PatientIDInputField.interactable = false; 
                SessionIDInputField.interactable = false;
                //ProgressSlider.interactable = false;
                break;
            case TestStates.Initialised:
                InitButton.interactable = true;
                EMGToggle.interactable = false;
                RecordButton.interactable = true;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = true;
                SessionIDInputField.interactable = true;
                //ProgressSlider.interactable = false;
                break;
            case TestStates.MvtRecording:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                //ProgressSlider.interactable = false;
                break; 
            case TestStates.MvtRecorded:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = true;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                QuitButton.interactable = true;
                PatientIDInputField.interactable = true;
                SessionIDInputField.interactable = true;
                //ProgressSlider.interactable = false;
                break;
            case TestStates.MvtTesting:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                //ProgressSlider.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                QuitButton.interactable = true;
                break;            
            case TestStates.MvtTested:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = true;
                StartButton.interactable = true;
                ContinueButton.interactable = false;
                //ProgressSlider.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                QuitButton.interactable = true;
                break;
            case TestStates.TrialInProgress:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                //ProgressSlider.interactable = true;
                break;
            case TestStates.TrialFinished:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = true;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                //ProgressSlider.interactable = false;
                break;
            case TestStates.MaxForceDetcted:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = true;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                //ProgressSlider.interactable = false;
                break;
            case TestStates.MinJerkFailed:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = true;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                //ProgressSlider.interactable = false;
                break;
        }

    }

    /// <summary>
    /// 设置光标
    /// </summary>
    private void SettingCusor()
    {
        Texture2D texture2D = Resources.Load<Texture2D>("Logo/光标");
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }


    /// <summary>
    /// Write the content of the csvcontent to a file in the appropriate folder
    /// AND erase the content of the csv content (to start a new one).
    /// </summary>
    /// <param name="TestName"></param>
    void WriteToFile(string TestName)
    {
        CurrentCSVFilename = "PatientID_" + PatientIDInputField.text + "_" + TestName;
        string csvfullfilename = csvpath + "\\" + CurrentCSVFilename + ".csv";
        File.WriteAllText(csvfullfilename, "Time, Xpos, Ypos, Xspd, Ysped, Xfor, Yfor\n");
        File.AppendAllText(csvfullfilename, csvcontent.ToString());
        csvcontent.Remove(0, csvcontent.Length);
    }



    void Init_cb()
    {
        InitRobot_cb();
        InitDelsys();
        //Reset state
        //TODO: restore if(EMG.IsConnected())
        if (true){
            TestState = TestStates.Initialised;
            //Debug.Log('1');
        }
        else
            TestState = TestStates.NotInitialised;
    }


    /// <summary>
    /// Homing and sensors init
    /// </summary>
    void InitRobot_cb()
    {
        //Setup connection to robot
        if (!M2Robot.IsInitialised())
        {
            M2Robot.Init("127.0.0.1");
            if(!M2Robot.IsInitialised())
				return;
			M2Robot.SetLoggingFile("mylogfile.csv");
			M2Robot.SetLogging(true); //start or stop logging to file
            Debug.Log("Connected");
        }
    }


    void InitDelsys()
    {
        t0 = DateTime.Now.Ticks;
        EMG.Init(t0);
        EMG.Connect();
        if (EMG.IsConnected())
        {
            EMG.StartAcquisition();
            EMGToggle.isOn= true;
            //EMGStateTxt.text = EMG.GetNbSensors() + "EMGs connected.";
            EMGToggle.GetComponentInChildren<Text>().text = EMG.GetNbSensors() + "EMGs connected.";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(0.1f, 1.0f, 0.1f);
        }
        else
        {
            EMGToggle.isOn = false;
            //EMGStateTxt.text = "EMGs NOT connected.";
            EMGToggle.GetComponentInChildren<Text>().text = "EMGs NOT connected.";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(1.0f, 0.1f, 0.1f);
        }
    }


    //IEnumerator RecordMvt_cb()
    void RecordMvt_cb()
    {
	    M2Robot.SendCmd("RECD");
    }


    /// Perform a test of the recorded movement at low velocity
    //IEnumerator Test_cb()
    void Test_cb()
    {
	    M2Robot.SendCmd("TEST");
    }


    void Start_cb()
    {
	    M2Robot.SendCmd("TRIA");
    }


    void Continue_cb()
    {
	    M2Robot.SendCmd("MFRT");
    }

 //   IEnumerator InitiateMovement()
//{
        //Go for it otherwise
     //   SubjectInstructionsText.text = "Relax your arm...";
 //       csvcontent.Remove(0, csvcontent.Length);
 //       CurrentCSVFilename = "PatientID_" + PatientIDInputField.text + "_" + TestVelocity.ToString() + "Spd";

//        if (EMG.IsConnected())
//        {
//            if (EMG.IsRunning())
//            {
//                //EMGStateTxt.text = "EMG recording";
//                EMGToggle.GetComponentInChildren<Text>().text = "EMG recording";
//                EMGToggle.GetComponentInChildren<Text>().color = new Color(0.1f, 1.0f, 0.1f);
//            }
//            else
//            {
//                EMGToggle.GetComponentInChildren<Text>().text = "EMG error";
//                EMGToggle.GetComponentInChildren<Text>().color = new Color(1.0f, 0.1f, 0.1f);
//                //EMGStateTxt.text = "EMG ERROR !";
//            }
//            EMG.StartRecording(csvpath + "\\" + CurrentCSVFilename + "EMG.csv");
//        }

//Debug.Log('9');
  //      CountDown = 4;
        //Show countdown
    //    while(CountDown > -1)
      //      yield return CountDownDisplay();
  //  }


    void Quit_cb()
    {
//        Debug.Log("Exit");
//        //Stop EMG Aquisition
//        if (EMG.IsConnected())
//        {
//            EMG.StopAcquisition();
//            EMG.Close();
//        }
//        //Stop robot
		  M2Robot.SendCmd("REST");
//        //Exit
    }



}
