﻿using GMap.NET;
using System.Drawing;


namespace TRUCKCOY.classes
{
    public class GMapPoint : GMap.NET.WindowsForms.GMapMarker
    {
        private PointLatLng point_;
        private float size_;
        public PointLatLng Point
        {
            get
            {
                return point_;
            }
            set
            {
                point_ = value;
            }
        }
        public GMapPoint(PointLatLng p, int size)
            : base(p)
        {
            point_ = p;
            size_ = size;
        }

        public override void OnRender(Graphics g)
        {
            g.FillEllipse(Brushes.SteelBlue, LocalPosition.X, LocalPosition.Y, size_, size_);
            //OR 
            g.DrawEllipse(Pens.AliceBlue, LocalPosition.X, LocalPosition.Y, size_, size_);
            //OR whatever you need

        }
    }
}
