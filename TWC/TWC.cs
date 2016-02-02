namespace TWC
{
    public class TWC
    {
        float[] vertices, normals, coordinates;
        public TWC()
        {

        }
        public static TWC LoadTWC(string filepath)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(System.IO.File.OpenRead(filepath));
            if (reader.ReadChars(3).ToString() == "TWC") // Correct Filetype
            {
                short meshcount = reader.ReadInt16();
                short bonecount = reader.ReadInt16();
                short animcount = reader.ReadInt16();
            }
            return new TWC();
        }
    }
}
