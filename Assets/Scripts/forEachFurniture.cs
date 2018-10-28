using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class forEachFurniture : MonoBehaviour {
    //材质
    public Material outline;
    public Material normal;
    public Material red;


    private Vector3 lins;
    private bool push = false;

    private Vector3 targetScreenPoint;

    private Vector3 offset;
    private Vector3 pos;



    void OnMouseDown()
    {
        if (gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture != null)
        {
            gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture.GetComponent<Renderer>().sharedMaterial.SetColor("_OutlineColor", Color.blue);

            gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture.GetComponent<Renderer>().material = normal;
        }

        gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture = null;

        gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture = gameObject;
        gameObject.GetComponent<Renderer>().material=outline;//当鼠标滑过时改变物体颜色为蓝色  
        targetScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

    }

    //void OnMouseDrag(){
     //   //if (Input.GetMouseButtonDown(0))
     //   //{
            
     //       pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));

     //   gameObject.transform.position = new Vector3(pos.x+offset.x, pos.y+offset.y, 0);
     //       Debug.Log("dowwwwwn");


     ////   }
  //  }


    void OnMouseUp()
    {
      //  gameObject.GetComponent<Renderer>().material=normal;//当鼠标滑过时改变物体颜色为蓝色  


    }




    void OnCollisionEnter(Collision collision)
    {
        //if(gameObject==gameObject.transform.parent.GetComponent<forFurnitureCollect>().curFurniture)
            gameObject.GetComponent<Renderer  >().sharedMaterial.SetColor("_OutlineColor", Color.red);

            //记一下刚接触的位置
        lins = gameObject .transform.position;
            push = true;

        if (push)
        {
            //记录刚碰撞的位置
            gameObject.transform.position=lins;
        }
    }

    //有相交的时候把正在移动的物体推出来变成相邻的
    void OnCollisionStay(Collision collision)
    {
        
        if (push)
        {
            gameObject.transform.position=lins;
        }
    }

    //不相交了换成普通描边
    void OnCollisionExit(Collision collision)
    {
        //if (isSelected )
        //{
        gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_OutlineColor", Color.blue);
        //}
        push = false;
    }

    void Update()
    {

    }

}
