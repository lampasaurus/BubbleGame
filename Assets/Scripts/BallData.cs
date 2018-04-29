using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallData : MonoBehaviour {
    public int type;
    SpriteRenderer srenderer;
    public List<GameObject> chain;

	// Use this for initialization
	void Start () {
        srenderer = GetComponent<SpriteRenderer>();
        chain = new List<GameObject>();
        chain.Add(gameObject);

        if (type != -1)
        {
            type = (int)Random.Range(0, 4);
        }
        AssignColour();
	}

    /*
     * Sets ball's colour based on generated types
     * */
    void AssignColour()
    {
        switch (type) {
            case -1:
                srenderer.color = Color.black;
                break;
            case 0:
                srenderer.color = Color.blue;
                break;
            case 1:
                srenderer.color = Color.red;
                break;
            case 2:
                srenderer.color = Color.green;
                break;
            case 3:
                srenderer.color = Color.yellow;
                break;
            default:
                Debug.Log("Something went wrong when deciding ball type");
                Destroy(gameObject);
                break;
        }
    }

    /*
     * "Links" balls together, and if 4 balls are linked, destroy them and add score"
     * */
    public void MergeChain(List<GameObject> newChain)
    {
        //Merges the chains of linked balls
        foreach(var x in newChain)
        {
            if (!chain.Contains(x)){
                chain.Add(x);
            }
        }
        newChain = chain;
        
        //Destroys balls if more than 4 are linked
        if(chain.Count >= 4)
        {
            foreach(var x in chain)
            {
                Destroy(x);
            }
        }

        //TODO add scoring
    }

    /*
     * Debug function to read chain lists
     * */
    public void DebugChain()
    {
        string s = "";
        BallData tmpData;
        foreach (var x in chain)
        {
            tmpData = x.GetComponent<BallData>();
            s += tmpData.type + ", ";
        }
        //Debug.Log(s);
    }
}
