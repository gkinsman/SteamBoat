using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using Microsoft.Win32;
using SteamBoatService.Infrastructure;
using SteamBoatService.Resources;
using System.Runtime.InteropServices;
using log4net;

namespace SteamBoatService.Services {
    public class Expedition : VariableSource
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (Expedition));
        private static readonly ResourceManager rm = Properties.VariableNames.ResourceManager;

        [DllImport("ExpDLL")]
        private static extern void GetExpVar(short id, out double pValue, short iBoat);

        [DllImport("kernel32")]
        private unsafe static extern void* LoadLibrary(string dllname);

        [DllImport("kernel32")]
        private static extern unsafe void FreeLibrary(void* handle);

        private sealed unsafe class LibraryUnloader
        {
            private void* handle;

            internal LibraryUnloader(void* handle)
            {
                this.handle = handle;
            }

            ~LibraryUnloader()
            {
                if(handle != null)
                {
                    FreeLibrary(handle);
                }
            }
        }

        private static readonly LibraryUnloader unloader;

        static Expedition()
        {
            const string regPath = @"SOFTWARE\Expedition\Core";

            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(regPath);
                var dllPath = (string) key.GetValue("Location");

                dllPath = dllPath + @"\ExpDLL.dll";

                unsafe
                {
                    void* handle = LoadLibrary(dllPath);
                    if(handle == null)
                    {
                        throw new DllNotFoundException("Unable to find Expedition DLL");
                    }

                    log.Debug("Successfully loaded ExpDLL.dll");
                    unloader = new LibraryUnloader(handle);
                }

            }catch(NullReferenceException e)
            {
                log.Fatal("Expedition not installed", e);
            }
            catch(DllNotFoundException e)
            {
                log.Fatal(e.Message, e);
            }


        }

        public override Variable GetVariable(int id)
        {
            var varType = typeof (Variables);
            var shortName = Enum.GetName(varType, Enum.ToObject(varType,id));
            var longName = rm.GetString(shortName.ToUpper());

            double value = -9999;

            try
            {
                GetExpVar((short) id, out value, 0);
            }catch (DllNotFoundException e)
            {
                longName = "Expedition not available";
            }

            return new Variable
                             {
                                 Id = id,
                                 ShortName = shortName,
                                 LongName = longName,
                                 Value = value
                             };
        }
    }
}