using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EpicSauceModJam
{
    public class EpicSauceModJam : Mod
    {
        public override void Load()
        {
            Main.rand = new Trollface();
            On.Terraria.Utils.NextFloat_UnifiedRandom += Oops;
            On.Terraria.Utils.NextFloat_UnifiedRandom_float += Oops2;
            On.Terraria.Utils.NextFloat_UnifiedRandom_float_float += Oops3;
        }

        private float Oops3(On.Terraria.Utils.orig_NextFloat_UnifiedRandom_float_float orig, UnifiedRandom r, float minValue, float maxValue)
        {
            return maxValue - 0.01f;
        }

        private float Oops2(On.Terraria.Utils.orig_NextFloat_UnifiedRandom_float orig, UnifiedRandom r, float maxValue)
        {
            return maxValue - 0.01f;
        }

        private float Oops(On.Terraria.Utils.orig_NextFloat_UnifiedRandom orig, UnifiedRandom r)
        {
            return 1;
        }

        public override void PreUpdateEntities()
        {
            if (!(Main.rand is Trollface))
                Main.rand = new Trollface();
        }
    }

    public class Trollface : UnifiedRandom
    {
        public override int Next(int maxValue)
        {
            return maxValue - 1;
        }

        public override int Next(int minValue, int maxValue)
        {
            return maxValue - 1;
        }

        public override int Next()
        {
            return 1;
        }

        public override double NextDouble()
        {
            return 1;
        }
    }
}
