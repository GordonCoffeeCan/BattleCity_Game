using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform playerTrans;

    public float speed = 5f;
    public Sprite[] tankGraphics;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        float _horizontalInput = Input.GetAxisRaw("Horizontal");

        playerTrans.Translate(playerTrans.right * _horizontalInput * Time.fixedDeltaTime * speed);

        if(_horizontalInput > 0) {
            spriteRenderer.sprite = tankGraphics[1];
        }else if (_horizontalInput < 0) {
            spriteRenderer.sprite = tankGraphics[3];
        }

        if(_horizontalInput != 0) {
            return;
        }

        float _verticalInput = Input.GetAxisRaw("Vertical");
        if (_verticalInput > 0) {
            spriteRenderer.sprite = tankGraphics[0];
        } else if (_verticalInput < 0) {
            spriteRenderer.sprite = tankGraphics[2];
         }
        playerTrans.Translate(playerTrans.up * _verticalInput * Time.deltaTime * speed);
    }
}

