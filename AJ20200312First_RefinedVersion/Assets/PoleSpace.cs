using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoleSpace : MonoBehaviour
{
    public int TranslateSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 amountToMove = (GameObject.Find("PoleRightChild").transform.position - GameObject.Find("PoleLeftChild").transform.position).normalized;
        // Vector3 amountToMove = new Vector3(1, 0, 0);
        Vector3 left = GameObject.Find("PoleLeftChild").transform.position;
        Vector3 right = GameObject.Find("PoleRightChild").transform.position;
        GameObject.Find("PlaneDiscovery/CanvasPET/Inward").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.Find("PoleLeftChild").transform.position = Vector3.Lerp(left, left + amountToMove/100, 1);
            GameObject.Find("PoleRightChild").transform.position = Vector3.Lerp(right, right - amountToMove/100, 1);
        }
        );
        GameObject.Find("PlaneDiscovery/CanvasPET/Outward").GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject.Find("PoleLeftChild").transform.position = Vector3.Lerp(left, left - amountToMove/100, 1);
            GameObject.Find("PoleRightChild").transform.position = Vector3.Lerp(right, right + amountToMove/100, 1);
        }
        );
    }

}
