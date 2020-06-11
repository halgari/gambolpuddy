using System;
using System.Collections.Generic;
using System.IO.Enumeration;
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
                XEditLibWrapper.InitXEdit();
                var ext = new Extension(".dat");
                var srcFolder = "native-libs"
                    .RelativeTo(((AbsolutePath) Assembly.GetExecutingAssembly().Location).Parent);
                var destFolder = ((AbsolutePath)GetGlobal("ProgramPath"));
                foreach (var file in srcFolder.EnumerateFiles().Where(f => f.Extension == ext))
                {
                    var dest = file.RelativeTo(srcFolder).RelativeTo(destFolder);
                    if (dest.Exists) continue;
                    
                    file.CopyToAsync(file.RelativeTo(srcFolder).RelativeTo(destFolder)).Wait();
                }
                ListenToMessages();
            }
        }

        private static void ListenToMessages()
        {
            var th = new Thread(() =>
            {
                while (true)
                {
                    lock (XEditLibWrapper.LockObject)
                    {
                        XEditLibWrapper.GetMessagesLength(out int len);
                        if (len > 0)
                        {
                            var sb = new StringBuilder(len);
                            XEditLibWrapper.GetMessages(sb, len);
                            Utils.Log(sb.ToString(0, len));
                        }
                    }
                    Thread.Sleep(100);
                }
            });
            th.IsBackground = true;
            th.Name = "XEdit Logging Thread";
            th.Start();
        }
        
        public static void Shutdown()
        {
            lock (XEditLibWrapper.LockObject)
            {
                XEditLibWrapper.CloseXEdit();
            }
        }

        public static string GetGlobal(string name)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.GetGlobal(name, out var len));
                var sb = new StringBuilder((int)len);
                ThrowOnError(XEditLibWrapper.GetResultString(sb, (int)len));
                return sb.ToString(0, (int)len);
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
        
        public static void LoadPlugins(IEnumerable<string> plugins)
        {
            LoadPlugins(plugins.Select(p => (RelativePath) p));
        }
        
        public static void LoadPlugins(params string[] plugins)
        {
            LoadPlugins(plugins.Select(p => (RelativePath) p));
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
        
        public static uint GetElementUIntValue(ElementHandle element, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
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

        
        public static int GetElementIntValue(string elementPath, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.GetIntValue(element, valuePath, out var value));
                return value;
            }
        }
        
        public static void SetElementIntValue(string elementPath, string valuePath, int value)
        {
            lock (XEditLibWrapper.LockObject)
            {
                using var element = GetElement(elementPath);
                ThrowOnError(XEditLibWrapper.SetIntValue(element, valuePath, value));
                
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
        
        public static string GetElementStringValue(ElementHandle element, string valuePath)
        {
            lock (XEditLibWrapper.LockObject)
            {
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

        public static FileHandle AddFile(RelativePath myfileEsp, bool ignoreExists = true)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.AddFile((string)myfileEsp.FileName, ignoreExists, out var handle));
                LoadOrderNames.Add(myfileEsp.FileName);
                ThrowOnError(XEditLibWrapper.FileByLoadOrder(LoadOrderNames.IndexOf(myfileEsp.FileName), out FileHandle handle2));
                handle.Dispose();
                return handle2;
            }
        }

        public static ElementHandle CopyTo(ElementHandle src, FileHandle file, bool asNew = false)
        {
            lock (XEditLibWrapper.LockObject)
            {
                ThrowOnError(XEditLibWrapper.CopyElement(src, file, asNew, out ElementHandle other));
                return other;
            }
        }
    }

}