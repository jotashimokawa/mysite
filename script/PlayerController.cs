using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public float speed;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        SetCountText();
        speed = 10;
        count = 0;
        rb = this.GetComponent<Rigidbody>();

    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            if (count >= 9)
            {
                winTextObject.SetActive(true);
            }
        }
    }


}
