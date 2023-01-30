using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    /// <summary> true=���Ԃ��J�E���g�_�E���v�Z���� </summary>
    public bool _isCountDown = true;
    /// <summary> �Q�[���̍ő厞�� </summary>
    public float _gameTime = 0;
    /// <summary> true = �^�C�}�[��~ </summary>
    public bool _isTimeOver = false;
    /// <summary> �\���ؑ� </summary>
    public float _displayTime = 0;
    /// <summary> ���ݎ��� </summary>
    float _times = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (_isCountDown)
        {
            // �J�E���g�_�E��
            _displayTime = _gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTimeOver == false)
        {
            _times += Time.deltaTime;
            if (_isCountDown)
            {
                // �J�E���g�_�E��
                _displayTime = _gameTime - _times;
                if(_displayTime <= 0.0f)
                {
                    _displayTime = 0.0f;
                    _isTimeOver = true;
                }
            }
            else
            {
                // �J�E���g�A�b�v
                _displayTime = _times;
                if(_displayTime >= 0.0f)
                {
                    _displayTime = _gameTime;
                    _isTimeOver = true;
                }
            }
            Debug.Log("TIMES:" + _displayTime);
        }
    }
}
