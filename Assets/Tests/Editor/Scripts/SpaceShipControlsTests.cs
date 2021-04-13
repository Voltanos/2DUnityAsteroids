using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Models;

namespace Assets.Tests.Editor.Scripts
{
    public class SpaceShipControlsTests
    {
        #region Properties

        private GameObject _obj;
        private SpaceShipControls _component;

        #endregion

        #region Setup()

        [SetUp]
        public void SetUp()
        {
            _obj = new GameObject();
            _obj.AddComponent<SpaceShipControls>();

            _component = _obj.GetComponent<SpaceShipControls>();
        }

        #endregion

        #region Unit-Tests

        #endregion
    }
}
