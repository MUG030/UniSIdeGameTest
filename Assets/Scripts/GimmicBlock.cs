using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmicBlock : MonoBehaviour
{
    /// <summary> �����������m���� </summary>
    public float _length= 0;
    /// <summary> ������ɍ폜����O���t </summary>
    public bool _isDelete = false;

    /// <summary> �����O���t </summary>
    bool _isFell = false;
    /// <summary> �t�F�[�h�A�E�g���� </summary>
    float _fadeTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D�̕����������~
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            // �v���C���[�Ƃ̋����v�Z
            float d = Vector2.Distance(transform.position, player.transform.position);
            if (_length >= d)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb.bodyType == RigidbodyType2D.Static)
                {
                    // RigidBody2D�̋������J�n
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
        if (_isFell)
        {
            // ��������
            // �����l��ύX���ăt�F�[�h�A�E�g������
            // �O�t���[���̍����b�}�C�i�X
            _fadeTime -= Time.deltaTime;
            // �J���[�����o��
            Color col = GetComponent<SpriteRenderer>().color;
            // �����l�̕ύX
            col.a = _fadeTime;
            // �J���[�̍Đݒ�
            GetComponent<SpriteRenderer>().color = col;
            if (_fadeTime <= 0.0f)
            {
                // 0�ȉ�(����)�ɂȂ��������
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// �ڐG�J�n
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDelete)
        {
           �@// �����t���O�I��
            _isFell = true;
        }
    }
}
