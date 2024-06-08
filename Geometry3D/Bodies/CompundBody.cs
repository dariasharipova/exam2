using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry3D
{
    public class CompoundBody : Body
    {
        public IReadOnlyList<Body> Parts { get; }

        public CompoundBody(IReadOnlyList<Body> parts) : base(parts[0].Position)
        {
            Parts = parts;
        }

        public override bool ContainsPoint(Vector3 point)
        {
            var counter = 0;
            while ((counter == Parts.Count) | !(Parts[counter].ContainsPoint(point)))
            {
                counter++;
            }
            return counter < Parts.Count;
        }
        public override RectangularCuboid GetBoundingBox()
        {
            var maxX = Parts[0].GetBoundingBox().Position.X + Parts[0].GetBoundingBox().SizeX / 2;
            var minX = Parts[0].GetBoundingBox().Position.X - Parts[0].GetBoundingBox().SizeX / 2;

            var maxY = Parts[0].GetBoundingBox().Position.Y + Parts[0].GetBoundingBox().SizeY / 2;
            var minY = Parts[0].GetBoundingBox().Position.Y - Parts[0].GetBoundingBox().SizeY / 2;

            var maxZ = Parts[0].GetBoundingBox().Position.Z + Parts[0].GetBoundingBox().SizeZ / 2;
            var minZ = Parts[0].GetBoundingBox().Position.Z - Parts[0].GetBoundingBox().SizeZ / 2;

            for(var i = 1; i<Parts.Count; i++)
            {
                maxX = Math.Max(maxX, Parts[i].GetBoundingBox().Position.X + Parts[i].GetBoundingBox().SizeX / 2);
                minX = Math.Min(minX, Parts[i].GetBoundingBox().Position.X - Parts[i].GetBoundingBox().SizeX / 2);

                maxY = Math.Max(maxY, Parts[i].GetBoundingBox().Position.Y + Parts[i].GetBoundingBox().SizeY / 2);
                minY = Math.Min(minY, Parts[i].GetBoundingBox().Position.Y - Parts[i].GetBoundingBox().SizeY / 2);

                maxZ = Math.Max(maxZ, Parts[i].GetBoundingBox().Position.Z + Parts[i].GetBoundingBox().SizeZ / 2);
                minZ = Math.Min(minZ, Parts[i].GetBoundingBox().Position.Z - Parts[i].GetBoundingBox().SizeZ / 2);
            }
            return new RectangularCuboid(new Vector3((maxX + minX)/2, (maxY + minY) / 2, (maxZ + minZ) / 2), maxX - minX, maxY - minY, maxZ - minZ);
            
        }
    }
}
