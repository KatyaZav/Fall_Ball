using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLogic : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator _anim;

    [SerializeField] GameObject effect;
    [SerializeField] Image _img;

    Camera _cam;

    private void Start()
    {
        Debug.Log("�������� ����� � ��������");

        _cam = Camera.main;

        if (rb == null)       
            rb = GetComponent<Rigidbody2D>();
        if (_anim == null)
            _anim = GetComponent<Animator>();
    }
    
    private void OnMouseDown()
    {
        OnTouched();
    }

    /// <summary>
    /// Action happend on mouse click on ball
    /// </summary>
    void OnTouched()
    {
        Debug.Log("Tap");

        if (effect != null)
            Instantiate(effect);
        _anim.SetTrigger("touched");
        Upped();
    }

    /// <summary>
    /// Ball fly up
    /// </summary>
    void Upped()
    {
        var mousePosWorld = _cam.ScreenToWorldPoint(Input.mousePosition);
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(
            (transform.position.x - mousePosWorld.x) * 2, 1-Mathf.Abs(transform.position.x - mousePosWorld.x)) * 300);
    }
}