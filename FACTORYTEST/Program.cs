// Abstract Factory
public interface IBankFactory
{
    SavingsAccount CreateSavingsAccount();
    CheckingAccount CreateCheckingAccount();
}

// Concrete Factory 1 (for USA)
public class USABankFactory : IBankFactory
{
    public SavingsAccount CreateSavingsAccount()
    {
        return new USASavingsAccount();
    }

    public CheckingAccount CreateCheckingAccount()
    {
        return new USACheckingAccount();
    }
}

// Concrete Factory 2 (for EU)
public class EUBankFactory : IBankFactory
{
    public SavingsAccount CreateSavingsAccount()
    {
        return new EUSavingsAccount();
    }

    public CheckingAccount CreateCheckingAccount()
    {
        return new EUCheckingAccount();
    }
}

// Abstract Products
public abstract class SavingsAccount
{
    public abstract void AccountType();
}

public abstract class CheckingAccount
{
    public abstract void AccountType();
}

// Concrete Products for USA
public class USASavingsAccount : SavingsAccount
{
    public override void AccountType()
    {
        Console.WriteLine("USA Savings Account");
    }
}

public class USACheckingAccount : CheckingAccount
{
    public override void AccountType()
    {
        Console.WriteLine("USA Checking Account");
    }
}

// Concrete Products for EU
public class EUSavingsAccount : SavingsAccount
{
    public override void AccountType()
    {
        Console.WriteLine("EU Savings Account");
    }
}

public class EUCheckingAccount : CheckingAccount
{
    public override void AccountType()
    {
        Console.WriteLine("EU Checking Account");
    }
}

// Client code using Abstract Factory
public class BankClient
{
    private SavingsAccount _savingsAccount;
    private CheckingAccount _checkingAccount;

    public BankClient(IBankFactory factory)
    {
        _savingsAccount = factory.CreateSavingsAccount();
        _checkingAccount = factory.CreateCheckingAccount();
    }

    public void ShowAccountTypes()
    {
        _savingsAccount.AccountType();
        _checkingAccount.AccountType();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // For USA
        IBankFactory usaFactory = new USABankFactory();
        BankClient usaClient = new BankClient(usaFactory);
        usaClient.ShowAccountTypes();  // Output: USA Savings Account, USA Checking Account

        // For EU
        IBankFactory euFactory = new EUBankFactory();
        BankClient euClient = new BankClient(euFactory);
        euClient.ShowAccountTypes();   // Output: EU Savings Account, EU Checking Account
    }
}
