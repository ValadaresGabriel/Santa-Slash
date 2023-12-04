using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranscendenceStudio
{
    public interface IHittable
    {
        void Hit(int damage, GameObject sender);
    }
}
