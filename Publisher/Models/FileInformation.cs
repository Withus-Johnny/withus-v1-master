using System;
using System.IO;

namespace Publisher.Models
{
	public class FileInformation
	{
		public string FileName;
		public int Length, Compressed;
		public DateTime Creation;

		public FileInformation()
		{
			Creation = DateTime.Now;
		}
		public FileInformation(BinaryReader reader)
		{
			FileName = reader.ReadString();
			Length = reader.ReadInt32();
			Compressed = reader.ReadInt32();
			Creation = DateTime.FromBinary(reader.ReadInt64());
		}
		public void Save(BinaryWriter writer)
		{
			writer.Write(FileName);
			writer.Write(Length);
			writer.Write(Compressed);
			writer.Write(Creation.ToBinary());
		}
	}
}
