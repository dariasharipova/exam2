using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class Cylinder : Body
    {
        public double SizeZ { get; }

        public double Radius { get; }

        public Cylinder(Vector3 position, double sizeZ, double radius) : base(position)
        {
            SizeZ = sizeZ;
            Radius = radius;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            var vectorX = point.X - Position.X;
            var vectorY = point.Y - Position.Y;
            var length2 = vectorX * vectorX + vectorY * vectorY;
            var minZ = Position.Z - this.SizeZ / 2;
            var maxZ = minZ + this.SizeZ;

            return length2 <= this.Radius * this.Radius && point.Z >= minZ && point.Z <= maxZ;
        }

        public override RectangularCuboid GetBoundingBox()
        {
            return new RectangularCuboid(Position, Radius * 2, Radius * 2, SizeZ);
            
        }
    }

}
