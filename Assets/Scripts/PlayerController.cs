
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;
    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _rb;
    public Vector2 MovementSpeed = new Vector2(100.0f, 100.0f);
    [SerializeField] private GameObject _bulletPrefab;
    private float _health = 100f;
    private float _enegy = 20f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (!IsOwner) return;
        Move();
        if (Input.GetMouseButtonDown(1))
        { 
            FireServerRpc();
        }
    }
    
    
    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        Vector2 _vectorInput = new Vector2(_horizontal, _vertical);
        _rb.velocity = new Vector2(_horizontal, _vertical);
        _rb.velocity.Normalize();
        _rb.MovePosition(_rb.position + (_vectorInput  *  MovementSpeed * Time.fixedDeltaTime));
    }

    // [ClientRpc]
    // private void FireClientRpc()
    // {
    //     GameObject bullet =  Instantiate(this._bulletPrefab, transform.position, transform.rotation);
    //     bullet.GetComponent<NetworkObject>().Spawn(true);
    //     
    // }

    private void Fire()
    {
        
    }
    
    public void TakeDamage()
    {
        _health -= 5;
        _enegy += 1;
    }
    
    [ServerRpc]
    private void FireServerRpc()
    {
        GameObject bullet =  Instantiate(_bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<NetworkObject>().Spawn();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            TakeDamage();
        }
    }
    

}
