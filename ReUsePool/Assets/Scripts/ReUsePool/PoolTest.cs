using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReUsePool;


public class Npc : IReUse
{
    public int _id;
    public Npc(int id)
    {
        _id = id;
    }

    public void ReUseOverflowRelease()
    {
        Debug.LogError("Npc ReUseOverflowRelease:" + _id);
    }

    public void Spawn()
    {
        Debug.LogError("Npc Spawn:" + _id);
    }

    public void UnSpawn()
    {
        Debug.LogError("Npc UnSpawn:" + _id);
    }
}


public class Player : IReUse
{
    public int _id;
    public Player(int id)
    {
        _id = id;
    }

    public void ReUseOverflowRelease()
    {
        Debug.LogError("Player ReUseOverflowRelease:" + _id);
    }

    public void Spawn()
    {
        Debug.LogError("Player Spawn:" + _id);
    }

    public void UnSpawn()
    {
        Debug.LogError("Player UnSpawn:" + _id);
    }
}


public class PoolTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestClass();

        TestGameObject();
    }

    // 测试类复用池
    private void TestClass()
    {
        // 一个对象实例只允许放入复用池一次，复用池中不会存多个相同的对象,使用对象的 GetHashCode 作为唯一标示
        // 每个继承 IReUse 的类名作为一个复用池名字

        #region Npc
        // 设置 Npc 类对象复用池大小
        PoolManager.GetInstance().SetSpawnClassCapacity<Npc>(15);

        // 从复用池取出一个对象
        Npc npc = PoolManager.GetInstance().SpawnClass<Npc>(typeof(Npc).Name) as Npc;
        // 如果复用池为空则自己创建一个对象，因为对象创建过程复杂
        // 所以不在复用池中实例化对象
        if (null == npc)
        {
            npc = new Npc(100);
        }
        // 用完后 将 Npc 对象放入复用池
        PoolManager.GetInstance().UnSpawnClass<Npc>(npc);

        // 从复用池中取一个对象
        Npc npc2 = PoolManager.GetInstance().SpawnClass<Npc>(typeof(Npc).Name) as Npc;
        Debug.Log("npc2:" + npc2._id);
        #endregion

        #region Player
        // 设置 Player 类对象复用池大小
        PoolManager.GetInstance().SetSpawnClassCapacity<Player>(25);

        // 创建一个 Player 对象
        Player player = new Player(100000);
        // 将 Player 对象放入复用池
        PoolManager.GetInstance().UnSpawnClass<Player>(player);

        // 从Player 复用池中取出一个对象
        Player player2 = PoolManager.GetInstance().SpawnClass<Player>(typeof(Player).Name);
        Debug.LogError(player2._id);
        #endregion

    }

    // 测试 GameObject 复用池
    private void TestGameObject()
    {
        // 每一个 GameObject 的名字作为一个复用池的名字
        // 名字相同的 GameObject 放入同一个复用池

        // 实例化一个 GameObject 对象
        GameObject cube = Load("Cube");
        // 对象使用完后，将对象放入复用池
        PoolManager.GetInstance().UnSpawnObject(cube.name, cube);
        Debug.LogError(cube.name + "    " + cube.GetHashCode());

        // 再创建一个对象放入复用池
        GameObject cube2 = Load("Cube");
        PoolManager.GetInstance().UnSpawnObject(cube2.name, cube2);

        // 从复用池取出一个 GameObject 对象，需要输入复用池名字
        GameObject cubeGo = PoolManager.GetInstance().SpawnObject("Cube");
        Debug.LogError(cubeGo.name + "    " + cubeGo.GetHashCode());

        GameObject sphere = Load("Sphere");
        Debug.LogError(sphere.name + "    " + sphere.GetHashCode());
        PoolManager.GetInstance().UnSpawnObject(sphere.name, sphere);

        GameObject sphereGo = PoolManager.GetInstance().SpawnObject("Sphere");
        Debug.LogError(sphereGo.name + "    " + sphereGo.GetHashCode());

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

