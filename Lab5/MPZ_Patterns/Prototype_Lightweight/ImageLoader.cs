using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MPZ_Patterns.Prototype
{
    public class UnitImagesFactory
    {
        public static Dictionary<Type, ImageBrush> Images = new Dictionary<Type, ImageBrush>();
        public static ImageBrush CrateImage(Type type, string iconUri)
        {
            if (!Images.ContainsKey(type))
            {
                ImageBrush image = new ImageBrush();
                image.ImageSource = new BitmapImage(new Uri(iconUri));
                Images.Add(type, image);
            }
            return Images[type];
        }
    }

}
