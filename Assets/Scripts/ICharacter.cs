using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacter : MonoBehaviour,IShootAble
{
    public string bulletName;

    public string weaponName;
    public float attackSpeed=1;



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
        weapon.SetAttackSpeed(attackSpeed);
        
       
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
        
        CharacterUpdate();

    }

    public virtual void CharacterUpdate()
    {

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
        if (status.isDied())
        {
            Die();
        }
    }

    public void CostMp(int cost)
    {
        status.CostMp(cost);
    }

  

    public string GetBulletName()
    {
        return bulletName;
    }

    public void Die()
    {
        
        Destroy(this);
    }
}
