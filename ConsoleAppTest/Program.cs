bool flag = false;
do {
    Console.WriteLine("Enter your role name (Administrator, Manager, or User)");
    string role = Console.ReadLine();

    switch (role)
    {
        case "Administrator":
            Console.WriteLine($"Your input value ({role}) has been accepted");
            flag = true;
            break;
        case "Manager":
            Console.WriteLine($"Your input value ({role}) has been accepted");
            flag = true;
            break;
        case "User":
            Console.WriteLine($"Your input value ({role}) has been accepted");
            flag = true;
            break;
        default:
            Console.WriteLine($"The role name that you entered, \"{role}\" is not valid. Enter your role name (Administrator, Manager, or User)");
            break;
    }
} while (!flag);

