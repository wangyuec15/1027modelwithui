using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class forFurnitureCollect : MonoBehaviour
{

    public int n;
    public GameObject curFurniture;


    //材质
    public Material outline;
    public Material normal;
    public Material red;


    private Vector3 lins;
    private bool push = false;

    private Vector3 targetScreenPoint;

    private Vector3 offset;
    private Vector3 pos;



    void OnMouseDown(){
    //{
        //if (gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture != null)
        //curFurniture.GetComponent<Renderer>().material = outline;//当鼠标滑过时改变物体颜色为蓝色  
        //targetScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = curFurniture.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
       // curFurniture.transform.position = new Vector3(pos.x + offset.x, pos.y + offset.y, 0);

    }

    void OnMouseDrag()
    {

        //Debug.Log("dowwwwwn");

        ////if (Input.GetMouseButtonDown(0))
        ////{

        //pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

        ////curFurniture.transform.position = new Vector3(pos.x + offset.x, pos.y + offset.y, 0);
        //Debug.Log("dowwwwwn");


        //   }
    }


    void OnMouseUp()
    {
      //  curFurniture.GetComponent<Renderer>().material = normal;


    }




    void OnCollisionEnter(Collision collision)
    {

        curFurniture.GetComponent<Renderer>().material = red;

        //记一下刚接触的位置
        lins = curFurniture.transform.position;
        push = true;

        if (push)
        {
            //记录刚碰撞的位置
            curFurniture.transform.position = lins;
        }
    }

    //有相交的时候把正在移动的物体推出来变成相邻的
    void OnCollisionStay(Collision collision)
    {

        if (push)
        {
            curFurniture.transform.position = lins;
        }
    }

    //不相交了换成普通描边
    void OnCollisionExit(Collision collision)
    {
        //if (isSelected )
        //{
        curFurniture.GetComponent<Renderer>().material = outline;
        //}
        push = false;
    }

    void Update()
    {

    if (Input.GetMouseButtonDown(0)){
            targetScreenPoint = Camera.main.WorldToScreenPoint(curFurniture.transform.position);

            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

            if(pos.x>100){
                curFurniture.GetComponent<Renderer>().material = normal;
                curFurniture = null;
            }

        if (curFurniture != null)
            curFurniture.GetComponent<Renderer>().material = outline;//当鼠标滑过时改变物体颜色为蓝色  
            targetScreenPoint = Camera.main.WorldToScreenPoint(curFurniture.transform.position);
        offset = curFurniture.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
    }



        if(Input.GetMouseButton(0)){
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

            curFurniture.transform.position = new Vector3(pos.x + offset.x, pos.y + offset.y, 0);
        }
    }

}
