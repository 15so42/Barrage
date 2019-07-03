using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public List<GameObject> bullets=new List<GameObject>();
    public float speed;

    //人妖状态之间切换
    public float bMonster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //debug查看bullet对象池
        bullets = BulletPool.bullets;

        //移动,带缓冲效果。考虑移除缓冲效果
        float h = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float v = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        transform.Translate(new Vector3(h, 0, v) *speed* Time.deltaTime);
        transform.Translate(transform.forward*3 * Time.deltaTime,Space.World);
    }
}
