namespace ReflectionAndHarmony;

public class PaymentService
{
    private int _retryCount = 0;

    public virtual int ProcessPaymentMethod(int amount)
    {
        _retryCount++;
        Console.WriteLine($"Payment processing attempt {_retryCount}, amount: {amount}");
        return amount;
    }
}