using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dictionary
{
    class PersistentDictionary<TKey,TValue>
    {
        // Create a dictionary of key, value pairs that is actually a file
        // Need to consider locking as read and writes may conflict
        // Need to understand what thread safe means fully
        // Start simple and just have it as a int, string dictionary
        // assume that the file is stored with the class
        // will need some form of index as 

        // data assuming int, string
        //
        // 0000 - unsigned int - number of elements
        // 0000 - unsigned int - pointer to current element
        // 0000 - int - handled by the binary writer and reader
        // 00 - unsigned int - Length of element handled by the binary writer and reader
        // bytes - string
        // ...
        // 0000 - int - handled by the binary writer and reader
        // 00 - unsigned int - Length of element handled by the binary writer and reader
        // bytes - string

        // Index
        // 0000 - unsigned int - number of elements
        // 0000 - unsigned int - pointer to data

        // Data
        // 


        #region Variables

        string _path = "";
        string _name = "PersistentDictionary";
        // Lets assume we will add the extension automatically but filename is not correct 

        readonly object _lockObject = new Object();
        UInt16 _size;
        UInt16 _pointer;

        #endregion
        #region Constructors

        public PersistentDictionary()
        {
            Open(_path, _name, false);
        }

        public PersistentDictionary(bool reset)
        {
            Open(_path, _name, reset);
        }

        public PersistentDictionary(string filename)
        {
            _name = filename;
            Open(_path, _name, false);
        }

        public PersistentDictionary(string path, string filename)
        {
            _name = filename;
            _path = path;
            Open(_path, _name, false);
        }
        public PersistentDictionary(string path, string filename, bool reset)
        {
            _name = filename;
            _path = path;
            Open(_path, _name, reset);
        }

        #endregion
        #region Proprties

        public int Count
        {
            get
            {
                return (_size);
            }
        }

        public string Path
        {
            get
            {
                return (_path);
            }
            set
            {
                _path = value;
            }
        }

        public string Name
        {
            get
            {
                return (_name);
            }
            set
            {
                _name = value;
            }
        }

        // Make the indexer property.
        public TValue this[TKey key]
        {
            get
            {
                // Need to search the index file 

                string data = "test data";
                return ((TValue)Convert.ChangeType(data, typeof(TValue)));
            }
            set
            {
                // Set the property's value for the key.
                Add(key, value);
            }
        }

        // Make the indexer property.
        public TValue this[int]
        {
            get
            {
                // Need to search the index file 

                string data = "test data";
                return ((TValue)Convert.ChangeType(data, typeof(TValue)));
            }
            set
            {
                // Set the property's value for the key.
                Add(key, value);
            }
        }

        #endregion
        #region Methods


        public void Add(TKey key, TValue value)
        {
            string filenamePath = System.IO.Path.Combine(_path, _name);
            lock (_lockObject)
            {
                Type keyParameterType = typeof(TKey);
                Type ValueParameterType = typeof(TValue);

                // append the new pointer the new index file

                BinaryWriter BinaryWriter = new BinaryWriter(new FileStream(filenamePath + ".idx", FileMode.Append));
                BinaryWriter.Write(_pointer);  // Write the pointer
                BinaryWriter.Close();

                // Need to consider how data is stored
                // so if int, string

                int offset = 0; 
                if (keyParameterType == typeof(int))
                {
                    offset = offset + 4;
                }

                if (ValueParameterType == typeof(string))
                {
                    offset = offset + 1 + Convert.ToString(value).Length; // Includes the byte length parameter
                }

                // Write the data

                BinaryWriter = new BinaryWriter(new FileStream(filenamePath + ".bin", FileMode.OpenOrCreate));
                BinaryWriter.Seek(0, SeekOrigin.Begin); // Move to start of the file
                _size++;
                BinaryWriter.Write(_size);  // Write the size
                _pointer = (UInt16)(_pointer + offset);
                BinaryWriter.Write(_pointer);  // Write the pointer
                BinaryWriter.Close();

                // Appending will only work if the file is deleted and the updates start again
                // Not sure if this is the best approach.
                // Need to update the 

                BinaryWriter = new BinaryWriter(new FileStream(filenamePath + ".bin", FileMode.Append));

                if (keyParameterType == typeof(int))
                {
                    int i = Convert.ToInt32(key);
                    BinaryWriter.Write(i);
                }

                if (ValueParameterType == typeof(string))
                {
                    string s = Convert.ToString(value);
                    BinaryWriter.Write(s);
                }
                BinaryWriter.Close();



            }
        }

        public void Clear()
        {
            lock (_lockObject)
            {
                Reset(_path, _name);
            }
        }

        #endregion
        #region Private

        private void Open(string path, string filename, bool reset)
        {
            string filenamePath = System.IO.Path.Combine(path, filename);
            if ((File.Exists(filenamePath + ".bin") == true) && (reset == false))
            {
                BinaryReader BinaryReader = new BinaryReader(new FileStream(filenamePath + ".bin", FileMode.Open));
                _size = BinaryReader.ReadUInt16();
                _pointer = BinaryReader.ReadUInt16();
                BinaryReader.Close();
            }
            else
            {
                File.Delete(filenamePath + ".bin");
                File.Delete(filenamePath + ".idx");
                Reset(path, filename);
            }
        }

        private void Reset(string path, string filename)
        {
            // Reset the file
            string filenamePath = System.IO.Path.Combine(path, filename);
            BinaryWriter BinaryWriter = new BinaryWriter(new FileStream(filenamePath + ".bin", FileMode.OpenOrCreate));
            BinaryWriter.Seek(0, SeekOrigin.Begin); // Move to start of the file
            _size = 0;
            _pointer = 4;   // Start of the data
            BinaryWriter.Write(_size);  // Write the new size
            BinaryWriter.Write(_pointer);  // Write the new pointer
            BinaryWriter.BaseStream.SetLength(4);
            BinaryWriter.Close();

            // Create the index

            BinaryWriter = new BinaryWriter(new FileStream(filenamePath + ".idx", FileMode.OpenOrCreate));
            BinaryWriter.BaseStream.SetLength(0);
            BinaryWriter.Close();

        }

        #endregion

    }
}
