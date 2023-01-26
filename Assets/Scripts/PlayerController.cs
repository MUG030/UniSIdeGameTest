using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary> Rigidbody2D�^�̕ϐ� </summary>
    public Rigidbody2D rbody;
    /// <summary> ���͗p�ϐ� </summary>
    private float _axisH = 0.0f;
    /// <summary> �ړ��ϐ� </summary>
    public float _speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D���Ƃ�
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�@���������̓��͂��m�F����
        _axisH = Input.GetAxisRaw("Horizontal");
        //�@�����̒���
        if (_axisH > 0.0f )
        {
            // �E�����̌���
            Debug.Log("�E�Ɉړ�");
            transform.localScale = new Vector2(1, 1);
        }
        else if (_axisH < 0.0f )
        {
            // ���Ɉړ�
            Debug.Log("���Ɉړ�");
            // ���E�ɔ��]������
            transform.localScale = new Vector2(-1, 1);
        }
    }

    /// <summary>
    /// ���x�X�V
    /// </summary>
    private void FixedUpdate()
    {
        /// ���x���X�V����
        rbody.velocity = new Vector2(_axisH * _speed, rbody.velocity.y);
    }

}
