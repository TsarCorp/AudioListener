using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(LineRenderer))]
public class LineVisualizer : MonoBehaviour {
    public GameObject objectPrefab;
    public GameObject objectPlayer;
    public float spawnThershold = 0.5f;
    public int frequency = 0;
    public float spawnThershold2 = 0.1f;
    public int frequency2 = 0;
    public float spawnThershold3 = 0.01f;
    public int frequency3 = 3;

    public float size = 10.0f;
    public float amplitude = 1.0f;
    public FFTWindow fftWindow;
    //private int samples = 64;   // must be power of 2
    private float[] samples = new float[64];
    private LineRenderer lineRenderer;
    private Rigidbody rb;
    private ParticleSystem particleSys;
    private float stepSize;

    public int cutoffSample = 32;

	void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        particleSys = GetComponent<ParticleSystem>();
         rb = objectPlayer.GetComponent<Rigidbody>();
        //lineRenderer.SetVertexCount(samples.Length);
        lineRenderer.numPositions = cutoffSample ;
        stepSize = size/cutoffSample;
    }
	
	// Update is called once per frame
	void Update () {
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        if (samples[frequency2] > spawnThershold2)
        {
            //print (samples[frequency2]);
            var mainSub = particleSys.main;
            mainSub.startColor = Color.black;
            mainSub.startSpeed = 3;
            //rb.AddForce(transform.forward * 100);
            //set the static var in the sprite script
            spriteSize.setSize = 10000;

            Instantiate(objectPrefab, new Vector3(8, 5, 0), transform.rotation);

        }


        if (samples[frequency3] > spawnThershold3)
        {
            //print (samples[frequency2]);
            var mainSub = particleSys.main;
            mainSub.startSpeed = 1;
            //rb.AddForce(transform.forward * 10);
            //set the static var in the sprite script
            

        }

        if ((samples[frequency2] > spawnThershold2) ^ (samples[frequency3] > spawnThershold3))
        {
            Instantiate(objectPrefab, new Vector3(0, 5, 0), transform.rotation);
        }



        if (samples[frequency] > spawnThershold)
        {
            //print (samples[frequency]);
            //rb.AddForce(transform.forward * 1000);
            var mainSub = particleSys.main;
            mainSub.startSpeed = 6;

            //create an object
            Instantiate(objectPrefab, new Vector3 (-8,5,0), transform.rotation);

            //change particle color
            
            mainSub.startColor = Color.white;
        }

       

        int i = 0;

        for (i = 0; i < cutoffSample; i++) {
            Vector3 position = new Vector3(i * stepSize - size / 2.0f, samples[i] * amplitude, 0.0f);
            lineRenderer.SetPosition(i, position);
          
        }
      //  foreach (float sample in samples)
    //    {
    //        Vector3 position = new Vector3(i*stepSize-size/2.0f,sample*amplitude,0.0f);
    //        lineRenderer.SetPosition(i, position);
    //            i++;
    //    }
	}
}
