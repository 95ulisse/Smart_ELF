﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace SmartApp.HAL.Model
{
    public class VideoFrame
    {

        public VideoFrame(DateTime timestamp, IList<Face> faces, Image<Bgr, byte> image)
        {
            Timestamp = timestamp;
            Faces = faces ?? throw new ArgumentNullException(nameof(faces));
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public DateTime Timestamp { get; private set; }
        public IList<Face> Faces { get; private set; }
        public Image<Bgr, byte> Image { get; private set; }



        public struct Face
        {
            public Face(Rectangle bounds)
            {
                Bounds = bounds;
            }

            public Rectangle Bounds { get; private set; }
        }
    }
}