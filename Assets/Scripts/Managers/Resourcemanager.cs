using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Resourcemanager : MonoBehaviour
    {
        [SerializeField] private Transform[] fabs;

        public enum Spawntypes
        {
            Gold
        }

        private static Resourcemanager instance;

        public static Resourcemanager Instance
        {
            get
            {
                if (instance == null)
                {
                    var go = new GameObject().AddComponent<Resourcemanager>();
                    instance = go.GetComponent<Resourcemanager>();
                }
                return instance;
            }
        }

        public Transform Spawnresource(Spawntypes type)
        {
            return Instantiate(fabs[(int)type]);
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}