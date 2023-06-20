using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    
    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = +1;
        }
        //normalized : agar resultan gaya nggak lebih dari 1 saat bergerak diagonal

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        //agar muka player bisa rotate sesuai posisinya
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
