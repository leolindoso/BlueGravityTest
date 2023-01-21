using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private Vector2 m_movement;
    [SerializeField]
    private SpriteRenderer m_renderer;

    private Rigidbody2D m_rigidBody;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GameState != GameState.ON_POP_UP)
        {
            m_movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            m_rigidBody.velocity = m_movement * m_speed;
            m_animator.SetFloat("Velocity", m_movement.magnitude);

            m_renderer.flipX = m_movement.x < 0;
        }
    }
}
