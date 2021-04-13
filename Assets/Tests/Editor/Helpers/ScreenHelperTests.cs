using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Models;
using Assets.Helpers;

namespace Assets.Tests.Editor.Helpers
{
    [TestFixture]
    public class ScreenHelperTests
    {
        #region Properties

        private ScreenHelper _helper;

        #endregion

        #region Setup()

        [SetUp]
        public void Setup()
        {
            _helper = new ScreenHelper();
        }

        #endregion

        #region Unit-Tests

        [
            TestCase
            (
                11.0f,
                5.0f,
                10.0f,
                10.0f,
                -10.0f,
                -10.0f,
                -10.0f,
                5.0f
            )
        ]
        [
            TestCase
            (
                5.0f,
                11.0f,
                10.0f,
                10.0f,
                -10.0f,
                -10.0f,
                5.0f,
                -10.0f
            )
        ]
        [
            TestCase
            (
                -11.0f,
                5.0f,
                10.0f,
                10.0f,
                -10.0f,
                -10.0f,
                10.0f,
                5.0f
            )
        ]
        [
            TestCase
            (
                5.0f,
                -11.0f,
                10.0f,
                10.0f,
                -10.0f,
                -10.0f,
                5.0f,
                10.0f
            )
        ]
        [
            TestCase
            (
                5.0f,
                5.0f,
                10.0f,
                10.0f,
                -10.0f,
                -10.0f,
                5.0f,
                5.0f
            )
        ]
        public void Update_WhenPositionIsPastScreenBorder_AdjustPosition
            (
                float currentX,
                float currentY,
                float screenTop,
                float screenRight,
                float screenBottom,
                float screenLeft,
                float expectedX,
                float expectedY
            )
        {
            //Assign.
            Vector3 position = new Vector3(currentX, currentY);
            Vector3 returnedPosition = new Vector3();

            //Act.
            returnedPosition = _helper.AdjustPositionForScreen(position, screenTop, screenRight, screenBottom, screenLeft);

            //Assert.
            Assert.AreEqual(returnedPosition.x, expectedX);
            Assert.AreEqual(returnedPosition.y, expectedY);
        }

        [TestCase(11.0f, 10.0f, -10.0f, -10.0f)]
        [TestCase(-11.0f, 10.0f, -10.0f, 10.0f)]
        [TestCase(5.0f, 10.0f, -10.0f, 5.0f)]
        public void ScreenWrap_WhenDataIsProvided_ReturnExpectedValue(float currentValue, float maxValue, float minValue, float expectedValue)
        {
            //Assign.
            float returnedValue = -1.0f;

            //Act.
            returnedValue = _helper.ScreenWrap(currentValue, maxValue, minValue);

            //Assert.
            Assert.AreNotEqual(-1.0f, returnedValue);
            Assert.AreEqual(expectedValue, returnedValue);
        }

        #endregion
    }
}
