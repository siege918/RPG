using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    public int BPM;
    private float framesPerHop;
    private float frameCounter = 0;
    public float minScale = .65f;
    private float initialY;

	// Use this for initialization
	void Start () {
        initialY = GetComponent<Transform>().localScale.y;

        framesPerHop = (1f / Time.fixedDeltaTime) / (float)(BPM / 60);
        Debug.Log(framesPerHop);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (framesPerHop - frameCounter <= 0)
        {
            frameCounter -= framesPerHop;
            GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, initialY, GetComponent<Transform>().localScale.z);
        }
        else if (framesPerHop - frameCounter == 1)
        {
            GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, (((1f - minScale) / 2f) + minScale) * initialY, GetComponent<Transform>().localScale.z);
        }
        else
        {
            float delta = (1f - minScale) * ((float)frameCounter / (float)framesPerHop);
            GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, (1 - delta) * initialY, GetComponent<Transform>().localScale.z);
        }
        frameCounter++;
	}
}
