using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FG
{
    public class Factorymanager
    {
        private static Factorymanager instance;
        private List<Factory> factories;
        public static Factorymanager Instance
        {
            get
            {
                if (instance == null)
                    instance = new Factorymanager();
                return instance;
            }
        }

        private Factorymanager()
        {
            factories = new List<Factory>();
        }

        public void Register(Factory fact)
        {
            factories.Add(fact);
        }

        public void Deregister(Factory fact)
        {
            factories.Remove(fact);
        }

        public void Create(Transform gofab)
        {
            if(factories.Count > 0)
            {
                int shortestqueue = factories.Min(each => each.Queuelength);
                factories.First(each => each.Queuelength == shortestqueue).Train(gofab);
            }
        }
    }
}