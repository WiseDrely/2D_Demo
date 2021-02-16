using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public GameObject In;

    [Header("���ﲻ�ö���")]
    public ExBullet EX;
    public GameObject GunPoint;
    public StringBuilder Skill = new StringBuilder();
    public Dictionary<string, Action> SkillData = new Dictionary<string, Action>();  //������ĺ���Ҫ�޲��޷���ֵ

    public HitPos hitPos;


    //��ǰ����д�������ɵ�λ��
    //���ֵļ���gameobject�����˶���أ�����ŵ��������gameobject
    [Header("�Ѽ�������Ҫ��Gameobject������")]
    [Header("����ļ��������ȹ���������򳡾��ļ���")]
    public GameObject qqq;  //����ѩ
    public GameObject qqw;
    public GameObject wwq;
    public GameObject eeq;  //���


    public GameObject aba;
    public GameObject bab;
    void Start()
    {
        EX = ExBullet.instance;
        hitPos = HitPos.instance;
        Combine();
        SkillData.Add("qqq", QQQ);
        SkillData.Add("qqw", QQW);
        SkillData.Add("qqe", QQE);
        SkillData.Add("wwe", WWE);
        SkillData.Add("wwq", WWQ);
        SkillData.Add("eeq", EEQ);
        SkillData.Add("eee", EEE);
        SkillData.Add("eew", EEW);       //��д�õļ��ܼӵ��ֵ�����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (SkillData.ContainsKey((Skill.ToString())))
            {
                StartCoroutine(InvokSkill());
            }
            else {
                print("��");
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
                Combine();
        }
    }
    void Combine()
    {
        Skill.Remove(0, Skill.Length);
        Skill.Append(EX.shoot[0]).Append(EX.shoot[1]).Append(EX.shoot[2]);
    }

    IEnumerator InvokSkill()
    {
        In.SetActive(true);
        Time.timeScale = 0.3f;
        yield return new WaitUntil(()=>In.activeInHierarchy==false);
        Time.timeScale = 1f;
        SkillData[Skill.ToString()].Invoke();
        yield return null;
    }

    //�Ѽ���ȫ��д��������
    void EEW()
    {
        GameObject bullet = DUIXIANGCHI1.instance.GetPooledObject("eew");//�Ӷ����ʵ�����ӵ�
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = aba.transform.position;         //�ӵ�����һ�̵ġ�λ�á���ֵ
            bullet.transform.eulerAngles = transform.eulerAngles;   //�ӵ�����һ�̵ġ����򡱸�ֵ
            bullet.transform.up = bullet.transform.position - hitPos.ReturnMouseTOGroudPos();
        }
    }
    void QQQ()
    {
        qqq.SetActive(true);
    }
    void EEQ()      //��ܣ������ǰ�͹��ڽ�ɫ���ϣ�ֱ��Active����
    {
        eeq.SetActive(true);
    }
    void EEE()
    {
        GameObject bullet = DUIXIANGCHI1.instance.GetPooledObject("eee");//�Ӷ����ʵ�����ӵ�
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = GunPoint.transform.position;         //�ӵ�����һ�̵ġ�λ�á���ֵ
            bullet.transform.eulerAngles = GunPoint.transform.eulerAngles;   //�ӵ�����һ�̵ġ����򡱸�ֵ
        }
    }
    void WWE()
    {
        //GameObject bullet = DUIXIANGCHI1.instance.GetPooledObject("wwe");//�Ӷ����ʵ�����ӵ�
        //if (bullet != null)
        //{
        //    //bullet.SetActive(true);
        //    //bullet.transform.position = transform.position;         //�ӵ�����һ�̵ġ�λ�á���ֵ
        //    //bullet.transform.eulerAngles = transform.eulerAngles;   //�ӵ�����һ�̵ġ����򡱸�ֵ


        //    bullet.SetActive(true);
        //    bullet.transform.position = new Vector2(hitPos.ReturnMouseTOGroudPos().x, aba.transform.position.y);         //�ӵ�����һ�̵ġ�λ�á���ֵ
        //    bullet.transform.eulerAngles = transform.eulerAngles;   //�ӵ�����һ�̵ġ����򡱸�ֵ
        //    //bullet.transform.up = bullet.transform.position - hitPos.ReturnMouseTOGroudPos();
        //    bullet.transform.Rotate(new Vector3(0, 0, -180));       //Ԥ�������﷽�����������ģ����Է���ǰҪ��ת�ɺ���
        //}
        StartCoroutine(ieWWE());
    }
    IEnumerator ieWWE()
    {
        Vector2[] a = new Vector2[7];
        a[1]=new Vector2(hitPos.ReturnMouseTOGroudPos().x, aba.transform.position.y);
        for (int i = 2; i <7; i++)
        {
            a[i] = new Vector2(hitPos.ReturnMouseTOGroudPos().x + UnityEngine.Random.Range(-3,3), aba.transform.position.y);
        }
        for (int i = 1; i <7; i++)
        {
            GameObject bullet = DUIXIANGCHI1.instance.GetPooledObject("wwe");//�Ӷ����ʵ�����ӵ�
            if (bullet != null)
            {
                bullet.SetActive(true);
                bullet.transform.position = a[i];
                bullet.transform.eulerAngles = transform.eulerAngles;   //�ӵ�����һ�̵ġ����򡱸�ֵ
                bullet.transform.Rotate(new Vector3(0, 0, -180));       //Ԥ�������﷽�����������ģ����Է���ǰҪ��ת�ɺ���
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return null;
    }
    void QQE()
    {
        GameObject bullet = DUIXIANGCHI1.instance.GetPooledObject("qqe");//�Ӷ����ʵ�����ӵ�
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = GunPoint.transform.position;         //�ӵ�����һ�̵ġ�λ�á���ֵ
            bullet.transform.eulerAngles = GunPoint.transform.eulerAngles;   //�ӵ�����һ�̵ġ����򡱸�ֵ
            bullet.transform.Rotate(new Vector3(0, 0, -90));
        }
    }
    void QQW()
    {
        qqw.SetActive(true);
    }
    void WWQ()
    {
        wwq.SetActive(true);
    }
}
