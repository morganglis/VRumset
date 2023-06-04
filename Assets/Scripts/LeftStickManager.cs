using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftStickManager : MonoBehaviour
{
    public AudioClip input;
    public AudioSource Snare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float snareStart = 0f;
    private float snareCooldown = 0.5f;

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Snare" && Time.time > snareStart + snareCooldown) 
        {
            Snare.PlayOneShot(input);
            snareStart = Time.time;
            
        }
    }

private IEnumerator DelayedAction()
{
    yield return new WaitForSeconds(1);
    print("I was printed after a delay of 0.5 seconds!");
}
}