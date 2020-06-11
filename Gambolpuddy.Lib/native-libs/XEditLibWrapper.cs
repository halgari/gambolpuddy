using System;
using System.Runtime.InteropServices;
using System.Text;
using Wabbajack.Common;

namespace Gambolpuddy.Lib
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ElementHandle : IDisposable
    {
        private uint _handle;

        public void Dispose()
        {
            lock (XEditLibWrapper.LockObject)
            {
                XEditLibWrapper.Release(_handle);
            }
        }

        public static implicit operator uint(ElementHandle e) => e._handle;
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FileHandle : IDisposable
    {
        private uint _handle;

        public void Dispose()
        {
            lock (XEditLibWrapper.LockObject)
            {
                XEditLibWrapper.Release(_handle);
            }
        }

        public void Save(string filename)
        {
            lock (XEditLibWrapper.LockObject)
            {
                var order = XEditLib.GetFileLoadOrder(this); 
                XEditLib.ThrowOnError(XEditLibWrapper.SaveFile(this, filename));
            }
        }

        public void AddMaster(string name)
        {
            if (!XEditLib.LoadOrderNames.Contains((RelativePath)name))
                throw new Exception("Cannot add {name} as master, file is not loaded");
            XEditLibWrapper.AddMaster(this, name);

        }

        public static implicit operator uint(FileHandle e) => e._handle;
    }

    public static class XEditLibWrapper
    {
        public static object LockObject = new object();

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void LoadPlugins(string sLoadPath, bool smartLoad = true, bool useDummies = false);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetGameMode(int gameId);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetLoaderStatus(out byte status);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void Initialize(string Path);

        #region Elements

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetElement(uint _id, string path, out ElementHandle res);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetElementFile (ElementHandle element, out FileHandle file);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetElementRecord(uint _id, out uint res);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool HasElement(uint _id, string path, out bool res);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ElementCount(ElementHandle h, out uint count);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool CopyElement(ElementHandle h, FileHandle file, bool asNew, out ElementHandle newElement);

        #endregion

        #region ElementValues 

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetValue(uint _id, string path, out uint len);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetValue(uint _id, string path, string value);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetUIntValue(ElementHandle h, string path, out uint value);

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetUintValue(uint _id, string path, uint value);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetIntValue(ElementHandle h, string path, out int value);

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetIntValue(uint _id, string path, int value);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetFloatValue(ElementHandle h, string path, out double value);

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SetFloatValue(uint _id, string path, double value);


        #endregion

        #region Files

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetFileLoadOrder(uint _id, out int pos);

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool AddFile(string myfileEsp, in bool ignoreExists, out FileHandle fileHandle);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool FileByLoadOrder(int order, out FileHandle fileHandle);
       
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool SaveFile(FileHandle file, string fileName);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool AddMaster(FileHandle file, string fileName);

        #endregion

        #region Messages

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void GetMessagesLength(out int len);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void GetMessages(StringBuilder str, int bufLen);

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void ClearMessages();

        #endregion

        #region Meta
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void InitXEdit();        

        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void CloseXEdit();


        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetResultString(StringBuilder sb, int len);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetGlobal(string name, out uint len);


        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern unsafe bool GetResultArray([In, Out] uint[] results, int len);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Release(uint handle);

        #endregion

        #region Records
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetRecord(uint _id, uint formId, bool searchMasters, out uint _res);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetRecords(uint _id, string search, bool includeOverrides, out int len);

        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindNextRecord(uint _id, string search, bool byEdid, bool byName, out uint _res);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetFormID(uint _id, out uint cardinal, bool native);

        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetWinningOverride(uint _id, out uint cardinal);
        
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetInjectionTarget(uint _id, out uint cardinal);

        #endregion

        #region Serialization
        [DllImport(@"native-libs\XEditLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void ElementToJson(uint id, out int len);        
        
        #endregion
    }
}