using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Attack")]
    public PlayerAttack playerAttack;

    [Header("Movement")]
    [SerializeReference] private float movementSpeed;

    private Rigidbody2D rB;

    private float inputX;
    private float inputY;
    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Debug.Log("Player Control");
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.G))
            playerAttack.Attack();
    }

    private void FixedUpdate()
    {
        rB.velocity = new Vector2(inputX, inputY) * movementSpeed * Time.deltaTime;
    }
}
