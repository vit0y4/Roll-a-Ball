using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        pickUps();
    }

    public void pickUps()
	{
        objectPooler = ObjectPooler.Instance;
        for (int i = 0; i < 12; i++)
        {
            float posX = Random.Range(-8, 8);
            float posZ = Random.Range(-8, 8);
            ObjectPooler.Instance.SpawnFromPool("PickUp", new Vector3(posX, transform.position.y, posZ), Quaternion.identity);

        }
    }

    

   
}
