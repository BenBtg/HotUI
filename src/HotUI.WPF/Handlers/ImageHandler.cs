﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPFImage = System.Windows.Controls.Image;
// ReSharper disable ClassNeverInstantiated.Global

namespace HotUI.WPF.Handlers
{
    public class ImageHandler : WPFImage, IUIElement
    {
        private static readonly PropertyMapper<Image, ImageHandler> Mapper = new PropertyMapper<Image, ImageHandler>()
        {
            [nameof(Image.Source)] = MapSourceProperty
        };
        
        private Image _image;
        internal string CurrentSource;

        public UIElement View => this;
        
        public void Remove(View view)
        {
        }

        public void SetView(View view)
        {
            _image = view as Image;
            Mapper.UpdateProperties(this, _image);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, property, value);
        }
        
        public static bool MapSourceProperty(ImageHandler nativeView, Image virtualView)
        {
            nativeView.UpdateSource(virtualView.Source);
            return true;
        }
    }

    public static partial class ControlExtensions
    {
        public static async void UpdateSource(this ImageHandler imageView, string source)
        {
            if (source == imageView.CurrentSource)
                return;
            
            imageView.CurrentSource = source;
            try
            {
                var image = await source.LoadImage();
                if (source == imageView.CurrentSource)
                    imageView.Source = image;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
       
        public static Task<ImageSource> LoadImage(this string source)
        {
            throw new NotImplementedException();
        }

        private static Task<ImageSource> LoadImageAsync(string urlString)
        {
            throw new NotImplementedException();

        }

        private static Task<ImageSource> LoadFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}