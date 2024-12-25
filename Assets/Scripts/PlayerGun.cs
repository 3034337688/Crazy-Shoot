using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform _firePosition;
    public Vector3 _offestFireEffective;
    public Transform _linePrefabs;
    public Transform _fireFlashPrefabs;
    [SerializeField] private float _offestAngle;

    [Header("����ϵͳ")]
    public FireMode fireMode = FireMode.Burst;//Ĭ�����������ģʽ
    public bool isReloading;
    public bool isTriggerRelease;
    public float nextShotTime;
    public int shotsNumber;
    public int clipSize;
    public int fireRate;

    [Header("射线检测")]
    [SerializeField] private LayerMask _layer;
    [SerializeField] private GameObject _SpakePrefabs;

    [Header("状态机")]
    public PopupText _popupText;




    //ʵ��ǹ�ڻ����ͼ
    void FireFlash()
    {
        Transform fireFlashPrefabs = Instantiate(_fireFlashPrefabs, _firePosition.transform);

        //fireFlashPrefabs.SetParent(_firePosition);
        Destroy(fireFlashPrefabs.gameObject, 0.1f);
    }


    //��ȴ��ʱ��
    void Cooldown()
    {

    }

    //��Ұ�סǹ

    public void GunOnTriggerHold()
    {
        if (isReloading) return;
        if (shotsNumber >= clipSize)
        {
            //����������TODO
            return;
        }

        switch(fireMode)
        {
            case FireMode.Single: //��ߵ��������ģʽ�е����⣬�Լ�����ģʽ����ƶ����������ٲ����
                {
                    if (isTriggerRelease) return;
                    Shoot();
                    isTriggerRelease = true;
                    break;
                }

            case FireMode.Burst:
            {
                    if (Time.time < nextShotTime) return;
                    nextShotTime = Time.time + 1f / (float)fireRate;

                    Shoot();
                    Debug.Log("��סfire");
                    break;
            }
        }


/*        Shoot();
        Debug.Log("��סfire");*/
    }

    //����ɿ�ǹ
    public void GunOnTriggerRelease()
    {
        Debug.Log("�ɿ�fire");
    }

    //���װ��
    public void GunReload()
    {
        Debug.Log("װ��");
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        Debug.Log("����װ��");
        isReloading = true;
        yield return new WaitForSeconds(2f);  //װ��ʱ����2��
        shotsNumber = 0;
        isReloading = false;

    }


    /// <summary>
    /// ����ƵĿ���ķ�����һ����װ
    /// </summary>
    private void Shoot()
    {
        shotsNumber++;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
        Vector2 firePosition = _firePosition.position;

        //�õ���������
        Vector2 shootDirection;

        //������������̫��,��Ʒ����ж�����
        if (Vector2.Distance(firePosition, mousePosition2D) > 0.5f) shootDirection = mousePosition2D - new Vector2(_firePosition.position.x, _firePosition.position.y);
        else
        {
            shootDirection = transform.up;
        }

        //��ⰴ�¿���

        Debug.Log("����fire");
        //Debug.DrawLine(new Vector2(_firePosition.position.x, _firePosition.position.y), shootDirection*100, Color.red);

        
        //计算line的旋转角度
	    float lineAngle = Mathf.Atan2(shootDirection.x, shootDirection.y) * Mathf.Rad2Deg;
        Quaternion lineRation = Quaternion.AngleAxis(-lineAngle + _offestAngle, Vector3.forward);//��ʱ��ת�� 

        //Transform linePosition = Instantiate(_linePrefabs, _firePosition.position, lineRation);
        //Destroy(linePosition.gameObject, 0.1f);


        //射线检测
        RaycastHit2D hit = Physics2D.Raycast(_firePosition.position, this.transform.up, _layer);
        if (hit.collider == null)
        {
            Transform linePosition = Instantiate(_linePrefabs, _firePosition.position, lineRation);
            Destroy(linePosition.gameObject, 0.1f);
            Debug.Log("没有碰到对象");
        }
        else
        {
            Debug.DrawLine(_firePosition.position, hit.point, Color.red);
            Debug.Log("射线检测碰到了对象");
            GameObject spakePrefab = Instantiate(_SpakePrefabs, hit.point, Quaternion.identity);

            //重新设置line的长度
            Transform linePosition = Instantiate(_linePrefabs, _firePosition.position, lineRation);
            LineRenderer line= linePosition.GetComponent<LineRenderer>();
            Vector3 hitPos = new Vector3(hit.point.x, hit.point.y, -1);  //中间值，用来扩展z轴的层级为-1，这样line才能正确显示
            line.useWorldSpace = true;
            line.SetPosition(0, _firePosition.position);
            line.SetPosition(1, hitPos);
            Destroy(linePosition.gameObject, 0.1f);
            Destroy(spakePrefab, 0.2f);

            //实现对木箱的伤害
            IDamage iDamage = hit.transform.GetComponent<IDamage>();
            if (iDamage == null) Debug.Log("没有得到木箱接口");
            iDamage?.TakeDamage(10);
            _popupText.Create(hit.point, Random.Range(0, 100), Random.Range(0, 100) < 30);
           



        }
        FireFlash();

    }

}


