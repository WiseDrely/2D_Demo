using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArea : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask LM;

    [Range(0f, 100f)] public float force;
    public Vector3 a;

    Vector3 screenPosition;//���������������ת��Ϊ��Ļ����
    Vector3 mousePositionOnScreen;//��ȡ�������Ļ����Ļ����
    Vector3 mousePositionInWorld;//�������Ļ����Ļ����ת��Ϊ��������
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //a = MouseFollow()-transform.position;
        transform.position = MouseFollow();
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        collision.gameObject.transform.right= Vector3.Slerp(collision.gameObject.transform.right, a.normalized, force / 100);
    //    }
    //}

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
}
