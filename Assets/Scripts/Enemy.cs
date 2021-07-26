using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    public float downForce = 1f;
    
	public void OnObjectSpawn()
	{
        Vector3 force = new Vector3(0, 0, -50);
        GetComponent<Rigidbody>().velocity = force;
        transform.Rotate(new Vector3(90, 0, 0));
    }
}
