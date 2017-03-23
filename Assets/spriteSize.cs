using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSize : MonoBehaviour {

    private SpriteRenderer sr;
    public static float setSize;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        setSize = 1;

    }
	
	// Update is called once per frame
	void Update () {


        if (transform.localScale.x < 10000)
        {
            transform.localScale = transform.localScale * setSize;
        }


        if (transform.localScale.x > 1) { 
        transform.localScale = transform.localScale / 2;
            setSize = 1;
        }
    }
}
