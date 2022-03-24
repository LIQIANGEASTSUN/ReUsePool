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

        Npc npc1 = new Npc(100);
        PoolManager.GetInstance().UnSpawn<Npc>(npc1);

        Npc npc = PoolManager.GetInstance().Spawn<Npc>() as Npc;
        Debug.Log(npc._id);

        Npc npc2 = new Npc(200);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);
        PoolManager.GetInstance().UnSpawn<Npc>(npc2);

        npc = PoolManager.GetInstance().Spawn<Npc>() as Npc;
        Debug.Log(npc._id);

        npc = PoolManager.GetInstance().Spawn<Npc>() as Npc;
        if (null == npc)
        {
            Debug.LogError("222 npc null");
        }

        Player player = new Player(100000);
        PoolManager.GetInstance().UnSpawn<Player>(player);

        Player player2 = PoolManager.GetInstance().Spawn<Player>();
        Debug.LogError(player2._id);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }
}
