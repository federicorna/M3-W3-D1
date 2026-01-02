
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    private float h, v;
    private Vector2 _dir; 

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        _dir = new Vector2(h, v).normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _dir * (_speed * Time.fixedDeltaTime));
        
    }

}
