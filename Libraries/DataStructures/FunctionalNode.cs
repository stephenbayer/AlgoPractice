using System;
namespace DataStructures
{
    public class FunctionalNode<T> : INode<T>
    {
        private readonly Func<T, T> _func;

        public FunctionalNode(Func<T, T> func, T value)
        {
            _func = func;
            Value = value;
        }

        public T Value { get; set; }

        public INode<T> Next()
        {
            return new FunctionalNode<T>(_func, _func(Value));
        }

        public void SetChild(INode<T> child)
        {
            throw new NotImplementedException();
        }
    }
}
