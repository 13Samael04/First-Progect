using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _countEnemys;

    private int _lastEnemy = 0;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _countEnemys--;
            enemy.TakeDamage(_damage);

            if(_countEnemys == _lastEnemy)
            {
                Destroy(gameObject);
            }
        }
    }
}