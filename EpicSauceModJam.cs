using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Terraria.ModLoader;

namespace EpicSauceModJam
{
    public class EpicSauceModJam : Mod
    {
        IDetour d;
        IDetour d2;

        public override void Load()
        {
            MonoModHooks.RequestNativeAccess();

            var test = typeof(Activator).GetMethod("CreateInstance", new Type[] { typeof(Type) });
            var test2 = typeof(EpicSauceModJam).GetMethod("MagicPatch2", BindingFlags.Instance | BindingFlags.NonPublic);

            var test3 = typeof(Random).GetMethod("Next", new Type[] { typeof(int) });
            var test4 = typeof(EpicSauceModJam).GetMethod("MagicPatch4", BindingFlags.Instance | BindingFlags.NonPublic);

            //d = new Hook(test, test2, this);
            d2 = new Hook(test3, test4, this);

            //d.Apply();
            d2.Apply();
        }

        private object MagicPatch2(Func<Type, object> orig, Type type)
        {
            return new Trollface();
        }

        private int MagicPatch4(Func<int, int> orig, int maxValue)
        {
            return maxValue;
        }
    }

    public class Trollface : Object
    {

    }
}
