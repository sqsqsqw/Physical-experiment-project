using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallSmallScrews : MonoBehaviour
{
    private int x = 0;

    public float TranslateSpeed = 0f;

    // Use this for initialization
    void Start () {
        transform.Translate(0, 50, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        x += 1;
        transform.Translate(0, TranslateSpeed * Time.deltaTime, 0);
        if (x >= 25)
        {
            TranslateSpeed = 0.2f;
        }
        if(x >= 75)
        {
            TranslateSpeed = 0f;
        }
        if (x >= 125)
        {
            Destroy(GetComponent<InstallSmallScrews>());
        }
    }
}
