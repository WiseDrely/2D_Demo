using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class createy : MonoBehaviour
{
    [Header("���ﲻ�ö���")]
    ExBullet EX;
    public bool Reset=false;
    public StringBuilder Skill = new StringBuilder();
    public Dictionary<string, Action> UseSkill = new Dictionary<string, Action>();  //������ĺ���Ҫ�޲��޷���ֵ


    [Header("�Ѽ�������Ҫ��Gameobject������")]        //����GameobjectҲ��
    //��ǰ����д�������ɵ�λ��
    public GameObject qqq;
    public GameObject eew;
    public GameObject eeq;
    void Awake()
    {
        EX = ExBullet.instance;
        Combine();
        UseSkill.Add("eeq", EEQ);
        UseSkill.Add("qqq", QQQ);
        UseSkill.Add("eew", EEW);       //��д�õļ��ܼӵ��ֵ�����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (UseSkill.ContainsKey((Skill.ToString())))
            {
                UseSkill[Skill.ToString()].Invoke();
            }
            else {
                print("��");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Combine();
        }
    }
    void Combine()
    {
        Skill.Remove(0, Skill.Length);
        Skill.Append(EX.shoot[0]).Append(EX.shoot[1]).Append(EX.shoot[2]);
    }

    //�Ѽ���ȫ��д��������
    void EEW()
    {
        Instantiate(eew, transform.position, transform.rotation);
    }
    void QQQ()
    {
        Instantiate(qqq, transform.position, transform.rotation);
    }
    void EEQ()      //��ܣ������ǰ�͹��ڽ�ɫ���ϣ�ֱ��Active����
    {
        eeq.SetActive(true);
    }
}
