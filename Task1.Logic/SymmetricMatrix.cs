using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public sealed class SymmetricMatrix<T> : BaseSquareMatrix<T>
    {
        public SymmetricMatrix(int order) : base(order)
        {
           
        }

        public override T this[int indexRow, int indexColumn]
        {
            get
            {
                return _container[indexRow, indexColumn];
            }

            set
            {
                _container[indexRow, indexColumn] = value;

                if (indexRow != indexColumn)
                {
                    _container[indexColumn, indexRow] = value;
                }
            }
        }


    }
}
