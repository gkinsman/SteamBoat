using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamBoatService.Resources;

namespace SteamBoatService.Infrastructure {
    public abstract class VariableSource {
        public enum Variables {

            Bsp = 1,
            Awa = 2,
            Aws = 3,
            Twa = 4,
            Tws = 5,
            Twd = 6,
            Rudder2 = 7,
            DeltaTargetBsp = 8,
            Course = 9,
            Hdg = 13,
            Depth = 17,
            Rudder = 20,
            GpsQuality = 39,
            Lat = 48,
            Lon = 49,
            Cog = 50,
            Sog = 51,
            TargTwaN = 53,
            TargBspN = 54,
            TargVmg = 55,
            TargHeel = 56,
            PolarBsp = 57,
            PolarBspPercent = 58,
            VmgPercent = 66,
            TimeToStartGun = 70,
            PolVmcToMark = 87,
            MarkTime = 88,
            NextMarkTimeOnPort = 89,
            NextMarkTimeOnStrb = 90,
            LayDist = 96,
            LayTime = 97,
            LayBear = 98,
            VmcPercent = 99,
            PolVmc = 100,
            OptVmc = 101,
            OptVmcHdg = 101,
            OptVmcTwa = 103,
            DeltaTargetTwa = 104,
            MarkRng = 105,
            MarkBrg = 106,
            MarkGpsTime = 107,
            MarkTwa = 108,
            NextMarkRng = 111,
            NextMarkBrg = 112,
            NextMarkTwa = 113,
            NextMarkPolTime = 127,
            TargetBspPercent = 132,
            NextMarkAwa = 133,
            NextMarkAws = 134,
            TackAngle = 152,
            TackAnglePolar = 153,
            TargAwa = 154,
            MarkSet = 159,
            MarkDrift = 160,
            MarkLat = 161,
            MarkLon = 162,
            TwdLayMark = 224,
            TwdLayMark2 = 225,
            DeltaBspSog = 226,
            DeltaHdgCog = 227,
            TargTawLwy = 228,
            TargTwaP = 235,
            TargBspP = 236,
            TwdTarg = 237
        }


        public abstract Variable GetVariable(int id);

    }
}