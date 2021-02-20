using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WalkState : IState
{
    private FSM manager;
    private Parameter parameter;

    private float timer;
    public WalkState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        timer = manager.parameter.timer;
        //parameter.animator.Play("Idle");
        manager.parameter.animator.Play("Walk");
    }

    public void OnUpdate()
    {
        timer -= Time.deltaTime;
        manager.FlipDirection();
        Debug.Log("run");
        if (timer < 1)
        {
            manager.TransitionState(StateType.Idle);
        }
        if (manager.target != null)
        {
            manager.Rb.velocity= new Vector2(manager.Dir * 250 * Time.deltaTime, manager.Rb.velocity.y);      //�����ƶ�(�ƶ����������ƶ���ʽ��ͬ������Ǹ���X���ٶȵ�����������Ҫ���ݷ������X�ٶȷ���)
        }
    }

    public void OnExit()
    {
        Debug.Log("changetoidle");
        manager.parameter.timer = timer;
    }
}