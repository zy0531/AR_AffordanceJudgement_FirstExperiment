using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.HelloAR;


public class TrialController: MonoBehaviour
{
    // ******************************** Use Array to store experiment variables ********************************
    public float[] AD = new float[] {0.7f, 1.8f, 0.7f, 1.8f, 0.7f, 1.8f, 0.7f, 1.8f };
    public float[] CueRatio = new float[] {0f, 0f, 0f, 0f, 1.0f, 1.0f, 1.0f, 1.0f};
    private int trialindex = 0;

    //writing data
    private HelloARController HelloARControllerInstance;
    private DiscCompare DiscCompareInstance;



    // ******************************** Tips: Create the TrialArray in Awake(), for successfully calling by other script in Start() ********************************
    public void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        HelloARControllerInstance = GameObject.Find("HelloAR Controller").GetComponent<HelloARController>();
        DiscCompareInstance = GameObject.Find("Manager").GetComponent<DiscCompare>();

        GameObject.Find("Go").GetComponent<Button>().onClick.AddListener(() =>
        {
            writeStringToFile("#Trial:" + HelloARControllerInstance.trial_times.ToString(), "zyyyyydata1");
            writeStringToFile("AD:" + AD[trialindex].ToString(), "zyyyyydata1");
            writeStringToFile("Cue Ratio:" + CueRatio[trialindex].ToString(), "zyyyyydata1");
            writeStringToFile("Dis between aperture and observer:" + HelloARControllerInstance.Posz.ToString(), "zyyyyydata1");
            writeStringToFile("Pole Gap Width:" + DiscCompareInstance.dis.ToString(), "zyyyyydata1");
            writeStringToFile("Shoulder Width:" + DiscCompareInstance.inputF.ToString(), "zyyyyydata1");
            trialindex++;
        }
        );
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    // convert 1D Array to 2D Array https://stackoverflow.com/questions/28113015/c-sharp-convert-1d-array-to-2d
    private static T[,] Make2DArray<T>(T[] input, int height, int width)
    {
        T[,] output = new T[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                output[i, j] = input[i * width + j];
            }
        }
        return output;
    }

    // Shuffle elements in Array
    public void Shuffle<T>(T[] OriginalData)
    {
        for (int i = 0; i < OriginalData.Length; i++)
        {
            int last = OriginalData.Length - 1;
            int rnd = Random.Range(0,last);
            T temp = OriginalData[i];
            OriginalData[i] = OriginalData[rnd];
            OriginalData[rnd] = temp;
        }
    }



    ////////////////// write data //////////////////
    ///
    //struct ExperimentData
    //{
    //    public int Trial;
    //    public float Dis_Poles;
    //    public Vector3 Pos_Poles;
    //}


    public void writeStringToFile(string str, string filename)
    {
#if !WEB_BUILD
        string path = pathForDocumentsFile(filename);
        FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write);

        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(str);

        sw.Close();
        file.Close();
#endif
    }


    public string readStringFromFile(string filename)//, int lineIndex )
    {
#if !WEB_BUILD
        string path = pathForDocumentsFile(filename);

        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }

        else
        {
            return null;
        }
#else
return null;
#endif
    }


    public string pathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }

        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }

}
