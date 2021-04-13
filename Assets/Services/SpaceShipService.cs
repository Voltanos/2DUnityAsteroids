using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Models;

namespace Assets.Services
{
	public class SpaceShipService : ISpaceShipService
	{
		private SpaceShipModel _model;

		public SpaceShipService()
		{
			_model = new SpaceShipModel();
		}

		public SpaceShipModel Read()
		{
			return _model;
		}

		public void Update(SpaceShipModel model)
		{
			_model = model;
		}
	}
}
