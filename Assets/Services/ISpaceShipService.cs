using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Models;

namespace Assets.Services
{
    public interface ISpaceShipService
    {
		SpaceShipModel Read();
		void Update(SpaceShipModel model);
    }
}
