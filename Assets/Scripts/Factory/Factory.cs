using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Factory : Building
    {
        private List<GameObject> queue;
        public int Queuelength
        {
            get
            {
                return queue.Count;
            }
        }

        public void Train(Transform gofab)
        {
            queue.Add(gofab.gameObject);
            StartCoroutine(Spawn(gofab.GetComponent<Unit>().Traintime, queue.Count - 1));
        }

        private IEnumerator Spawn(float delay, int i)
        {
            yield return new WaitForSeconds(delay);
            Transform temp = gameObject.transform;
            Instantiate(queue[i], temp.position + temp.forward * temp.localScale.x * 0.5f + temp.forward * queue[i].transform.localScale.x * 0.5f, Quaternion.identity);
        }

        private void Awake()
        {
            queue = new List<GameObject>();
            Factorymanager.Instance.Register(this);
        }

        private void OnDestroy()
        {
            Factorymanager.Instance.Deregister(this);
        }
    }
}