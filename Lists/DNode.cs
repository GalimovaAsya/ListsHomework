using System;
namespace Lists
{
    public class DNode
    {
        
        public int Value { get; set; }
        public DNode Next { get; set; }
        public DNode Privious { get; set; }

        public DNode(int value)
        {
            Value = value;
            Next = null;
            Privious = null;
        }
    }
}
