using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ProtocolC1218
{
    class crc
    {
        /**
        ******************************************************************************
        * \fn public UInt16 calc_crc16(Byte[] data, UInt16 nbrBytes)
        * \brief Computes the 16-bit CRC of the specified data.
        *
        *                                              16   12   5
        *        This is the CCITT CRC 16 polynomial X  + X  + X  + 1.
        *        This works out to be 0x1021, but the way the algorithm works
        *        lets us use 0x8408 (the reverse of the bit pattern).  The high
        *        bit is always assumed to be set, thus we only use 16 bits to
        *        represent the 17 bit value.
        * \param pData Pointer to data
        * \param num_bytes The length of the data
        * \retval crc12 The CRC of the data
        ******************************************************************************
        */
        public UInt16 calc_crc16(Byte[] data, UInt16 nbrBytes)
        {
            UInt16 crc = 0xffff;
            byte chr, temp, i;
            byte j = 0;

            do
            {
                for (i = 0, chr = data[j]; i < 8; i++, chr >>= 1)
                {
                    temp = Convert.ToByte((crc) & 0x0001);
                    crc >>= 1;
                    if ((temp ^ (chr & 0x01)) != 0)
                    {
                        crc ^= 0x8408;
                    }
                }
                nbrBytes--;
                j++;
            }
            while (0 != nbrBytes);

            crc = (ushort)~((crc << 8) | (crc >> 8));

            return crc;
        }

        /**
        ******************************************************************************
        * \fn public Byte calc_2s_complemet(Byte[] data, UInt16 nbr_bytes)
        * \brief Computes the 2's complement CRC of the specified data.
        *
        * \param pData Pointer to data
        * \param num_bytes The length of the data
        * \retval crc The CRC of the data
        ******************************************************************************
        */
        public Byte calc_2s_complemet(Byte[] data, UInt16 nbr_bytes)
        {
            UInt16 i;
            Byte crc = 0;

            for (i = 0; i < nbr_bytes; i++)
            {
                crc += data[i];
            }

            if (crc != 0)
            {
                crc = Convert.ToByte(0xFF - crc + 1);
            }

            return crc;
        }
    }
}

