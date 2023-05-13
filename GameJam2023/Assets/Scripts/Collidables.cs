using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collidables : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void ToggleCollidable()
    {
        _collider.enabled = !_collider.enabled;
        Color tmp = _spriteRenderer.color;
        if (_collider.enabled)
        {
            tmp.a = 1f;
        }
        else
        {
            tmp.a = 0.5f;
        }
        _spriteRenderer.color = tmp;
    }
}
