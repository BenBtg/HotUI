﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using UWPTextField = Windows.UI.Xaml.Controls.TextBox;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace HotUI.UWP.Handlers
{
    public class TextFieldHandler : UWPTextField, IUIElement
    {
        private static readonly PropertyMapper<TextField, TextFieldHandler> Mapper = new PropertyMapper<TextField, TextFieldHandler>()
        {
            [nameof(TextField.Text)] = MapTextProperty
        };
        
        private TextField _textField;
        
        public UIElement View => this;
        
        public void Remove(View view)
        {
        }

        public void SetView(View view)
        {
            _textField = view as TextField;
            Mapper.UpdateProperties(this, _textField);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, _textField, property);
        }
        
        public static bool MapTextProperty(UWPTextField nativeView, object value)
        {
            nativeView.Text = (string)value;
            return true;
        }
    }
}