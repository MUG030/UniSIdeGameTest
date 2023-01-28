using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /// <summary> Rigidbody2D�^�̕ϐ� </summary>
    Rigidbody2D rbody;
    /// <summary> ���͗p�ϐ� </summary>
    private float _axisH = 0.0f;
    /// <summary> �ړ��ϐ� </summary>
    public float _speed = 3.0f;
    /// <summary> �W�����v�ϐ� </summary>
    public float _jump = 9.0f;
    /// <summary> ���n�ł��郌�C���[ </summary>
    public LayerMask groundLayer;
    /// <summary> �W�����v�J�n�t���O </summary>
    bool _gojump = false;
    /// <summary> �n�ʂɗ����Ă���t���O </summary>
    bool _onGround = false;

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
        // Player���W�����v������
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    /// <summary>
    /// ���x�X�V
    /// </summary>
    private void FixedUpdate()
    {
        // �n�㔻��
        _onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        // �n�ʂ̏�������͑��x��0�ł͂Ȃ�
        if (_onGround || _axisH != 0)
        {
            // ���x���X�V����
            rbody.velocity = new Vector2(_axisH * _speed, rbody.velocity.y);
        }
        // �n�ʂ̏�ŃW�����v�L�[�������ꂽ
        if (_onGround && _gojump)
        {
            // �W�����v�\
            Debug.Log("�W�����v");
            Vector2 jumpPw = new Vector2(0, _jump);         //�����Ղ����邽�߂̃��\�b�h
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //�u�ԓI�ȗ͂�������
            _gojump = false;
        }
    }

    /// <summary>
    /// �W�����v���邽�߂̃��\�b�h
    /// </summary>
    public void Jump()
    {
        _gojump = true;         //�W�����v�t���O�����Ă�
        Debug.Log("�W�����v�{�^����������");
    }

}
