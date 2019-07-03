using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMovement:MonoBehaviour
{
    

    public GameObject[] targets;

    public bool moveAble;

    int index;//当前接近的路径点的Id

    public float speed = 2.5f;

    private void Update()
    {
        if (moveAble)
        {

            Move();
            Debug.DrawRay(transform.position, GetVec());
        }
    }

    //每帧调用
    public  void Move()
    {
        transform.position += GetVec() * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, targets[index].transform.position) < 0.5f)
        {
            if (index == targets.Length - 1)
            {
                Die();
            }
            else
            {
                index++;
            }
            
        }
    }

    public Vector3 GetVec()
    {
        return targets[index].transform.position - transform.position;
    }

    public void CanMove()
    {
        moveAble = true;
    }

    public void Die()
    {
        Destroy(transform.parent);
    }
}
