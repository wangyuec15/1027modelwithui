﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInfo : MonoBehaviour,IBeginDragHandler, IDragHandler,IEndDragHandler
{
    private Vector3 targetScreenPoint;
    private GameObject board;
    private GameObject target;
    //private GameObject pict;
    public GameObject sofa ;
    public Texture picture;
    private Vector3 offset;
    private Vector3 pos;
    public Color paint;

    void Start(){
        board = Resources.Load("pict") as GameObject;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        
        gameObject.GetComponent<Image>().color =Color.black;

        targetScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
        target = Instantiate(board);
        target.GetComponent<Renderer>().sharedMaterial.mainTexture = picture;

        target.transform.parent = GameObject.Find("Canvas").transform;

    }

    void Update() { 
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.5f);

        pos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
        if(pos.x>100){
            target.transform.position =new Vector3( pos.x+offset.x-14.4f,pos.y+offset.y,-10);
        }else{
            Destroy(target);
            target  = Instantiate(sofa);
            target.transform.parent = GameObject.Find("sofaCollecter").transform;
            target.transform.parent.GetComponent<forFurnitureCollect>().curFurniture = target;
            target.transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        if(pos.x>100){

            target.transform.localScale = new Vector3(1f - Time.deltaTime * 0.002f, 1f - Time.deltaTime * 0.002f, 1f);

            Destroy(target);
            target = null;
        }
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
