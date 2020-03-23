using System;
using System.Linq;
using System.Text;

[System.Serializable]
public class MyCustomSerialization
{
    public int MyNumber = -1;
    public string MyString = string.Empty;

    public static byte[] Serialize(object obj)
    {
        //MyNumber.
        MyCustomSerialization data = (MyCustomSerialization)obj;
        byte[] myNumberBytes = BitConverter.GetBytes(data.MyNumber);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(myNumberBytes);
        //MyString.
        byte[] myStringBytes = Encoding.ASCII.GetBytes(data.MyString);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(myStringBytes);

        return JoinBytes(myNumberBytes, myStringBytes);
    }

    public static object Deserialize(byte[] bytes)
    {
        MyCustomSerialization data = new MyCustomSerialization();
        //MyNumber.
        byte[] myNumberBytes = new byte[4];
        Array.Copy(bytes, 0, myNumberBytes, 0, myNumberBytes.Length);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(myNumberBytes);
        data.MyNumber = BitConverter.ToInt32(myNumberBytes, 0);

        //MyString.
        byte[] myStringBytes = new byte[bytes.Length - 4];
        if (myStringBytes.Length > 0)
        {
            Array.Copy(bytes, 4, myStringBytes, 0, myStringBytes.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(myStringBytes);
            data.MyString = Encoding.UTF8.GetString(myStringBytes);
        }
        else
        {
            data.MyString = string.Empty;
        }

        return data;
    }


    private static byte[] JoinBytes(params byte[][] arrays)
    {
        byte[] rv = new byte[arrays.Sum(a => a.Length)];
        int offset = 0;
        foreach (byte[] array in arrays)
        {
            System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
            offset += array.Length;
        }
        return rv;
    }

}