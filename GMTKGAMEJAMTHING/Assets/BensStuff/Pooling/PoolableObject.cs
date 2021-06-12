using UnityEngine;
using System.Collections;

namespace ObjectPooling
{
    public class PoolableObject : MonoBehaviour
    {
        //lifespan, if set to below 0 with never be deactivated
        [SerializeField]private float lifeSpan = 0.0f;
        //lifespan for destoyer
        private WaitForSeconds waitTime;
        //its prefab ID, set from manager
        private int poolID;
        //its techincally more security/ can be made more secure if I had time to find out
        public int PoolID
        {
            get{return poolID;}
            set{poolID = value;}
        }
        //sets wait for seconds, I think its suppose to be faster
        private void Awake()
        {
            waitTime = new WaitForSeconds(lifeSpan);
        }
        //start disabler if lifespawn is greater than zero
        private void OnEnable()
        {
            if(lifeSpan>=0f)
            {
                StartCoroutine(Disabler());
            }
        }
        //restacks the object and stops courtines
        private void OnDisable()
        {
            PoolManager.Restack(this,PoolID);
            StopAllCoroutines();
        }
        //disables the object on its waitTime
        private IEnumerator Disabler()
        {
            yield return waitTime;
            gameObject.SetActive(false);
        }
    }
}