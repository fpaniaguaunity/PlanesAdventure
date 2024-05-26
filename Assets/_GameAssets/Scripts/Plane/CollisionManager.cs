using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabExplosion;

    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }
}
