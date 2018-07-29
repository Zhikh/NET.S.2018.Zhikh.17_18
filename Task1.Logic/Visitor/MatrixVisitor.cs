namespace Task1.Logic
{
    public abstract class MatrixVisitor<T>
    {
        public void DynamicVisit(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
            => Visit((dynamic)left, (dynamic)right);

        protected abstract void Visit(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right);
    }
}
