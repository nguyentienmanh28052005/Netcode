using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BulletController : NetworkBehaviour
{
    private GameObject _player;
    private float _speed = 20f;
    private Vector2 _diretion;
    private Vector2 mousePosi;
    
    private void Start()
    {
        mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _diretion = mousePosi - (Vector2)transform.position;
        _diretion.Normalize();
    }
    
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime  * _speed);
        Debug.Log(transform.position); 
        //StartCoroutine(WaitForDestroy());
    }
    
    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(2f);
        DestroyBulletServerRpc();
    }

    [ServerRpc]
    private void DestroyBulletServerRpc()
    {
        Destroy(this.gameObject);
    }    
    // [SerializeField] private float _speed = 20f;
    //
    //
    // public void Start()
    // {
    //     GetComponent<Rigidbody2D>().velocity = transform.forward * _speed;
    // }

    

   
}