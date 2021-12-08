using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public interface Goldbuilder
    {
        public Goldbuilder Setposition(Vector3 position);
        public Goldbuilder Setamount(float amount);
        public Goldbuilder Setdensity(float density);
        public Goldbuilder Setscale(float scale);
        public Goldbuilder Setpurity(float purity);
        public Gold Build();
    }
}