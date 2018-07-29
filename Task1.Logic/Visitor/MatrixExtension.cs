using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public static class MatrixExtension
    {
        public static BaseSquareMatrix<T> Add<T>(this BaseSquareMatrix<T> left, BaseSquareMatrix<T> right)
        {
            var visitor = new ComputeAreaVisitor();
            visitor.DynamicVisit(shape);
            return visitor.Area;
        }
    }
}
