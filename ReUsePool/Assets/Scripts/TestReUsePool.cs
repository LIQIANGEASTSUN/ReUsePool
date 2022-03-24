using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReUsePool;

public class TestReUsePool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PoolClassController test = new PoolClassController();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }
}
