using System.Numerics;

namespace FacessoHoloLens.Content
{
    /// <summary>
    /// Constant buffer used to send hologram position transform to the shader pipeline.
    /// </summary>
    internal struct ModelConstantBuffer
    {
        public Matrix4x4 model;
    }

    /// <summary>
    /// Used to send per-vertex data to the vertex shader.
    /// </summary>
    public struct VertexPositionCoordinate
    {
        public VertexPositionCoordinate(Vector3 pos, Vector2 coord)
        {
            this.pos   = pos;
            this.coordinate = coord;
        }

        public Vector3 pos;
        public Vector2 coordinate;
    };
}
