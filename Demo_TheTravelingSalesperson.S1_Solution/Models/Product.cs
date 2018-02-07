using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    public class Product
    {
        #region ENUMERABLES
        public enum ProductType
        {
            None,
            Furry,
            Spotted,
            Dancing
        }

        #endregion

        #region FIELDS

        private ProductType _type;
        private int _numberOfUnits;
        private bool _onBackorder;

        #endregion

        #region PROPERTIES

        public ProductType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
            set { _numberOfUnits = value; }
        }

        public bool OnBackOrder
        {
            get { return _onBackorder; }
            set { _onBackorder = value; }
        }

        public Product()
        {
            _type = ProductType.None;
        }

        public Product(ProductType type, int numberOfUnits)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
        }
        #endregion

        #region METHODS

        public void AddProducts(int unitsToAdd)
        {
            _numberOfUnits += unitsToAdd;
        }

        public void SubtractProducts(int unitsToSubtract)
        {
            if (_numberOfUnits < unitsToSubtract)
            {
                _onBackorder = true;
            }
            _numberOfUnits -= unitsToSubtract;
        }

        #endregion
    }
}
