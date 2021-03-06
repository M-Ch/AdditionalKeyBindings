﻿using System.Linq;
using ColossalFramework.UI;
using UnityEngine;

namespace AdditionalKeyBindings.BindActions
{
	public class RoadToolSnapAction : IExecutableAction, IActionDescription
	{
		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return "Road tool snapping"; } }
		public string Command { get { return "AKB-RoadToolSnapping"; } }

		public void Execute()
		{
			var snapping = Object.FindObjectsOfType<UIMultiStateButton>().FirstOrDefault(i => i.name == "SnappingToggle" && i.isVisible);
			if (snapping != null)
				snapping.activeStateIndex = snapping.activeStateIndex.CycleIncrement(0, 1);
		}
	}
}