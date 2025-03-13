using System.Linq.Expressions;

string[][] userEnteredValues = new string[][]
{
            new string[] { "1", "2", "3"},
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
};

Workflow1(userEnteredValues);

static void Workflow1(string[][] userEnteredValues)
{
    string operationStatusMessage = "good";
    string processStatusMessage = "";

try {
    foreach (string[] userEntries in userEnteredValues)
    {
        Process1(userEntries);
    }

    if (operationStatusMessage == "good")
    {
        operationStatusMessage = "operating procedure complete";
    }
} catch (InvalidCastException icex) {
    operationStatusMessage = "Invalid data. User input values must be valid integers.";
} catch (DivideByZeroException dbzex) {
    operationStatusMessage = "Invalid data. User input values must be non-zero values.";
} catch (Exception ex) {
    operationStatusMessage = "An error occurred during 'Workflow1'.";
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}
}

static void Process1(String[] userEntries)
{
    int valueEntered;

    try {
        foreach (string userValue in userEntries)
        {
            valueEntered = int.Parse(userValue);

            checked
            {
                int calculatedValue = 4 / valueEntered;
            }
        }

    } catch (InvalidCastException icex) {
        throw;
    } catch (DivideByZeroException dbzex) {
        throw;
    } catch (Exception ex) {
        throw;
    }
}