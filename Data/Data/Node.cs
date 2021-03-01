using RBush;
using System;

namespace Data.Data
{
    public class Node : SearchArea, ISpatialData, IComparable<Node>, IEquatable<Node>
    {
        public ref readonly Envelope Envelope => ref envelope;
        private readonly Envelope envelope;
        public double CostToParent { get; set; }
        public Node Parent { get; set; }

        public Node(Position position) : base(position)
        {
            envelope = position.GetNewEnvelope();
        }

        public Node(int posX, int posY) :base(posX, posY)
        {
            envelope = new Position(posX, posY).GetNewEnvelope();
        }

        public int CompareTo(Node other)
        {
            if (this.Envelope.MinX != other.Envelope.MinX)
                return this.Envelope.MinX.CompareTo(other.Envelope.MinX);
            if (this.Envelope.MinY != other.Envelope.MinY)
                return this.Envelope.MinY.CompareTo(other.Envelope.MinY);
            if (this.Envelope.MaxX != other.Envelope.MaxX)
                return this.Envelope.MaxX.CompareTo(other.Envelope.MaxX);
            if (this.Envelope.MaxY != other.Envelope.MaxY)
                return this.Envelope.MaxY.CompareTo(other.Envelope.MaxY);
            return 0;
        }

        public bool Equals(Node other) =>
            this.envelope == other.envelope;

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }
    }
}
