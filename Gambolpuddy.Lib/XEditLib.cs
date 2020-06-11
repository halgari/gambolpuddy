using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Gambolpuddy.Lib.Records;
using Gambolpuddy.Lib.Records.Fields;
using Wabbajack.Common;

namespace Gambolpuddy.Lib
{
    public enum XEditGame : int
    {
        FNV = 0,
        FO3 = 1,
        TES4 = 2,
        TES5 = 3, 
        SSE = 4,
        FO4 = 5
    }
    public static class XEditLib 
    {
        
        internal static List<RelativePath> LoadOrderNames = new List<RelativePath>();
        #region Setup

        public static void Init()
        {
            lock (XEditLibWrapper.LockObject)
            {
                var ext = new Extension(".dat");
                var srcFolder = "native-libs"
                    .RelativeTo(((AbsolutePath) Assembly.GetExecutingAssembly().Location).Parent);
                var destFolder = ((AbsolutePath)Assembly.GetEntryAssembly().Location).Parent;
                foreach (var file in srcFolder.EnumerateFiles().Where(f => f.Extension == ext))
                {
                    file.CopyToAsync(file.RelativeTo(srcFolder).RelativeTo(destFolder)).Wait();
                }
                XEditLibWrapper.InitXEdit();
            }
        }
        
        public static void Shutdown()
        {
            lock (XEditLibWrapper.LockObject)
            {
                XEditLibWrapper.CloseXEdit();
            }
        }


        public static void SetGameMode(XEditGame game)
        {
            lock (XEditLibWrapper.LockObject)
            {
                XEditLibWrapper.SetGameMode((int)game);
            }
        }
        
        public static void LoadPlugins(IEnumerable<RelativePath> plugins)
        {
            lock (XEditLibWrapper.LockObject)
            {
                LoadOrderNames = plugins.ToList();
                XEditLibWrapper.LoadPlugins(string.Join("\r\n", plugins.Select(p => p.ToString())));
                byte status = 0;
                while (status < 2)
                {
                    ThrowOnError(XEditLibWrapper.GetLoaderStatus(out status));
                    Thread.Sleep(100);
                }
            }
        }

        #endregion

        #region Elements

        

        public static ElementHandle GetElement(string path)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.GetElement(0, path, out var res), path);
                return res;
            }
        }

        public static uint ElementCount(string elementPath, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath + "\\" + valuePath);
                ThrowOnError(XEditLibWrapper.ElementCount(element, out var value));
                return value;
            }
        }
        
        public static uint GetElementUIntValue(string elementPath, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.GetUIntValue(element, valuePath, out var value));
                return value;
            }
        }
        
        public static void SetElementUIntValue(string elementPath, string valuePath, uint value)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.SetUintValue(element, valuePath, value));
            }
        }
        
        public static double GetElementFloatValue(string elementPath, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.GetFloatValue(element, valuePath, out var value));
                return value;
            }
        }
        
        public static void SetElementFloatValue(string elementPath, string valuePath, double value)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.SetFloatValue(element, valuePath, value));
            }
        }
        
        public static string GetElementStringValue(string elementPath, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.GetValue(element, valuePath, out var len));
                var sb = new StringBuilder((int)len);
                ThrowOnError(XEditLibWrapper.GetResultString(sb, (int)len));
                return sb.ToString(0, (int)len);
            }
        }
        
        public static void SetElementStringValue(string elementPath, string valuePath, string value)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.SetValue(element, valuePath, value));
            }
        }
       
        public static FileHandle GetElementFile(ElementHandle element)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.GetElementFile(element, out var file));
                return file;
            }
        }

        public static Cursor GetCursorFromFormId(uint form)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.GetRecord(0, form, true, out uint record));

                XEditLibWrapper.GetElement(record, "Record Header\\FormID", out ElementHandle elementHandle);
                using var handle = GetElementFile(elementHandle);
                var pos = GetFileLoadOrder(handle);
                return new Cursor((uint)pos, form);

            }
        }
        
        #endregion

        
        public static int GetFileLoadOrder(FileHandle file)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.GetFileLoadOrder(file, out var pos));
                return pos;
            }
        }


        public static void ThrowOnError(bool success, string context = null)
        {
            if (!success)
                throw new Exception($"XEditLib call Error : {context}");
        }

    }

}