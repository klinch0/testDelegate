using System;
using System.Threading.Tasks;

public class SomethingHappend : Exception
{
    public SomethingHappend(string message)
        : base(message)
    {
    }
}
public class Account
{
    public void Check (int i)
    {
        Console.WriteLine(i);
        if (i * 2 == 4)
        {
            // ??? Invoke("success")
            throw new SomethingHappend("success");
        }
    }
}
public class Test
{
    static async Task Main()
    {
        var account = new Account();
        
        var result = await Job(account);

        Console.WriteLine(result);
    }

    static async Task<string> Job(Account account)
    {
        int i = 0;

        while (true)
        {
            try
            {
                account.Check(i);
                // if i*2 == 10 return "Success"
                i++;
                await Task.Delay(1000);
            }
            catch (SomethingHappend ex)
            {
                return ex.Message;
            }

        }
    }
}