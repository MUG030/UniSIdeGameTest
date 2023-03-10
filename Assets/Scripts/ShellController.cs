using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    /// <summary> 削除する時間指定 </summary>
    public float deltaTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        /// <summary> 削除設定 </summary>
        Destroy(gameObject, deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //　何かに接触したら消す
        Destroy(gameObject);
    }
}
