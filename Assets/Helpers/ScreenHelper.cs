using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Helpers
{
    public class ScreenHelper : IScreenHelper
    {
        public Vector3 AdjustPositionForScreen(Vector3 position, float screenTop, float screenRight, float screenBottom, float screenLeft)
        {
            Vector2 newPos = position;

			newPos.y = ScreenWrap(position.y, screenTop, screenBottom);
			newPos.x = ScreenWrap(position.x, screenRight, screenLeft);

			return newPos;
        }

		public float ScreenWrap(float currentValue, float maxValue, float minValue)
		{
			if (currentValue > maxValue)
			{
				return minValue;
			}

			if (currentValue < minValue)
			{
				return maxValue;
			}

			return currentValue;
		}
	}
}
