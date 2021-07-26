using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
