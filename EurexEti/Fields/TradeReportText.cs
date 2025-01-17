using System;
using System.Runtime.CompilerServices;

namespace Eurex.EtiDerivatives.v130
{
    /// <summary>
    ///  Trade Report Text: Optional Fixed Length Space Filled String Field
    /// </summary>

    public static class TradeReportText
    {
        /// <summary>
        ///  Fix Tag for Trade Report Text
        /// </summary>
        public const ushort FixTag = 28583;

        /// <summary>
        ///  Length of Trade Report Text in bytes
        /// </summary>
        public const int Length = 20;

        /// <summary>
        ///  Encode Trade Report Text
        /// </summary>
        public unsafe static void Encode(byte* pointer, int offset, string value, int length, out int current)
        {
            if (length > offset + TradeReportText.Length)
            {
                throw new System.Exception("Invalid Length for Trade Report Text");
            }

            Encode(pointer, offset, value, out current);
        }

        /// <summary>
        ///  Encode Trade Report Text
        /// </summary>
        public unsafe static void Encode(byte* pointer, int offset, string value, out int current)
        {
            var position = pointer + offset;

            var end = Math.Min(value.Length, TradeReportText.Length);

            for (var i = 0; i < end; i++)
            {
                *(position++) = (byte)value[i];
            }

            end = TradeReportText.Length - end;

            for(var i = 0; i < end; i++)
            {
                *(position++) = (byte)' ';
            }

            current = offset + TradeReportText.Length;
        }

        /// <summary>
        ///  Check available length and set Trade Report Text to no value
        /// </summary>
        public unsafe static void SetNull(byte* pointer, int offset, int length, out int current)
        {
            if (length > offset + TradeReportText.Length)
            {
                throw new System.Exception("Invalid Length for Trade Report Text");
            }

            SetNull(pointer, offset, out current);
        }

        /// <summary>
        ///  Set Trade Report Text to no value and update index
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void SetNull(byte* pointer, int offset, out int current)
        {
            SetNull(pointer, offset);

            current = offset + TradeReportText.Length;
        }

        /// <summary>
        ///  Set Trade Report Text to no value
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void SetNull(byte* pointer, int offset)
        {
            var position = pointer + offset;

            for (var i = 0; i < TradeReportText.Length; i++)
            {
                *(position++) = 0;
            }
        }

        /// <summary>
        ///  TryDecode Trade Report Text
        /// </summary>
        public unsafe static bool TryDecode(byte* pointer, int offset, int length, out string value, out int current)
        {
            if (length > offset + TradeReportText.Length)
            {
                return TryDecode(pointer, offset, out value, out current);
            }

            value = string.Empty;

            current = offset;

            return false;
        }

        /// <summary>
        ///  TryDecode Trade Report Text
        /// </summary>
        public unsafe static bool TryDecode(byte* pointer, int offset, out string value, out int current)
        {
            current = offset + TradeReportText.Length;

            value = string.Empty;

            if (*(pointer + offset) == 0)
            {
                return false;
            }

            value = Decode(pointer, offset);

            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        ///  Decode Trade Report Text
        /// </summary>
        public unsafe static string Decode(byte* pointer, int offset, out int current)
        {
            current = offset + TradeReportText.Length;

            return Decode(pointer, offset);
        }

        /// <summary>
        ///  Decode Trade Report Text
        /// </summary>
        public unsafe static string Decode(byte* pointer, int offset)
        {
            return new string ((sbyte*)pointer, offset, TradeReportText.Length).Trim();
        }
    }
}