using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Helpers
{
    public interface IScreenHelper
    {
        Vector3 AdjustPositionForScreen(Vector3 position, float screenTop, float screenRight, float screenBottom, float screenLeft);
    }
}
