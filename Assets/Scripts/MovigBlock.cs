using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovigBlock : MonoBehaviour
{
    /// <summary> X �ړ����� </summary>
    public float _moveX = 0.0f;
    /// <summary> Y �ړ����� </summary>
    public float _moveY = 0.0f;
    /// <summary> ���� </summary>
    public float _times = 0.0f;
    /// <summary> ��~���� </summary>
    public float _weight = 0.0f;
    /// <summary> ������Ƃ��ɓ����t���O </summary>
    public bool _isMoveWhenOn = false;

    /// <summary> �����t���O </summary>
    public bool _isCanMove = true;
    /// <summary> 1�t���[����X�ړ��l </summary>
    float perDX;
    /// <summary> 1�t���[����Y�ړ��l </summary>
    float perDY;
    /// <summary> �����ʒu </summary>
    Vector3 defPos;
    /// <summary> ���]�t���O </summary>
    bool _isReverse = false;

    // Start is called before the first frame update
    void Start()
    {
        // �����ʒu
        defPos = transform.position;
        // �P�t���[���̈ړ����Ԏ擾
        float timestep = Time.fixedDeltaTime;
        // �P�t���[����X�ړ��l
        perDX = _moveX / (1.0f / timestep * _times);
        // �P�t���[����Y�ړ��l
        perDY = _moveY / (1.0f / timestep * _times);

        if (_isMoveWhenOn)
        {
            // ��������ɓ������ߏ��߂͓������Ȃ�
            _isCanMove = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_isCanMove)
        {
            // �ړ���
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;
            if (_isReverse)
            {
                // �t�����Ɉړ���
                // �ړ��ʂ��v���X�ňړ��ʒu��������菬�����܂��́A�ʂ��}�C�i�X�ňʒu���������傫��
                if ((perDX >= 0.0f && x <= defPos.x) || (perDX <= 0.0f && x >= defPos.x))
                {
                    // �ړ��ʂ��{��
                    endX = true;        // X�����̈ړ����I��
                }
                if ((perDY >= 0.0f && y <= defPos.y) || (perDY <= 0.0f && y >= defPos.y))
                {
                    endY = true;        // Y�����̈ړ��I��
                }
                // �����ړ�������
                transform.Translate(new Vector3(-perDX, -perDY, defPos.z));
            }
            else
            {
                // �������ړ����E�E�E
                // �ړ��ʂ��v���X�ňʒu�������{�ړ��������傫���܂��́A�ʂ��}�C�i�X�ňʒu�������{�ړ�������菬����
                if ((perDX >= 0.0f && x >= defPos.x + _moveX) || (perDX < 0.0f && x <= defPos.x + _moveX))
                {
                    endX = true;       // X�����̈ړ��I��
                }
                if ((perDY >= 0.0f && y >= defPos.y + _moveY) || (perDY < 0.0f && y <= defPos.y + _moveY))
                {
                    endY = true;       // Y�����̈ړ��I��
                }
                // �����ړ�������
                Vector3 v = new Vector3(perDX, perDY, defPos.z);
                transform.Translate(v);
            }
            if (endX && endY)
            {
                // �ړ��I��
                if (_isReverse)
                {
                    // �������ړ��ɖ߂�O�ɏ����ʒu�ɖ߂�
                    transform.position = defPos;
                }
                // �t���O�𔽓]������
                _isReverse = !_isReverse;
                // �ړ��t���O������
                _isCanMove = false;
                if (_isMoveWhenOn == false)
                {
                    // ������Ƃ��ɓ����t���OOFF
                    Invoke("Move", _weight);        // �ړ��t���O�����Ă�x�����s
                }
            }
        }
    }

    /// <summary>
    /// �ړ��t���O�����Ă�
    /// </summary>
    public void Move()
    {
        _isCanMove = true;
    }

    /// <summary>
    /// �ړ��t���O�����낷
    /// </summary>
    public void Stop()
    {
        _isCanMove = false;
    }

    /// <summary>
    /// �ڐG�J�n
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // �ڐG�����̂��v���C���[�Ȃ�ړ����̎q�ɐݒ肷��
            collision.transform.SetParent(transform);
            if (_isMoveWhenOn)
            {
                // ������Ƃ��ɓ����t���OON
                _isCanMove = true;      // �ړ��t���O�����Ă�
            }
        }
    }

    /// <summary>
    /// �ڐG�I��
    /// </summary>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // �ڐG�����̂��v���C���[�Ȃ�ړ����̎q����O��
            collision.transform.SetParent(null);
        }
    }
}
