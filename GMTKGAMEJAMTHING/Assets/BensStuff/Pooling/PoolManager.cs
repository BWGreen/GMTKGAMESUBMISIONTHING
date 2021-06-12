using UnityEngine;
using System.Collections.Generic;

namespace ObjectPooling
{
    public static class PoolManager
    {
        //default stack size
        private static readonly int DEFAULT_POOL_SIZE = 1;
        //dictionary that stores pool object by instance ID
        private static Dictionary<int,Stack<PoolableObject>> pools = new Dictionary<int, Stack<PoolableObject>>();

        //creates pool from prefab, size, and if specifed with a parent in hierarchy
        public static void CreatePool(PoolableObject _prefab,int _poolsize,Transform _parent = null,bool _setActive = false)
        {
            var _poolId = _prefab.GetInstanceID();
            pools[_poolId] = new Stack<PoolableObject>(_poolsize);
            for(int i = 0;i<_poolsize;i++)
            {
                CreateObjectForPool(_prefab,_poolId,_parent,_setActive);
            }
        }
        
        //creates and object for the pool, with added parenting 
        private static PoolableObject CreateObjectForPool(PoolableObject _prefab, int _poolID,Transform _parent = null,bool _setActive = true)
        {
            var _clone = GameObject.Instantiate(_prefab);
            _clone.GetComponent<PoolableObject>().PoolID = _poolID;
            _clone.transform.parent = _parent;
            _clone.gameObject.SetActive(_setActive);
            return _clone;
        }

        //gets next object, setting transform and parent
        public static PoolableObject GetNext(PoolableObject _prefab,Transform _target,Transform _parent = null,bool _setActive = true)
        {
            PoolableObject _clone = GetNext(_prefab,_setActive);
            if(_target!=null)
            {
                _clone.transform.position = _target.transform.position;
                _clone.transform.rotation = _target.transform.rotation;
            }
            if(_parent!=null)
            {
                _clone.transform.parent = _parent;
            }
            return _clone;
        }
        //gets next object in pool with the ability to set active within it
        public static PoolableObject GetNext(PoolableObject _prefab,bool _setActive = true)
        {
            int _poolID = _prefab.GetInstanceID();
            if(pools.ContainsKey(_poolID)==false)
            {
                CreatePool(_prefab,DEFAULT_POOL_SIZE);
            }
            Stack<PoolableObject> currentPool = pools[_poolID];
            if(currentPool.Count>0)
            {
                PoolableObject _clone = currentPool.Pop();
                if(_clone != null)
                {
                    _clone.gameObject.SetActive(_setActive);
                    return _clone;
                }
            }
            return CreateObjectForPool(_prefab,_poolID);
        }
        //restacks the object, callled from object
        public static void Restack(PoolableObject _prefab,int _poolID)
        {
            pools[_prefab.PoolID].Push(_prefab);
        }
    }
}