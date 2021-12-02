using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] protected float traintime;
        public float Traintime
        {
            get
            {
                return traintime;
            }
        }
    }
}