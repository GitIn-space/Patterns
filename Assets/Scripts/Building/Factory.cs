using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Factory : Building
    {
        private Queue<GameObject> queue;
        private Coroutine spawnroutine;

        public int Queuelength
        {
            get
            {
                return queue.Count;
            }
        }

        public void Train(Transform gofab)
        {
            queue.Enqueue(gofab.gameObject);

            if(spawnroutine == null)
                spawnroutine = StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (queue.Count > 0)
            {
                yield return new WaitForSeconds(queue.Peek().GetComponent<Unit>().Traintime);
                Transform temp = gameObject.transform;
                Instantiate(queue.Peek(), temp.position + temp.forward * temp.localScale.x * 0.5f + temp.forward * queue.Peek().transform.localScale.x * 0.5f, Quaternion.identity);
                queue.Dequeue();
            }
            spawnroutine = null;
        }

        private void Awake()
        {
            queue = new Queue<GameObject>();
            Factorymanager.Instance.Register(this);
        }

        private void OnDestroy()
        {
            Factorymanager.Instance.Deregister(this);
        }
    }
}