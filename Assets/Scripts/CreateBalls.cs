using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBalls : MonoBehaviour {
    float time;
    float difTime;
    public int delay;   //The initial number of frames between spawning a ball
    public int distance;    //The distance a ball will spawn from the center
    public int difficultyDelay;     //The number of frames between each difficulty increase
    public int difficultyIncrement; //The number of frames subtracted from delay each difficulty increase
    public int minDelay;
    public GameObject ball;
	// Use this for initialization
	void Start () {
        time = Time.frameCount;
        difTime = Time.frameCount;
        if (distance == 0) distance = 20;
	}
	
	// Update is called once per frame
	void Update () {
        //Spawn a ball
        if (Time.frameCount > time + delay)
        {
            time = Time.frameCount;
            Vector3 spawnDir = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
            spawnDir.Normalize();

            Instantiate(ball, spawnDir * distance, Quaternion.identity);
        }
        //Increment difficulty
        if(Time.frameCount > difTime + difficultyDelay)
        {
            delay -= difficultyIncrement;
            difTime = Time.frameCount;
            if (delay < minDelay) delay = minDelay;
        }
	}
}
