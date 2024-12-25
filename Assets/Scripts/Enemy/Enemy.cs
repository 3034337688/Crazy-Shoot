using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : LiveDamage
{

    public Transform _target;
    private Animator _anim;
    private AIPath aipath;

    [Header("����")]
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
        if (_anim == null) Debug.Log("�������Ϊ��");
        else
        {
            Debug.Log("�ҵ��˶������");
        }
        aipath = GetComponent<AIPath>();
        if(aipath==null)
        {
            Debug.Log("ai���Ϊ��");
        }

        base.Start();


    }

    void Update()
    {

        if (_target == null) return;
        aipath.destination = _target.transform.position;
        if(!aipath.reachedDestination)
        {

            Debug.Log("û�е����յ�");
            _anim.SetBool("isBeetleWalk", true);

        }
        else
        {
            Debug.Log("�����յ�");
           _anim.SetBool("isBeetleWalk", false);

            //�������
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
        Vector2 hitDirection = (_target.transform.position - this.transform.position).normalized;//���򼴿ɣ���һ������
        RaycastHit2D hit = Physics2D.Raycast(startHitPoint, hitDirection,aipath.endReachedDistance+2f, _beetleLayer);
        Debug.DrawLine(this.transform.position, _target.transform.position, Color.blue);
        if (hit.collider == null)
        {
            Debug.Log("�����Ѿ�����");
        }
        IDamage beetleIDamage = hit.transform.GetComponent<IDamage>();
        if (beetleIDamage != null) Debug.Log("���˵õ��˽ӿ���Ϣ");
        beetleIDamage?.TakeDamage(20);




    }
}
