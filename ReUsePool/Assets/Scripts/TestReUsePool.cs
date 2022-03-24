using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReUsePool;

public class TestReUsePool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestClass();

        Debug.LogError("");
        Debug.LogError("");
        Debug.LogError("");
        Debug.LogError("");
        Debug.LogError("");

        TestGameObject();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }

    private void TestClass()
    {
        PoolClassController test = new PoolClassController();

        Npc npc1 = new Npc(100);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc1);

        Npc npc = PoolManager.GetInstance().SpawnClass<Npc>() as Npc;
        Debug.Log(npc._id);

        Npc npc2 = new Npc(200);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc2);

        npc = PoolManager.GetInstance().SpawnClass<Npc>() as Npc;
        Debug.Log(npc._id);

        npc = PoolManager.GetInstance().SpawnClass<Npc>() as Npc;
        if (null == npc)
        {
            Debug.LogError("222 npc null");
        }

        Player player = new Player(100000);
        PoolManager.GetInstance().UnSpawnClass<Player>(player);

        Player player2 = PoolManager.GetInstance().SpawnClass<Player>();
        Debug.LogError(player2._id);
    }

    private void TestGameObject()
    {
        GameObject cube = Load("Cube");
        PoolManager.GetInstance().UnSpawnObject(cube.name, cube);
        Debug.LogError(cube.name + "    " + cube.GetHashCode());


        GameObject cube2 = Load("Cube");
        PoolManager.GetInstance().UnSpawnObject(cube2.name, cube2);
       

        GameObject cubeGo = PoolManager.GetInstance().SpawnObject("Cube");
        Debug.LogError(cubeGo.name + "    " + cubeGo.GetHashCode());

        GameObject sphere = Load("Sphere");
        Debug.LogError(sphere.name + "    " + sphere.GetHashCode());
        PoolManager.GetInstance().UnSpawnObject(sphere.name, sphere);

        GameObject sphereGo = PoolManager.GetInstance().SpawnObject("Sphere");
        Debug.LogError(sphereGo.name + "    " + sphereGo.GetHashCode());

        cubeGo = PoolManager.GetInstance().SpawnObject("Cube");
        Debug.LogError(cubeGo.name + "    " + cubeGo.GetHashCode());

        cubeGo = PoolManager.GetInstance().SpawnObject("Cube");
        Debug.LogError(cubeGo.name + "    " + cubeGo.GetHashCode());
    }

    private GameObject Load(string resName)
    {
        GameObject go = Resources.Load<GameObject>(resName);
        go = GameObject.Instantiate(go);
        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.transform.rotation = Quaternion.identity;
        go.name = resName;
        return go;
    }

}
