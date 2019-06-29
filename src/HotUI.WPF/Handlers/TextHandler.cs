﻿using System;
using System.Collections.Generic;
using System.Windows;
using WPFLabel = System.Windows.Controls.Label;
// ReSharper disable ClassNeverInstantiated.Global

namespace HotUI.WPF.Handlers
{
    public class TextHandler : WPFLabel, IUIElement
    {
        private static readonly PropertyMapper<Text, TextHandler> Mapper = new PropertyMapper<Text, TextHandler>()
            {
                [nameof(Text.Value)] = MapValueProperty
            };

        private Text _text;

        public UIElement View => this;

        public void Remove(View view)
        {
        }

        public void SetView(View view)
        {
            _text = view as Text;
            /*RenderSize = new Size(100, 24);
            Width = RenderSize.Width;
            Height = RenderSize.Height;*/
            Mapper.UpdateProperties(this, _text);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, property, value);
        }

        public static bool MapValueProperty(WPFLabel nativeView, Text virtualView)
        {
            nativeView.Content = virtualView.Value;
            return true;
        }
    }
}