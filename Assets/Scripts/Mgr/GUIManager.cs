using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public static class GUIManager {

   static List<GameObject> DialougueUIs = new List<GameObject>();
   
    /// <summary>
    /// 是否直接显示,ui名称,父物体名
    /// </summary>
    /// <param name="ps,"></param>
    /// <returns></returns>
    public static GameObject ShowView(bool show,params object[] ps)
    {
        string path = "UI/Prefab/" + ps[0].ToString();

        GameObject tmp = (GameObject)Resources.Load(path, typeof(GameObject));
        GameObject parent =( ps.Length>1?GameObject.Find(ps[1].ToString()) :GameObject.Find("Canvas"));  
        GameObject IGO= GameObject.Instantiate(tmp,new Vector3(-1000,-1000,0),Quaternion.identity);
        IGO.transform.SetParent(parent.transform);
        //根据是否有第三个参数决定显示位置
        if(show)
            IGO.transform.localPosition =Vector3.zero;//一开始不显示
       
        IGO.transform.localScale = new Vector3(1, 1, 1);
        //Debug.Log("实例化UI-" + ps[0].ToString() + "至" + ps[1].ToString());
        return IGO;
    }
    public static GameObject ShowView(string name,Vector3 position)
    {
        string path = "UI/" + name;

        GameObject tmp = (GameObject)Resources.Load(path, typeof(GameObject));
        GameObject parent =GameObject.Find("Canvas");
        
        GameObject IGO = GameObject.Instantiate(tmp,position,parent.transform.rotation,parent.transform);
        //IGO.transform.SetParent(parent.transform);
        
        IGO.transform.localScale = new Vector3(1, 1, 1);
       
        return IGO;
    }
    



}
