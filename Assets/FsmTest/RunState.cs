
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RunState : IState
{
    private FSM manager;
    private Parameter parameter;
    public RunState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        manager.parameter.animator.Play("HeroKnight_Run");
    }

    public void OnUpdate()
    {
        if (manager.target == null)
        {
            manager.TransitionState(StateType.Idle);
            manager.Rb.velocity = new Vector2(0, manager.Rb.velocity.y);
        }
        else if (manager.target != null)        //�������Ȧ����
        {
            manager.FlipDirection();
            manager.Rb.velocity = new Vector2(manager.Dir * 250 * Time.deltaTime, manager.Rb.velocity.y);      //�����ƶ�(�ƶ����������ƶ���ʽ��ͬ������Ǹ���X���ٶȵ�����������Ҫ���ݷ������X�ٶȷ���)
            if (manager.Attacktarget != null)       //����Ȧ����ͬʱ������������
            {
                manager.TransitionState(StateType.Attack);
                manager.Rb.velocity = new Vector2(0, manager.Rb.velocity.y);
            }
        }
    }

    public void OnExit()
    {
    }
}