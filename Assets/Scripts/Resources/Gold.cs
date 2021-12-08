using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Gold : MonoBehaviour
    {
        [SerializeField] private float amount;
        [SerializeField] private float density;
        [SerializeField] private Vector3 position;
        [SerializeField] private float purity;
        [SerializeField] private float scale;

        public Gold Create(float amount = 0, float density = 0, Vector3 position = new Vector3(), float purity = 0, float scale = 0)
        {
            if (amount != 0)
                this.amount = amount;
            if (density != 0)
                this.density = density;
            if (position != new Vector3())
                this.position = position;
            if (purity != 0)
                this.purity = purity;
            if (scale != 0)
                this.scale = scale;
            return this;
        }
    }
}