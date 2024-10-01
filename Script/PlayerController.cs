using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 0.8f;

        //入力を取得する
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移動ベクトルを計算
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * moveSpeed * Time.deltaTime;

        // プレイヤーを移動
        transform.Translate(movement);
    }

    public float customGravity = -5.0f; // カスタム重力の強さ

    private Rigidbody rb;

    void FixedUpdate()
    {
        // 重力をカスタマイズして適用する
        rb.AddForce(new Vector3(0, customGravity, 0), ForceMode.Acceleration);
    }
}
