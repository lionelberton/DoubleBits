using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleBits
{
    /// <summary>
    /// Vue model pour la conversion des doubles en bits et inversement.
    /// </summary>
    public class DoubleBitsViewModel : ViewModelBase
    {
        /// <summary>
        /// Flag pour empêcher une boucle infinie.
        /// </summary>
        bool _calculating;

        private double _doubleValue;
        /// <summary>
        /// Gets or sets the double value.
        /// </summary>
        /// <value>
        /// The double value.
        /// </value>
        public double DoubleValue
        {
            get
            {
                return _doubleValue;
            }
            set
            {
                _doubleValue = value;
                base.OnPropertyChanged();
                DoubleToBits(value);
            }
        }

        /// <summary>
        /// Doubles to bits.
        /// </summary>
        /// <param name="value">The value.</param>
        private void DoubleToBits(double value)
        {
            if (_calculating) return;
            _calculating = true;
            BinaryValue = string.Format("{0:X16}", BitConverter.DoubleToInt64Bits(value));
            AddLog(DoubleValue, BinaryValue);
            _calculating = false;
        }

        private string _binaryValue;
        /// <summary>
        /// Gets or sets the binary value.
        /// </summary>
        /// <value>
        /// The binary value.
        /// </value>
        public string BinaryValue
        {
            get
            {
                return _binaryValue;
            }
            set
            {
                _binaryValue = value;
                base.OnPropertyChanged();
                BitsToDouble(value);
            }
        }

        /// <summary>
        /// Bitses to double.
        /// </summary>
        /// <param name="value">The value.</param>
        private void BitsToDouble(string value)
        {
            if (_calculating) return;
            _calculating = true;
            DoubleValue = BitConverter.Int64BitsToDouble(Convert.ToInt64(value, 16));
            AddLog(DoubleValue, BinaryValue);
            _calculating = false;
        }

        /// <summary>
        /// Adds to the log.
        /// </summary>
        /// <param name="doubleValue">The double value.</param>
        /// <param name="binaryValue">The binary value.</param>
        private void AddLog(double doubleValue, string binaryValue)
        {
            Log += string.Format("{0,25:E16}{1,23:X16}\n", doubleValue, binaryValue);
        }

        private string _log;
        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        public string Log
        {
            get
            {
                return _log;
            }
            set
            {
                _log = value;
                base.OnPropertyChanged();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBitsViewModel"/> class.
        /// </summary>
        public DoubleBitsViewModel()
        {
            DoubleValue = 0;
            DoubleValue = 1;
            DoubleValue = 0.5;
            DoubleValue = 1.0000000000000002;

        }

    }
}
