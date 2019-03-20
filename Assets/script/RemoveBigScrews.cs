using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBigScrews : MonoBehaviour
{
    private int x = 0;

    public float TranslateSpeed = 0.2f;
    public float RotateSpeed = 273f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -TranslateSpeed * Time.deltaTime, 0);
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
        x += 1;
        if(x >= 75)
        {
            TranslateSpeed = 0.5f;
            RotateSpeed = 0f;
        }
        if (x >= 100)
        {
            TranslateSpeed = 0f;
        }
        if (x >= 125)
        {
            transform.Translate(0, -50, 0);
            Destroy(GetComponent<RemoveBigScrews>());
        }
    }
}
