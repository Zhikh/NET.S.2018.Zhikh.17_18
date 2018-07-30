namespace Task1.Logic
{
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// Call neede method
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        public BaseSquareMatrix<T> DynamicAdd(BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
            => Add((dynamic)left, right);

        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract SymmetricMatrix<T> Add(SymmetricMatrix<T> left, SymmetricMatrix<T> right);

        /// <summary>
        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract DiagonalMatrix<T> Add(DiagonalMatrix<T> left, DiagonalMatrix<T> right);

        /// <summary>
        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract SquareMatrix<T> Add(SquareMatrix<T> left, BaseSquareMatrix<T> right);

        /// <summary>
        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract SquareMatrix<T> Add(BaseSquareMatrix<T> left, SquareMatrix<T> right);

        /// <summary>
        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract SymmetricMatrix<T> Add(SymmetricMatrix<T> left, DiagonalMatrix<T> right);

        /// <summary>
        /// Extension methos for finding sum
        /// </summary>
        /// <param name="left"> Matrix </param>
        /// <param name="right"> Matrix </param>
        protected abstract SymmetricMatrix<T> Add(DiagonalMatrix<T> left, SymmetricMatrix<T> right);
    }
}
