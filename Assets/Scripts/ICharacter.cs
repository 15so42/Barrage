using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacter : MonoBehaviour
{
    public string bulletName;

    public string weaponName;
    //武器
    public IWeapon weapon;

    //public float attackSpeed=1;

    void Start()
    {
        Init();
    }
    //初始化方法
    public virtual void Init()
    {
        

        weapon = (IWeapon)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(weaponName, false);
        weapon.shooter = this;
        //weapon.attackSpeed = attackSpeed;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        weapon.Tick();
    }

    public GameObject GetObj()
    {
        return gameObject;
    }
    public Vector3 GetPos()
    {
        return gameObject.transform.position;
    }

    
    public virtual void Fire()
    {
        weapon.Fire();
    }

    //血量
    public IStatus status=new IStatus();

    public void GetDamage(int damage)
    {
        status.GetDamage(damage);
    }

    public void CostMp(int cost)
    {
        status.CostMp(cost);
    }

    





}
