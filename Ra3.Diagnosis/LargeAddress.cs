using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ra3.Diagnosis
{
    internal static class LargeAddress
    {
        public static bool IsLargeAddressEnabled(string path)
        {
            using var stream = File.OpenRead(path);
            using var reader = new BinaryReader(stream);
            reader.BaseStream.Seek(0x3C, SeekOrigin.Begin);
            var offset = reader.ReadUInt32() + 4 + 18;
            reader.BaseStream.Seek((int)offset, SeekOrigin.Begin);
            var characteristics = reader.ReadUInt16();
            return (characteristics & 0x0020) != 0;
        }

        public static void EnableLargeAddress(string path)
        {
            using var stream = File.OpenRead(path);
            using var reader = new BinaryReader(stream);
            reader.BaseStream.Seek(0x3C, SeekOrigin.Begin);
            var offset = reader.ReadUInt32() + 4 + 18;
            reader.BaseStream.Seek((int)offset, SeekOrigin.Begin);
            var characteristics = reader.ReadUInt16();
            characteristics |= 0x0020;
            reader.Close();
            stream.Close();

            var allBytes = File.ReadAllBytes(path);
            File.WriteAllBytes(path + ".backup", allBytes);
            File.Delete(path);
            using var writeStream = File.OpenWrite(path);
            using var writer = new BinaryWriter(writeStream);
            writer.Write(allBytes, 0, (int)offset);
            writer.Write(characteristics);
            writer.Write(allBytes, (int)offset + 2, (int)(allBytes.Length - (offset + 2)));
            writer.Close();
            writeStream.Close();
        }
    }
}