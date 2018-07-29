namespace Task1.Logic
{
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// Call neede method
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        public void DynamicVisit(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
            => Visit((dynamic)left, (dynamic)right);

        /// <summary>
        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract void Visit(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right);
    }
}
