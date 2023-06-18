using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightRingManager : MonoBehaviour
{
    public GameObject rightRingModel;
    public GameObject leftRingModel;

    void OnCollisionEnter(Collision col) {


        if (col.gameObject.tag == "rightRing") 
        {
             rightRingModel.SetActive(false);
             leftRingModel.SetActive(true);
        }
    }
    
}
