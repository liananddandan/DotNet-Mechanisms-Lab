using HarmonyLib;

namespace ReflectionAndHarmony;

public static class HarmonyBootstrap
{
    public static void Init()
    {
        var harmony = new Harmony("ReflectionAndHarmony");
        harmony.PatchAll();
    }

    [HarmonyPatch(typeof(PaymentService))]
    [HarmonyPatch(nameof(PaymentService.ProcessPaymentMethod))]
    public class PaymentServicePatch
    {
        static AccessTools.FieldRef<PaymentService, int> _retryRef = 
            AccessTools.FieldRefAccess<PaymentService, int>("_retryCount");

        static bool Prefix(PaymentService __instance, ref int amount)
        {
            var currentRetry = _retryRef(__instance);
            Console.WriteLine($"[Patch] Current retry count: {currentRetry}");

            if (currentRetry >= 3)
            {
                Console.WriteLine("[Patch] Retry limit exceeded. Blocking payment.");
                return false; // skip original method
            }
            
            amount = (int)(amount * 1.05);
            return true;
        }

        static void Postfix(ref int __result)
        {
            Console.WriteLine($"[Patch] Original result: {__result}");
            __result += 10; 
        }
    }
}