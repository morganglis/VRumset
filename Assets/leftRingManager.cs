using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftRingManager : MonoBehaviour
{
    public GameObject rightRingModel;
    public GameObject leftRingModel;

    void OnCollisionEnter(Collision col) {


        if (col.gameObject.tag == "leftRing") 
        {
             rightRingModel.SetActive(true);
             leftRingModel.SetActive(false);
        }
    }
    
}
