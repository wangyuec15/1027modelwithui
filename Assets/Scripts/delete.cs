using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class delete : MonoBehaviour {
    private GameObject todelete;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(myAction);

	}
	
	// Update is called once per frame
	void Update () {
        todelete = GameObject.Find("sofaCollecter").GetComponent<forFurnitureCollect>().curFurniture;
	}

    void myAction()
    {
        Debug.Log(todelete);

        Destroy(todelete);
        Debug.Log("haha");

    }
}
