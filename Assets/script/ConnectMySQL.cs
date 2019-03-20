using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectMySQL : MonoBehaviour {
    

    // Use this for initialization
    IEnumerator Start () {

        WWW itemsData = new WWW("http://http://libraryseat.applinzi.com/experience/InputDataForFile.php");
        yield return itemsData;
        GetComponent<AutoExp>().data = Convert.ToInt32(itemsData.text);
        print(GetComponent<AutoExp>().data);
    }
}
