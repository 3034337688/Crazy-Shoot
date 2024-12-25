using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : LiveDamage
{

    public Transform _target;
    private Animator _anim;
    private AIPath aipath;

    [Header("攻击")]
    public float hitRate;
    public float lastHitTime;
    public LayerMask _beetleLayer;



    // Start is called before the first frame update
    public override void Start()
    {
        if(_target==null)
        {
            _target = GameObject.Find("Player").transform;
        }

        
        _anim = GetComponent<Animator>();
        if (_anim == null) Debug.Log("动画组件为空");
        else
        {
            Debug.Log("找到了动画组件");
        }
        aipath = GetComponent<AIPath>();
        if(aipath==null)
        {
            Debug.Log("ai组件为空");
        }

        base.Start();


    }

    void Update()
    {

        if (_target == null) return;
        aipath.destination = _target.transform.position;
        if(!aipath.reachedDestination)
        {

            Debug.Log("没有到达终点");
            _anim.SetBool("isBeetleWalk", true);

        }
        else
        {
            Debug.Log("到达终点");
           _anim.SetBool("isBeetleWalk", false);

            //攻击玩家
            if (Time.time > lastHitTime + 1 / hitRate)
            {
                BeetleHit();
                lastHitTime = Time.time;
            }

        }

    }

    void BeetleHit()
    {
        Vector2 startHitPoint = this.transform.position;
        Vector2 hitDirection = (_target.transform.position - this.transform.position).normalized;//方向即可，归一化处理
        RaycastHit2D hit = Physics2D.Raycast(startHitPoint, hitDirection,aipath.endReachedDistance+2f, _beetleLayer);
        Debug.DrawLine(this.transform.position, _target.transform.position, Color.blue);
        if (hit.collider == null)
        {
            Debug.Log("主角已经死了");
        }
        IDamage beetleIDamage = hit.transform.GetComponent<IDamage>();
        if (beetleIDamage != null) Debug.Log("敌人得到了接口信息");
        beetleIDamage?.TakeDamage(20);




    }
}
