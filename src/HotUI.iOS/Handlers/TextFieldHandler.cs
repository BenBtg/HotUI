﻿using System;
using System.Collections.Generic;
using UIKit;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace HotUI.iOS
{
    public class TextFieldHandler : UITextField, IUIView
    {
        private static readonly PropertyMapper<TextField, TextFieldHandler> Mapper = new PropertyMapper<TextField, TextFieldHandler>()
        {
            [nameof(TextField.Text)] = MapTextProperty
        };
        
        private TextField _textField;

        public TextFieldHandler()
        {
            EditingDidEnd += EntryHandler_EditingDidEnd;

            ShouldReturn = s =>
            {
                ResignFirstResponder();
                return true;
            };
        }

        public UIView View => this;
        
        public void Remove(View view)
        {
            _textField = null;
        }

        public void SetView(View view)
        {
            _textField = view as TextField;
            Mapper.UpdateProperties(this, _textField);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, property, value);
        }

        private void EntryHandler_EditingDidEnd(object sender, EventArgs e)
        {
            _textField?.Completed(Text);
        }
        
        public static bool MapTextProperty(TextFieldHandler nativeView, object value)
        {
            nativeView.Text = (string)value;
            nativeView.SizeToFit();
            return true;
        }
    }
}