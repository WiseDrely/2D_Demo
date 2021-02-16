using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPos : MonoBehaviour
{
    static public HitPos instance; 

    public LayerMask LM;    //Layer�㣨δʹ�ã�
    public Vector3 Moupos;                          //�������
    public Vector3 MouposToGround;                  //������굽���������
    [Range(0f, 20f)] public float RayRange = 20;    //���߳���

    Vector3 screenPosition;//���������������ת��Ϊ��Ļ����
    Vector3 mousePositionOnScreen;//��ȡ�������Ļ����Ļ����
    Vector3 mousePositionInWorld;//�������Ļ����Ļ����ת��Ϊ��������
    void Awake()
    {
        instance = this;
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        transform.position = MouseFollow();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, RayRange);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                MouposToGround = hit.point;
                //print(MouposToGround);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, -transform.up * RayRange);
    }
    public Vector3 MouseFollow()
    {
        //��ȡ���������У������У���λ�ã�ת��Ϊ��Ļ���ꣻ
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //��ȡ����ڳ���������
        mousePositionOnScreen = Input.mousePosition;
        //�ó����е�Z=��������Z
        mousePositionOnScreen.z = screenPosition.z;
        //������е�����ת��Ϊ��������
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //�����������ƶ�
        return new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, mousePositionInWorld.z);
    }
    public Vector3 ReturnMouseTOGroudPos()
    {
        return MouposToGround;
    }
}
