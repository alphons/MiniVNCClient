﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniVNCClient.Types
{
	[StructLayout(LayoutKind.Sequential), Serializable]
	public struct PixelFormat
	{
		public byte BitsPerPixel;
		public byte Depth;
		public byte BigEndianFlag;
		public byte TrueColorFlag;
		public ushort RedMax;
		public ushort GreenMax;
		public ushort BlueMax;
		public byte RedShift;
		public byte GreenShift;
		public byte BlueShift;
		public byte[] Padding;

		public int BytesPerPixel => (BitsPerPixel + 7) / 8;

		public static PixelFormat Deserialize(Stream stream)
		{
			var reader = new Util.BinaryReader(stream);

			return new PixelFormat()
			{
				BitsPerPixel = reader.ReadByte(),
				Depth = reader.ReadByte(),
				BigEndianFlag = reader.ReadByte(),
				TrueColorFlag = reader.ReadByte(),
				RedMax = reader.ReadUInt16(),
				GreenMax = reader.ReadUInt16(),
				BlueMax = reader.ReadUInt16(),
				RedShift = reader.ReadByte(),
				GreenShift = reader.ReadByte(),
				BlueShift = reader.ReadByte(),
				Padding = reader.ReadBytes(3),
			};
		}
	}
}
