using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreePlayScript : MonoBehaviour
{

    public GameObject LeftStick;
    public GameObject RightStick;
    public AudioSource Snare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Snare") {
            Snare.Play();
        }
    }
    
}
