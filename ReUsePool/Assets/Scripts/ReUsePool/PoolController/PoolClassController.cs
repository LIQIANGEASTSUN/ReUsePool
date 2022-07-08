

namespace ReUsePool
{
    /// <summary>
    /// 类复用池管理：类复用需要继承 IReUse 接口
    /// 一个类创建一个池子， typeof(类).Name 作为池子的名字
    /// </summary>
    public class PoolClassController : PoolControllerBase<IReUse>
    {

        public override IReUse Spawn(string poolName)
        {
            return base.Spawn(poolName);
        }

        protected override IPool<IReUse> CreatePool(string poolName)
        {
            IPool<IReUse> pool = new PoolClass<IReUse>(poolName);
            _poolDic.Add(poolName, pool);
            return pool;
        }
    }

}