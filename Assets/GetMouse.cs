using Unity.Netcode;
using UnityEngine;

public class GetMouse : NetworkBehaviour
{
    public static GetMouse instance;
    private Vector2 _mousePosi;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector2 GetMousePosi()
    {
        return _mousePosi;
    }
}
