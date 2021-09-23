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
    BtwTrialCheck,
    TrialInProgress, //Ongoing spasticity testing
    TrialFinished,
    MaxForceDetcted,
    MinJerkFailed,
    RobotDisabled,
    Quited
}


public class CenterControl : MonoBehaviour
{
    //UI elements
    public Button InitButton, RecordButton, TestButton, StartButton, ContinueButton, StopButton, QuitButton;
    public Toggle EMGToggle;
    public InputField PatientIDInputField, SessionIDInputField;
    public Slider ProgressSlider;
    public Text SubjectInstructionsText, InstructionsText;

    public CORCM2 M2Robot;
    public DelsysEMG EMG;


    //Timing
    public long T0, t0;
    public Timer timerBack, timerRecordBack, timerCountDown, timerRecordMvt, timerStart;
    public int CountDownSeconds;

    //Logging
    public StringBuilder csvcontent;
    public String CurrentCSVFilenameCORC = "", CurrentCSVFilenameEMG = "";
    string csvpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "//SpasticityStudyData//" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");

    //Test logic and parameters
    private TestStates TestState;
	private double[] StateCompare = new double[2];
	
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
        StopButton.onClick.AddListener(Stop_cb);
        QuitButton.onClick.AddListener(Quit_cb);
        
        //RecordButton.onClick.AddListener(delegate { StartCoroutine(RecordMvt_cb()); } );
        //StartButton.onClick.AddListener(delegate { StartCoroutine(Start_cb()); } );
        //TestButton.onClick.AddListener(delegate { StartCoroutine(Test_cb()); }) ;
    }


    private void Update()
    {
		
	if (EMG.IsConnected())
	{
		if (EMG.IsRunning())
        {
            //EMGStateTxt.text = "EMG recording";
            EMGToggle.GetComponentInChildren<Text>().text = "EMG recording";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(0.1f, 1.0f, 0.1f);
        }
        else
        {
            //EMGStateTxt.text = "EMG ERROR !";
            EMGToggle.GetComponentInChildren<Text>().text = "EMG error";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(1.0f, 0.1f, 0.1f);
        }
    }   


	if(M2Robot.IsInitialised())
	{
		StateCompare[0] = StateCompare[1];
		StateCompare[1] = M2Robot.State["S"][0];
	}
		
		
	if((StateCompare[1]==6||(StateCompare[1]>=11&&StateCompare[1]<=19)) && (StateCompare[1]-StateCompare[0]!=0))
	{
		StartCoroutine(CountDown());
	}	
	

	if(M2Robot.IsInitialised()){
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
				SubjectInstructionsText.text = "Reset done.";	
			    break;
			case 10:
			    TestState = TestStates.BtwTrialCheck;
			    SubjectInstructionsText.text = "Start next velocity when ready.";	
			    break;
			case 11: //velocity 1
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 1/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 12: //velocity 2
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 2/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 13: //velocity 3
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 3/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 14: //velocity 4
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 4/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 15: //velocity 5
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 5/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 16: //velocity 6
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 6/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 17: //velocity 7
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 7/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 18: //velocity 8
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 8/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 19: //velocity 9
			    TestState = TestStates.TrialInProgress;
			    SubjectInstructionsText.text = "Trial in progress 9/9.";
			    ProgressSlider.value = ((int)(M2Robot.State["S"][0])-10) / (float)9.0 * (float)100.0;
			    break;
			case 20:
			    TestState = TestStates.TrialFinished;
			    SubjectInstructionsText.text = "Trial finished! Thank you.";
			    break;			
			case 21: //max force/speed detected before trial
			    TestState = TestStates.Initialised; 
				SubjectInstructionsText.text = "Safety Limit Reached! Please record again.";
			    break;
			case 22: //max force/speed detected in trial
			    TestState = TestStates.MaxForceDetcted; 
				SubjectInstructionsText.text = "Safety Limit Reached! Relax and press continue when ready.";
			    break;
			case 23:
				TestState = TestStates.MinJerkFailed;
				SubjectInstructionsText.text = "Robot not back to starting point... Retry.";
				break;
			case 24:
				TestState = TestStates.RobotDisabled;
				SubjectInstructionsText.text = "Safety Limit Reached! Relax and press reset when ready.";
				break;
			}
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
                StopButton.interactable = false;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = true; 
                SessionIDInputField.interactable = true;
                ProgressSlider.interactable = false;
                break;
            case TestStates.Initialised:
                InitButton.interactable = true;
                EMGToggle.interactable = false;
                RecordButton.interactable = true;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                StopButton.interactable = false;
                QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
            case TestStates.MvtRecording:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
				StopButton.interactable = true;
				QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break; 
            case TestStates.MvtRecorded:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = true;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                StopButton.interactable = true;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
            case TestStates.MvtTesting:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                StopButton.interactable = true;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;            
            case TestStates.MvtTested:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = true;
                StartButton.interactable = true;
                ContinueButton.interactable = false;
                StopButton.interactable = true;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
            case TestStates.BtwTrialCheck:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = true;
                ContinueButton.interactable = false;
                StopButton.interactable = true;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = true;
                break;
            case TestStates.TrialInProgress:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
                StopButton.interactable = true;
                QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = true;
                break;
            case TestStates.TrialFinished:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = true;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
				StopButton.interactable = true;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
            case TestStates.MaxForceDetcted:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = true;
				StopButton.interactable = true;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
            case TestStates.MinJerkFailed:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = true;
				StopButton.interactable = true;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
			case TestStates.RobotDisabled:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
				StopButton.interactable = true;
				QuitButton.interactable = true;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
                break;
            case TestStates.Quited:
                InitButton.interactable = false;
                EMGToggle.interactable = false;
                RecordButton.interactable = false;
                TestButton.interactable = false;
                StartButton.interactable = false;
                ContinueButton.interactable = false;
				StopButton.interactable = false;
				QuitButton.interactable = false;
                PatientIDInputField.interactable = false;
                SessionIDInputField.interactable = false;
                ProgressSlider.interactable = false;
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
//    void WriteToFile(string TestName)
//    {
//        CurrentCSVFilename = "PatientID_" + PatientIDInputField.text + "_" + TestName;
//        string csvfullfilename = csvpath + "\\" + CurrentCSVFilename + ".csv";
//        File.WriteAllText(csvfullfilename, "Time, Xpos, Ypos, Xspd, Ysped, Xfor, Yfor, State\n");
//        File.AppendAllText(csvfullfilename, csvcontent.ToString());
//        csvcontent.Remove(0, csvcontent.Length);
//    }


	IEnumerator WaitM2Init()
	{ 	
		//Debug.Log("waiting start");
		yield return new WaitForSeconds(5.0f);
		//Debug.Log("waiting done");
	}
	
	
	IEnumerator CountDown()
	{ 	
		CountDownSeconds=3;
		while(CountDownSeconds>=1){
			//Start movement at 0
			InstructionsText.text = CountDownSeconds.ToString();
			yield return new WaitForSeconds(1.0f);
			//Decrease CountdownSeconds
			CountDownSeconds -= 1;
		}
		InstructionsText.text = " ";
	}


    void Init_cb()
    {
        T0 = DateTime.Now.Ticks;
        InitRobot_cb(T0);
        InitDelsys(T0);
        //Reset state
        //TODO: restore if(EMG.IsConnected())
        if (M2Robot.IsInitialised() && EMG.IsConnected()){
            //StartCoroutine(WaitM2Init());
            TestState = TestStates.Initialised;
            SubjectInstructionsText.text = "Initialised. Record movement when ready.";	
        }
        else if (M2Robot.IsInitialised() && !EMG.IsConnected()){
            //StartCoroutine(WaitM2Init());
            TestState = TestStates.Initialised;
            SubjectInstructionsText.text = "CORC Initialised. Record movement when ready.";	
        }
        else {
            TestState = TestStates.NotInitialised;
            SubjectInstructionsText.text = "Not initialised.";
		}	
    }


    /// <summary>
    /// Homing and sensors init
    /// </summary>
    void InitRobot_cb(long t0)
    {
        //Setup connection to robot
        if (!M2Robot.IsInitialised())
        {
            long init_time = t0;
            //M2Robot.Init("127.0.0.1"); //locally
            //M2Robot.Init("192.168.6.2"); //Linux
            M2Robot.Init(init_time, "192.168.7.2", 2048); //Windows
            //M2Robot.Init(start_time); //Windows
            if(!M2Robot.IsInitialised())
				return;
			CurrentCSVFilenameCORC = "PatientID_" + PatientIDInputField.text + "_SessionID_" + SessionIDInputField.text;
			string csvfullfilenameCORC = csvpath + "\\" + CurrentCSVFilenameCORC + "_CORC.csv";
			M2Robot.SetLoggingFile(csvfullfilenameCORC);
			M2Robot.SetLogging(true); //start or stop logging to file
            Debug.Log("CORC Connected");
        }
    }


    void InitDelsys(long t0)
    {
        long init_time = t0;
        EMG.Init(init_time);
        EMG.Connect();
        if (EMG.IsConnected())
        {
            EMG.StartAcquisition();
            EMGToggle.isOn= true;
            //EMGStateTxt.text = EMG.GetNbSensors() + "EMGs connected.";
            EMGToggle.GetComponentInChildren<Text>().text = EMG.GetNbSensors() + "EMGs connected.";
            EMGToggle.GetComponentInChildren<Text>().color = new Color(0.1f, 1.0f, 0.1f);
            CurrentCSVFilenameEMG = "PatientID_" + PatientIDInputField.text + "_SessionID_" + SessionIDInputField.text;
			string csvfullfilenameEMG = csvpath + "\\" + CurrentCSVFilenameEMG + "_EMG.csv";
			EMG.StartRecording(csvfullfilenameEMG);
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


    void Stop_cb()
    {
		M2Robot.SendCmd("REST");
    }


    void Quit_cb()
    {
        //Disconnect robot
        M2Robot.Disconnect();
        //Stop EMG Aquisition
        if (EMG.IsConnected())
        {
            EMG.StopAcquisition();
            EMG.StopRecording();
            EMG.Close();
        }
        //Exit
        TestState = TestStates.Quited;
        SubjectInstructionsText.text = "Quited.";
    }



}
