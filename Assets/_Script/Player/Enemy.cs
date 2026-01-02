
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private PlayerController _player;

    void Awake()
    {
        _player = FindAnyObjectByType<PlayerController>();  //quando enemy nasce trova player
    }

    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        if (_player == null) return;

        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Destroy(collision.gameObject);
        }

    }
}
 