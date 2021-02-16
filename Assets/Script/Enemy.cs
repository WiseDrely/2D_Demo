using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator Anim;
    Rigidbody2D Rb;
    public LayerMask LM;
    public Transform Player;
    public float CircleRadius=5;
    public GameObject Freeze;
    int Dir = -1;
    float velocityX;

    public GameObject Attention;
    bool attention=true;
    public GameObject Doubt;
    bool doubt=false;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


    //����Ҫע�⣬���ڸ�������ͼ������������ģ�unity��X�����������ҵģ���ת��ʱҪ�����ת���ж�������
    void Update()
    {
        if (Freeze.activeInHierarchy == false)
        {
            Anim.speed = 1f;
            PlayerCheck();
            FlipDirection();
        }
        else 
        {
            Anim.speed = 0f;
        }
        velocityX = Rb.velocity.x;
        Anim.SetFloat("velocityX", velocityX);
    }
    void FlipDirection()
    {
        if (Dir == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Dir == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Player.position.x - 0.1 > transform.position.x)
        {
            Dir = 1;
        }
        else if (Player.position.x + 0.08 < transform.position.x)
        {
            Dir = -1;
        }
    }
    void PlayerCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, CircleRadius,LM);
        if (collider != null)
        {
            Rb.velocity = new Vector2(Dir * 250 * Time.deltaTime, Rb.velocity.y);      //�����ƶ�(�ƶ����������ƶ���ʽ��ͬ������Ǹ���X���ٶȵ�����������Ҫ���ݷ������X�ٶȷ���)
            StartCoroutine(InAttention());
        }
        else
        {
            StartCoroutine(InDoubt());
            Rb.velocity = new Vector2(0, Rb.velocity.y);
        }
    }
    private void OnDrawGizmos() //���ӻ������ⳤ����

    {
        Gizmos.DrawWireSphere(transform.position, CircleRadius);
        Gizmos.color = Color.red;
    }
    IEnumerator InAttention()
    {
        if (Attention.activeInHierarchy == true)
        {
            yield return null;
        }
        else
        {
            if (attention == true)
            {
                Doubt.SetActive(false);
                attention = false;
                doubt = true;
                Attention.SetActive(true);
                yield return new WaitForSeconds(3);
                Attention.SetActive(false);
            }
        }
        
    }
    IEnumerator InDoubt()
    {
        if (Doubt.activeInHierarchy == true)
        {
            yield return null;
        }
        else
        {
            if (doubt == true)
            {
                Attention.SetActive(false);
                doubt = false;
                Doubt.SetActive(true);
                yield return new WaitForSeconds(3);
                Doubt.SetActive(false);
                attention = true;
            }
        }

    }
}
