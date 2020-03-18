using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine;
using GoogleARCore.Examples.HelloAR;

public class DiscCompare : MonoBehaviour
{
    ////Debug Text
    //public Text CueRatioInfo;
    //public Text DisPoles;
    //public Text ShoulderWidth;
    public GameObject Cueprefab;
    public InputField inputfield;
    public Text NextTrial;

    public float dis;
    public float inputF;
    private bool havereadinputF = false;

    private float timeShown; // results show 2s then disappear

    public int trial_times1 = 0;
    public float[] CueRatio1 = new float[] { 0f, 0f, 0f, 0f, 1.0f, 1.0f, 1.0f, 1.0f };
    private HelloARController HelloARControllerInstance;

    // Start is called before the first frame update
    void Start()
    {
        HelloARControllerInstance = GameObject.Find("HelloAR Controller").GetComponent<HelloARController>();
        // compare dis
        GameObject.Find("Go").GetComponent<Button>().onClick.AddListener(() =>
        {
            timeShown = 0.0f; // update it in Update() function
            if(trial_times1<7)
            {
                NextTrial.text = "【Trial" + (trial_times1 + 1).ToString() + "】Please hit the grid on the ground to continue the trial.";
            }
        }
        );

    }

    // Update is called once per frame
    void Update()
    {
        // 【Distance between 2 Poles】 = dis of center of circles - 2*radius
        dis = Vector3.Distance(GameObject.Find("PoleRightChild").transform.position, GameObject.Find("PoleLeftChild").transform.position) - GameObject.Find("PoleRightChild").transform.localScale.x;
        //DisPoles.text = "Pole Gap Width:" + dis.ToString();
        // Shoulder width of participant
        if (havereadinputF == false)
        {
            inputF = float.Parse(inputfield.text, System.Globalization.CultureInfo.InvariantCulture);
            //ShoulderWidth.text = "Shoulder Width:" + inputfield.text;
            havereadinputF = true;

        }



        // show 2s and then disappear
        timeShown += Time.deltaTime;
        if (timeShown >= 1.5f)
        {
            NextTrial.text = "";
        }


        //CueRatioInfo.text = "trial:" + trial_times1 + "Cueratio:" + CueRatio1[trial_times1] 
        //    +"Right"+ GameObject.Find("PoleRightChild").transform.position.x +"Left" + GameObject.Find("PoleLeftChild").transform.position.x
        //    +"scale"+GameObject.Find("PoleRightChild").transform.localScale.x;

        //show the cue on the 4th trial
        trial_times1 = HelloARControllerInstance.trial_times;
        if (trial_times1 % 4 == 0  &&  trial_times1 != 0)
        {
            Cueprefab.SetActive(true);
            float cueratio = CueRatio1[trial_times1];
            Cueprefab.transform.localScale = new Vector3(inputF * cueratio, 0.05f, 0.05f);
        }
            
        Cueprefab.transform.position = GameObject.Find("First Person Camera").transform.position + new Vector3(0.0F, -1.0f, 1.2F);
        Cueprefab.transform.rotation = GameObject.Find("First Person Camera").transform.rotation;
        //Cueprefab.transform.LookAt(GameObject.Find("First Person Camera").transform,new Vector3(0,0,-1));

    }
}
