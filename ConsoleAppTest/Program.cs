using System.Linq.Expressions;

string[][] userEnteredValues = new string[][]
{
            new string[] { "1", "2", "3"},
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
};

string overallStatusMessage = "";

Workflow1(userEnteredValues);

if (overallStatusMessage == "operating procedure complete")
{
    Console.WriteLine("'Workflow1' completed successfully.");
}
else
{
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(overallStatusMessage);
}

static void Workflow1(string[][] userEnteredValues)
{
    string operationStatusMessage = "good";
    string processStatusMessage = "";

try {
    foreach (string[] userEntries in userEnteredValues)
    {
        Process1(userEntries);

        if (processStatusMessage == "process complete")
        {
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(processStatusMessage);
            Console.WriteLine();
            operationStatusMessage = processStatusMessage;
        }
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
    string processStatus = "clean";
    string returnMessage = "";
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

        if (processStatus == "clean")
        {
            returnMessage = "process complete";
        }
    } catch (InvalidCastException icex) {
        returnMessage = "Invalid data. User input values must be valid integers.";
    } catch (DivideByZeroException dbzex) {
        returnMessage = "Invalid data. User input values must be non-zero values.";
    } catch (Exception ex) {
        returnMessage = "An error occurred during 'Process1'.";
    }
}