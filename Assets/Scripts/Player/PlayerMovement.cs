using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public List<GameObject> bullets=new List<GameObject>();
    public List<IEnemy> enemys=new List<IEnemy>();
    public float speed;
    Camera camera;
    public float cameraMoveSpeed;
    //人妖状态之间切换
    public float bMonster;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        cameraMoveSpeed = BarrageGame.Instance.GetMoveSpeed();
        
    }

    // Update is called once per frame
    void Update()
    {
        //debug查看bullet对象池
        bullets = BulletPool.bullets;
        enemys = IEnemy.enemys;


        float h = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float v = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);

        //边界控制
        if (transform.position.x >= 21&&h>0 || transform.position.x <= -21 && h < 0 )            
        {
            h = 0;
        }
        if( (transform.position.z - camera.transform.position.z) >= 12 && v > 0
            || (transform.position.z - camera.transform.position.z) <= -12 && v < 0)
        {
            v = 0;
        }


        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        transform.Translate(transform.forward * cameraMoveSpeed * Time.deltaTime, Space.World);
    }
}
