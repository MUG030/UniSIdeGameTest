using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    /// <summary> ����������Prefab�f�[�^ </summary>
    public GameObject objPrefab;
    /// <summary> �x������ </summary>
    public float delayTime = 3.0f;
    /// <summary> ���˃x�N�g��X </summary>
    public float fireSpeedX = -4.0f;
    /// <summary> ���˃x�N�g��Y </summary>
    public float fireSpeedY = 0.0f;
    public float length = 8.0f;

    GameObject player;
    GameObject gateObj;
    float _passedTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ���˃I�u�W�F�N�g���擾
        Transform tr = transform.Find("gate");
        gateObj = tr.gameObject;
        // �v���C���[
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԏ��Ԕ���
        _passedTimes += Time.deltaTime;
        if (CheckLength(player.transform.position))
        {
            if (_passedTimes > delayTime)
            {
                // ����
                _passedTimes = 0;
                // ���ˈʒu
                Vector3 pos = new Vector3(gateObj.transform.position.x, gateObj.transform.position.y, transform.position.z);
                // Prefab ���� GameObject�����
                GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
                // ���˕���
                Rigidbody2D rbody = obj.GetComponent<Rigidbody2D>();
                Vector2 v = new Vector2 (fireSpeedX, fireSpeedY);
                rbody.AddForce (v, ForceMode2D.Impulse);
            }
        }
    }

    private bool CheckLength(Vector2 targetPos)
    {
        bool ret = false;
        float d = Vector2.Distance(transform.position, targetPos);
        if (length >= 0)
        {
            ret = true;
        }
        return ret;
    }
}
