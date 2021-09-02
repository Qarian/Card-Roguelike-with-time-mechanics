﻿using System;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
    [RequireComponent(typeof(Canvas))]
    public class CanvasDataProvider : BaseSingleton<CanvasDataProvider>
    {
        public Canvas canvas { get; private set; }

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }
    }
}