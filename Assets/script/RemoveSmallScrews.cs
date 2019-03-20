using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSmallScrews : MonoBehaviour
{
    private int x = 0;

    public float TranslateSpeed = 0.2f;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -TranslateSpeed * Time.deltaTime, 0);
        x += 1;
        if (x >= 50)
        {
            TranslateSpeed = 0f;
        }
        if (x >= 125)
        {
            transform.Translate(0, -50, 0);
            Destroy(GetComponent<RemoveSmallScrews>());
        }
    }
}
