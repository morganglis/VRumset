using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FlamLogger : MonoBehaviour
{
    // Assign these in the editor 
    public GameObject headset;
    // Need these for Contollers
    public GameObject leftHand;
    public GameObject rightHand;

    private StreamWriter writer;
    private StreamWriter writer2;
    private StreamWriter writer3;

    private Vector3 headPosition;
    private Quaternion headOrientation;

    public float finaltotal = 0;
    public float finalcorrect = 0;
    public float accuracy = 0;

    // Will need these for the Quest 2 Controllers
    private Vector3 LHposition;
    private Quaternion LHorientation;
    private Vector3 RHposition;
    private Quaternion RHorientation;

    public GameObject rightStick;
    private flamRightStickManager RscriptManager;

    public GameObject leftStick;
    private flamLeftStickManager LscriptManager;

    // Start is called before the first frame update
    void Start()
    {
        /*
            Below is only an example is of logging for the headset. 
            You may want to create one path and one writer for each of the things you want to log. 
        */

        // Create TrackingLogs Directory if it doesn't already exist
        var folder = Directory.CreateDirectory(Application.persistentDataPath + "/" + "TrackingLogs");
        // Create the path for the file of the current trial
        string path = Application.persistentDataPath + "/" + "TrackingLogs" + "/" + "headPosition&Orientation_Flam_" +
                     System.DateTime.Now.ToString("MM-dd-yyy-HH-mm-ss") + ".txt";

        string path2 = Application.persistentDataPath + "/" + "TrackingLogs" + "/" + "handPosition&Orientation_Flam_" +
                     System.DateTime.Now.ToString("MM-dd-yyy-HH-mm-ss") + ".txt";

        string path3 = Application.persistentDataPath + "/" + "TrackingLogs" + "/" + "accuracyPercentage_Flam_" +
                     System.DateTime.Now.ToString("MM-dd-yyy-HH-mm-ss") + ".txt";
        // Create the StreamWriter for the above file, which creates the file if it doesn't exist
        writer = new StreamWriter(path, true);
        writer2 = new StreamWriter(path2, true);
        writer3 = new StreamWriter(path3, true);

        RscriptManager = rightStick.GetComponent<flamRightStickManager>(); // Grab our right stick script
        LscriptManager = leftStick.GetComponent<flamLeftStickManager>();    // Grab our left stick script
    }

    // Update is called once per frame 
    // This will result in one line of data, per frame, which is a whole lot lol
    void Update()
    {   
        finaltotal = RscriptManager.total + LscriptManager.total;   // Calculates our final total from the right and left stick hits
        finalcorrect = RscriptManager.correct + LscriptManager.correct;     // Calculates our final correct total from right and left sticks
        accuracy = (finalcorrect / finaltotal) * 100; // Divide the correct number of hits by the total number of hits and multiply by 100 to get the accuracy

        // Grab headPosition values from headset (Unity Camera) -- Format: (x, y, z)
        headPosition = headset.transform.position;
        // Grab headOrientation values from headset (Unity Camera) -- Format: (r, p, y, w)
        headOrientation = headset.transform.rotation;
        // Write line to file with current time, position, and orientation
        LHposition = leftHand.transform.position;
        LHorientation = leftHand.transform.rotation;
        RHposition = rightHand.transform.position;
        RHorientation = rightHand.transform.rotation;

        writer.WriteLine(System.DateTime.Now.ToString("s") + "\t" + "Position: " + headPosition.ToString() + "\t" + "Orientation: " + headOrientation.ToString());
        writer2.WriteLine(System.DateTime.Now.ToString("s") + "\t" + "Right Hand Position: " + RHposition.ToString() + "\t" + "Right Hand Orientation: " + RHorientation.ToString());
        writer2.WriteLine(System.DateTime.Now.ToString("s") + "\t" + "Left Hand Position: " + LHposition.ToString() + "\t" + "Left Hand Orientation: " + LHorientation.ToString());
        writer3.WriteLine(System.DateTime.Now.ToString("s") + "\t" + "Accuracy: " + accuracy.ToString() + "%" + "\t" + "Final Total Hits: " + finaltotal.ToString() + "\t" + "Final Total Correct Hits: " + finalcorrect.ToString());
    }

    void OnApplicationQuit()
    {
        // Shut down writer when application is exited
        writer.Close();
        writer2.Close();
        writer3.Close();
    }
}
