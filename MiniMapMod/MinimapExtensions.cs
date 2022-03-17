﻿using MiniMapLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MiniMapMod
{
    public static class MinimapExtensions
    {
        /// <summary>
        /// Converts the provided <paramref name="position"/> from world posiion to a 2D represetation defined by <paramref name="dimensions"/>
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimensions"></param>
        /// <returns></returns>
        public static Vector2 ToMinimapPosition(this Vector3 position, Range3D dimensions)
        {
            // may consider switching to integer math for whole library for performance
            // reasons but for now 32bit floats are fine
            float x = position.x;
            float z = position.z;

            // the offset represents the vertical and horizontal "scrolling" of the map
            x += dimensions.X.Offset;
            z += dimensions.Z.Offset;

            // ensure the dimensions are always between 0 and 1
            x /= dimensions.X.Difference;
            z /= dimensions.Z.Difference;

            return new(x * Settings.MinimapSize.Width, z * Settings.MinimapSize.Height);
        }
    }
}
