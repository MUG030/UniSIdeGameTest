using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    /// <summary> �폜���鎞�Ԏw�� </summary>
    public float deltaTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        /// <summary> �폜�ݒ� </summary>
        Destroy(gameObject, deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�@�����ɐڐG���������
        Destroy(gameObject);
    }
}
