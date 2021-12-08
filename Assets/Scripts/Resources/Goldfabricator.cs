using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Goldfabricator : Goldbuilder
    {
        private float amount;
        private float density;
        private Vector3 position;
        private float purity;
        private float scale;

        public Gold Build()
        {
            return Resourcemanager.Instance
                .Spawnresource(Resourcemanager.Spawntypes.Gold)
                .GetComponent<Gold>()
                .Create(amount, density, position, purity, scale);
        }

        public Goldbuilder Setamount(float amount)
        {
            this.amount = amount;
            return this;
        }

        public Goldbuilder Setdensity(float density)
        {
            this.density = density;
            return this;
        }

        public Goldbuilder Setposition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public Goldbuilder Setpurity(float purity)
        {
            this.purity = purity;
            return this;
        }

        public Goldbuilder Setscale(float scale)
        {
            this.scale = scale;
            return this;
        }
    }
}