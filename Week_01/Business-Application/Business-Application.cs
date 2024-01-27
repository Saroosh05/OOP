using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace Business_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializing arrays for storing data about officers, admins, complainants, and other entities.

            // all the police officers that can signin
            string[] officers = new string[500]; 
            officers[0] = "Rahim Ali";        
            officers[1] = "Farhan Shah";
            officers[2] = "Bilal Ahmad";

            // codes for the police officers
            string[] officerCodes = new string[500];  
            officerCodes[0] = "PC-123";                
            officerCodes[1] = "PC-456";
            officerCodes[2] = "PC-789";

            // designations of the police officers
            string[] designations = new string[500];  
            designations[0] = "Inspector";      
            designations[1] = "Inspector";
            designations[2] = "Inspector";

            // total number of officers
            int officerCount = 3;

            // Each index across these arrays corresponds to a single officer.                                                                        
            // For example, officers[0], officerCodes[0], and designations[0] all refer to the first officer's data.


            // there is only admin with this particular code and name
            string admin = "Asad Abbas";           // admin user name
            string adminCode = "DSP-59";          // admin code

            string[] names = new string[500];
            string[] passwords = new string[500];
            string[] roles = new string[500];         // contains all the user names, passwords and roles that are signed-up
            int countUser = 0;                       // total number of signed-up users

            string var1;
            string var2;
            string var3;


            // Arrays storing information of complaints
            string[] compNames = new string[500];
            string[] emails = new string[500];
            string[] contacts = new string[500];
            string[] address = new string[500];
            string[] cities = new string[500];
            string[] provinces = new string[500];
            string[] dates = new string[500];
            string[] details = new string[500];
            string[] subjects = new string[500];
            string[] codes = new string[500];
            string[] urgencyLevel = new string[500];

            // Each index across these arrays corresponds to a single complain.
            // For example, emails[0], contacts[0], and address[0], etc all refer to the first complaint's data.


            // Arrays containing complainant's data
            string[] complainants = new string[500];         // user names of complainants
            string[] compPasswords = new string[500];           // passwords of complainants
            int[] complaints = new int[500];             // number of filed complaints of each complainant
            int complainantCount = 0;       // total number of complainants
            //int k = 0;
            // Each index across these arrays corresponds to a single complainant.
            // For example, complainants[0], compPasswords[0], and complaints[0], etc all refer to the first complainant's data.


            // Arrays saving signed-up police officers
            string[] signedUpOff = new string[500];              // usernames of signed-up officers
            string[] signedUpOffPass = new string[500];         // passwords of signed-up officers
            string[] signedOffCodes = new string[500];         // codes of signed-up officers
            int signedoffCount = 0;                           // number of signed-up officers
                                                              // Each index across these arrays corresponds to a single signed-up officer.
                                                              // For example, signedUpOff[0], signedUpOffPass[0], and signedOffCodes[0], etc all refer to the first signed-up officer's data.


            // Arrays being used for assigning complaints to police officers
            string assignToCode = "";
            string[] assingedCompCodes = new string[500];       //codes of complaints being assigned
            string[] assignedOffCode = new string[500];        //codes of police officers who are assigned the complaints
            int assignCount = 0;
            // Correspondence exists between the index of these arrays.


            // Arrays being used for saving status of complaints
            string[] status = new string[500];             //status of complaints
            string[] codeStatus = new string[500];        //codes of complaints whose status is set
            int statusCount = 0;
            string compStatus = "Pending";
            // Correspondence exists between the index of these arrays.

            int complaintCount = 0;

            int[] numbersAsInteger = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] numberAsString = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Console.Clear(); // Clearing Screen
            string t = "AllUsers.txt";
            // Functions for loading the data from the files into the arrays
            loadSignedOfficers(signedUpOff, signedUpOffPass, signedOffCodes, ref signedoffCount, "SignedOfficers.txt");
            loadAllUsers(names, passwords, roles, ref countUser, t);
            loadComplainants(complainants, compPasswords, ref complainantCount, "ComplainantsSignUp.txt");
            loadAssignedComplainants(assingedCompCodes, assignedOffCode, ref assignCount, "AssignComplaints.txt");
            loadStatus(status, codeStatus, ref statusCount, "Status.txt");
            loadOfficers(officers, officerCodes, designations, ref officerCount, "Officers.txt");
            loadComplaintDetails(subjects, compNames, emails, contacts, address, cities, provinces, dates, urgencyLevel, details, codes, complaints, ref complaintCount, "ComplaintDetails.txt", numberAsString, numbersAsInteger);

            Console.ReadKey();
            // Main application loop
            while (true)
            {
                Console.Clear();       // Clearing the screen
                printHeader();        // Printing the main header
                printOath();         // Printing the oath of police officers
                lines();            // Printing lines for decoration
                printMenu();       // Displaying the main menu
                policeCar();      // Displaying a police car for decoration

                string option;
                Console.SetCursorPosition(70, 33);
                Console.Write("     Enter your option: ");
                option = Console.ReadLine();

                // invalid option   
                while (option != "1" && option != "2" && option != "3")
                {
                    Console.SetCursorPosition(73, 35);
                    Console.Write("Choose the correct option.");
                    Console.SetCursorPosition(70, 33);
                    Console.Write("     Enter your option:    ");
                    Console.SetCursorPosition(70, 33);
                    Console.Write("     Enter your option: ");
                    option = Console.ReadLine();
                }

                // Option 1: Sign In
                if (option == "1")
                {
                    Console.Clear();
                    printHeader();

                    Console.SetCursorPosition(23, 15);
                    Console.Write("Provide the following requirements to SIGN IN : ");
                    Console.SetCursorPosition(65, 20);
                    Console.Write("-------------------------------------------");
                    Console.SetCursorPosition(65, 26);
                    Console.Write("--------------------------------------------");

                    // Geting username and passworod as input from the user
                    string user, pass;
                    int x = 73, y = 22;
                    Console.SetCursorPosition(x, y);
                    Console.Write("User Name: ");

                    user = Console.ReadLine();

                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("Password: ");
                    pass = Console.ReadLine();

                    // signing in and returning role
                    string role = signIn(names, passwords, roles, user, pass, countUser);

                    // if role is not found, declaring the input invalid
                    if (role == "nill")
                    {
                        Console.SetCursorPosition(72, y + 7);
                        Console.Write("Invalid Username or Password");
                        Console.SetCursorPosition(72, y + 9);
                        Console.Write("Press any key to continue ... ");
                        Console.ReadKey();
                    }
                    else
                    {
                        // Complainant
                        if (role == "3")
                        {
                            // The compCompare function is used to check if complainant exists in the system.
                            int compIndex;
                            int comparison = compCompare(user, pass, complainants, compPasswords, complainantCount);

                            if (comparison == -1)
                            {
                                // if complainant has signed in for the first time, putting everything equal to nill
                                complaintCount = 0;
                                compIndex = complainantCount;

                                compNames[compIndex] = "";
                                emails[compIndex] = "";
                                contacts[compIndex] = "";
                                address[compIndex] = "";
                                cities[compIndex] = "";
                                provinces[compIndex] = "";
                                dates[compIndex] = "";
                                subjects[compIndex] = "";
                                urgencyLevel[compIndex] = "";
                                details[compIndex] = "";
                            }
                            else
                            {
                                //storing the index of the complainant if exists
                                compIndex = comparison;
                            }

                            string requirement = "";
                            string task = "";
                            complainant();
                            compMenu(20, 11);
                            Console.SetCursorPosition(57, 30);
                            Console.Write("Enter your required option from the above main menu: ");
                            requirement = Console.ReadLine();

                            while (requirement != "1" && requirement != "2" && requirement != "3" && requirement != "4")
                            {
                                Console.SetCursorPosition(57, 32);
                                Console.Write("         Choose the Correct Option ");
                                Console.SetCursorPosition(57, 30);
                                Console.Write("Enter your required option from the above main menu:              ");
                                Console.SetCursorPosition(57, 30);
                                Console.Write("Enter your required option from the above main menu: ");
                                requirement = Console.ReadLine();

                                Console.SetCursorPosition(57, 32);
                                Console.Write("                                                       ");
                            }

                            Console.Clear();
                            while (true)
                            {
                                compMenu(21, 2);

                                // printing the user guidance page
                                if (requirement == "1")
                                {
                                    guidance();
                                }
                                //printing the complaints' details to the complainant
                                else if (requirement == "2")
                                {
                                    // checking  if complainant has filed any complaints or not

                                    
                                    if (codes[compIndex] == null || codes[compIndex] == "")
                                    {
                                        Console.SetCursorPosition(76, 22);
                                        Console.Write("SORRY! NO RECORD FOUND.");
                                    }
                                    else
                                    {
                                        // listing all the complaints filed by the complainant
                                        int loopVar = 0;
                                        Console.SetCursorPosition(60, 11);
                                        Console.Write("Here is the list of complaints you have filed till now.");

                                        int o = 22;
                                        int p = 15;
                                        // The complaintsList function is used to display a list of all complaints filed by the complainant.
                                        string FurtherOpen = complaintsList(codes, subjects, dates, urgencyLevel, complaintCount, compIndex, ref loopVar, o, p);
                                        if (FurtherOpen != "0")
                                        {
                                            // The codeCompare function finds the index of the specific complaint on the basis of the provided code.
                                            int codeIndex = codeCompare(FurtherOpen, codes, compIndex);
                                            if (codeIndex != -1)
                                            {
                                                // printing the complaint details 
                                                Console.Clear();
                                                compMenu(21, 2);
                                                Console.SetCursorPosition(25, 9);
                                                Console.Write("YOUR COMPLAINT DETAILS: ");

                                                //displaying the general details of a specific complaint.
                                                int m = 30, n = 11;
                                                generalDetails(codes, subjects, dates, urgencyLevel, codeIndex, compIndex, m, n);
                                                Console.SetCursorPosition(25, 18);
                                                Console.Write("Personal Information: ");

                                                //displaying the personal information and incident details of a specific complaint.
                                                int X = 22, Y = 20;
                                                personalDetails(subjects, compNames, emails, contacts, address, cities, provinces, details, codes, codeIndex, compIndex, X, Y);
                                                string tasks = historyMenu(task); // displaying the history menu

                                                // Validation
                                                while (tasks != "1" && tasks != "2" && tasks != "3")
                                                {
                                                    Console.SetCursorPosition(43, 42);
                                                    Console.Write("                             Invalid Option");
                                                    Console.SetCursorPosition(43, 40);
                                                    Console.Write("                        Enter the required option:      ");
                                                    Console.SetCursorPosition(43, 40);
                                                    Console.Write("                        Enter the required option: ");
                                                    tasks = Console.ReadLine();
                                                }
                                                Console.SetCursorPosition(43, 42);
                                                Console.Write("                                                         ");

                                                // 1 : Delete (deleting complaint)
                                                if (tasks == "1")
                                                {
                                                    string[] newString = new string[500];
                                                    string deletedCode = compareIndex(codes[compIndex], newString, codeIndex);

                                                    deleteComplaint(subjects, codeIndex, compIndex);
                                                    deleteComplaint(compNames, codeIndex, compIndex);
                                                    deleteComplaint(emails, codeIndex, compIndex);
                                                    deleteComplaint(contacts, codeIndex, compIndex);
                                                    deleteComplaint(address, codeIndex, compIndex);
                                                    deleteComplaint(cities, codeIndex, compIndex);
                                                    deleteComplaint(provinces, codeIndex, compIndex);
                                                    deleteComplaint(details, codeIndex, compIndex);
                                                    deleteComplaint(codes, codeIndex, compIndex);
                                                    deleteComplaint(urgencyLevel, codeIndex, compIndex);
                                                    deleteComplaint(dates, codeIndex, compIndex);

                                                    complaintCount--;
                                                    codeIndex--;
                                                    complaints[compIndex] = complaintCount;

                                                    codeStatus[compIndex] = "";
                                                    status[compIndex] = "";
                                                    statusCount--;

                                                    int indexForAssigned = findIndex(deletedCode, assingedCompCodes, assignCount);
                                                    if (indexForAssigned != -1)
                                                    {
                                                        assignedOffCode[indexForAssigned] = "";
                                                        assingedCompCodes[indexForAssigned] = "";
                                                        assignCount--;
                                                    }

                                                    // Storing Assigned Complaints Detail in the file.
                                                    storeAssignedComplainants(assingedCompCodes, assignedOffCode, ref assignCount, "AssignComplaints.txt");

                                                    // Storing Status of the Complaints in the file.
                                                    storeStatus(status, codeStatus, ref statusCount, "Status.txt");

                                                    // Storing Complaint Detail in the file.
                                                    storeComplaintDetails(subjects, compNames, emails, contacts, address, cities, provinces, dates, urgencyLevel, details, codes, complaints, ref compIndex, "ComplaintDetails.txt");

                                                    Console.SetCursorPosition(43, 42);
                                                    Console.Write("                        Record Deleted Successfully.");
                                                }
                                                // 2: Check Status (displaying the status of the complaint)
                                                else if (tasks == "2")
                                                {
                                                    string[] newString = new string[500];
                                                    //The compareIndex function extracts and returns a code from a string on the basis of the given index.
                                                    string currentCode = compareIndex(codes[compIndex], newString, codeIndex);
                                                    if (currentCode != "nill")
                                                    {
                                                        // findIndex function finds the index of a specific string in an array.
                                                        int indexForStatus = findIndex(currentCode, codeStatus, statusCount);
                                                        
                                                        if (status != null && indexForStatus >= 0 && indexForStatus < status.Length && status[indexForStatus] != null)
                                                        {
                                                            if (status[indexForStatus] != "")
                                                            {
                                                                compStatus = status[indexForStatus];
                                                            }
                                                        }
                                                    }

                                                    Console.SetCursorPosition(43, 42);
                                                    Console.Write("                        STATUS : " + compStatus);
                                                }
                                            }
                                            else if (task == "3")
                                            {
                                                Console.SetCursorPosition(74, y + 3 + loopVar + 14);
                                                Console.Write("Code Not Matched.");
                                            }
                                        }
                                    }
                                }
                                else if (requirement == "3")
                                {
                                    // filing a new complaint
                                    complaint(subjects, compNames, emails, contacts, address, cities, provinces, dates, urgencyLevel, details, codes, compIndex, codeStatus, status, statusCount);
                                    complaints[compIndex] = complaintCount;

                                    // Storing data in the file
                                    storeComplaintDetails(subjects, compNames, emails, contacts, address, cities, provinces, dates, urgencyLevel, details, codes, complaints, ref compIndex, "ComplaintDetails.txt");
                                    complaintCount++;
                                    statusCount++;
                                }
                                else if (requirement == "4")
                                {
                                    break;
                                }

                                Console.SetCursorPosition(60, 45);
                                Console.Write("Enter your required option from the above menu: ");
                                requirement = Console.ReadLine();

                                while (requirement != "1" && requirement != "2" && requirement != "3" && requirement != "4")
                                {
                                    Console.SetCursorPosition(60, 46);
                                    Console.Write("         Choose the Correct Option ");
                                    Console.SetCursorPosition(60, 45);
                                    Console.Write("Enter your required option from the above menu:         ");
                                    Console.SetCursorPosition(60, 45);
                                    Console.Write("Enter your required option from the above menu: ");
                                    requirement = Console.ReadLine();

                                    Console.SetCursorPosition(60, 46);
                                    Console.Write("                                                       ");
                                }

                                Console.Clear();

                            }
                        }
                        // Role 2 : police officer
                        else if (role == "2")
                        {

                            Console.Clear();
                            printHeader();
                            officerMenu(29, 11);

                            Console.SetCursorPosition(25, 20);
                            Console.Write("Welcome Inspector " + user + ".");

                            //string task = "";
                            string requirement = "";
                            Console.SetCursorPosition(61, 25);
                            Console.Write("Enter your required option from the above menu: ");
                            requirement = Console.ReadLine();

                            while (requirement != "1" && requirement != "2" && requirement != "3")
                            {
                                Console.SetCursorPosition(61, 27);
                                Console.Write("         Choose the Correct Option ");
                                Console.SetCursorPosition(61, 25);
                                Console.Write("Enter your required option from the above menu:              ");
                                Console.SetCursorPosition(61, 25);
                                Console.Write("Enter your required option from the above menu: ");
                                requirement = Console.ReadLine();

                                Console.SetCursorPosition(61, 27);
                                Console.Write("                                                       ");
                            }

                            while (true)
                            {
                                // showing assigned complaints
                                if (requirement == "1")
                                {
                                    Console.Clear();
                                    printHeader();
                                    officerMenu(29, 11);

                                    // findIndex function finds the index of a specific string in an array.
                                    int indexForOFFCode = findIndex(user, officers, officerCount);
                                    string OFFCode = officerCodes[indexForOFFCode];

                                    int[] officersIndexes = new int[500];

                                    // Finding all the indexes of the complaints that have been assigned.
                                    int numberOfIndexes = findAllIndexes(OFFCode, assignedOffCode, assignCount, officersIndexes);

                                    if (numberOfIndexes == -1)
                                    {
                                        Console.SetCursorPosition(60, 25);
                                        Console.Write("You are not assigned any complaint yet.");
                                    }
                                    else
                                    {

                                        Console.SetCursorPosition(60, 15);
                                        Console.Write("Following are the complaints that you are assigned :");

                                        string codeOfComp = "";
                                        int complainantIndex = 0;
                                        int indexInBTW;
                                        int loopVar = 0;
                                        int endingY = 0;
                                        int j = 0;
                                        int serial = 0;

                                        //Listing all the assigned complaints
                                        complaintsListForAssign_Header();

                                        for (int z = 0; z < numberOfIndexes; z++)
                                        {
                                            codeOfComp = assingedCompCodes[officersIndexes[z]];

                                            for (int i = 0; i < complainantCount; i++)
                                            {
                                                string[] newString = new string[500];

                                                // The codeCompare function finds the index of the specific complaint on the basis of the provided code.
                                                indexInBTW = codeCompare(codeOfComp, codes, i);
                                                Console.WriteLine();
                                                if (indexInBTW != -1)
                                                {
                                                    complainantIndex = i;

                                                    string AssignedList = complaintsListForAssign(codes, subjects, dates, urgencyLevel, indexInBTW, complainantIndex, numberOfIndexes, ref loopVar, 22, 19 + z, j, ref serial);
                                                    endingY = 19 + z;

                                                    break;
                                                }
                                            }
                                        }

                                        // Diplaying deatils of an assigned complaint
                                        string detailsForAssign = openingCodeForCompDetail(loopVar, 22, endingY);

                                        if (detailsForAssign != "0")
                                        {
                                            // The codeCompare function finds the index of the specific complaint on the basis of the provided code.
                                            int codeIndex = codeCompare(detailsForAssign, codes, complainantIndex);
                                            if (codeIndex != -1)
                                            {
                                                Console.Clear();
                                                printHeader();
                                                officerMenu(29, 10);
                                                Console.SetCursorPosition(25, 15);
                                                Console.Write("COMPLAINT DETAILS: ");

                                                int m = 30, n = 17;
                                                // Displaying General Details of an assigned complaint
                                                generalDetails(codes, subjects, dates, urgencyLevel, codeIndex, complainantIndex, m, n);
                                                Console.SetCursorPosition(25, 23);
                                                Console.Write("Personal Information: ");

                                                int X = 23, Y = 25;
                                                // Displaying personal details of the assigned complaint
                                                personalDetails(subjects, compNames, emails, contacts, address, cities, provinces, details, codes, codeIndex, complainantIndex, X, Y);

                                                // Asking Officer for the change in status
                                                string yes;
                                                Console.SetCursorPosition(41, 39);
                                                Console.Write("Change Status of the Complaint (Yes or No): ");
                                                yes = Console.ReadLine();

                                                if (yes == "Yes" || yes == "yes")
                                                {
                                                    Console.Clear();
                                                    printHeader();
                                                    officerMenu(29, 11);

                                                    string[] newString = new string[500];
                                                    //The compareIndex function extracts and returns a code from a string on the basis of the given index.
                                                    string codeForStatus = compareIndex(codes[complainantIndex], newString, codeIndex);

                                                    // findIndex function finds the index of a specific string in an array.
                                                    int indexForStatus = findIndex(codeForStatus, codeStatus, statusCount);

                                                    // Displaying options which can be set as status of the complaint
                                                    string statusAdmin = statusAdminOptions(codeForStatus);

                                                    if (statusAdmin != "nill")
                                                    {
                                                        if (statusAdmin == "1")
                                                        {
                                                            status[indexForStatus] = "Pending";
                                                        }
                                                        else if (statusAdmin == "2")
                                                        {
                                                            status[indexForStatus] = "Invalid";
                                                        }
                                                        else if (statusAdmin == "3")
                                                        {
                                                            status[indexForStatus] = "Under Process";
                                                        }
                                                        else if (statusAdmin == "4")
                                                        {
                                                            status[indexForStatus] = "Accomplished";
                                                        }

                                                        Console.SetCursorPosition(41, 29);
                                                        Console.Write("The status of the complaint under code " + codeForStatus + " is set as " + status[indexForStatus] + ".");
                                                        storeStatus(status, codeStatus, ref statusCount, "Status.txt");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                // displaying the information of current officer
                                else if (requirement == "2")
                                {
                                    Console.Clear();
                                    printHeader();
                                    officerMenu(29, 11);
                                    me(user, officers, officerCodes, designations, officerCount);
                                }
                                else
                                {
                                    break;
                                }
                                Console.SetCursorPosition(60, 41);
                                Console.Write("Enter your required option from the above main menu: ");
                                requirement = Console.ReadLine();

                                while (requirement != "1" && requirement != "2" && requirement != "3")
                                {
                                    Console.SetCursorPosition(60, 43);
                                    Console.Write("         Choose the Correct Option ");
                                    Console.SetCursorPosition(60, 41);
                                    Console.Write("Enter your required option from the above menu:         ");
                                    Console.SetCursorPosition(60, 41);
                                    Console.Write("Enter your required option from the above menu: ");
                                    requirement = Console.ReadLine();

                                    Console.SetCursorPosition(60, 43);
                                    Console.Write("                                                       ");
                                }

                                Console.Clear();
                            }
                        }
                        //Role 1: Adminstrator
                        else if (role == "1")
                        {
                            Console.Clear();     // clearing screen
                            printHeader();      // printing the header
                            adminMenu(29, 11); // printing the admin menu


                            Console.SetCursorPosition(25, 20);
                            Console.Write("Welcome Sir!");

                            //Asking the user requirement
                            string task = "";
                            string requirement = "";
                            Console.SetCursorPosition(61, 25);
                            Console.Write("Enter your required option from the above menu: ");
                            requirement = Console.ReadLine();

                            // Validation
                            while (requirement != "1" && requirement != "2" && requirement != "3")
                            {
                                Console.SetCursorPosition(61, 27);
                                Console.Write("         Choose the Correct Option ");
                                Console.SetCursorPosition(61, 25);
                                Console.Write("Enter your required option from the above menu:              ");
                                Console.SetCursorPosition(61, 25);
                                Console.Write("Enter your required option from the above menu: ");
                                requirement = Console.ReadLine();

                                Console.SetCursorPosition(61, 27);
                                Console.Write("                                                       ");
                            }

                            while (true)
                            {
                                // 1: details and functionality about the complainants
                                if (requirement == "1")
                                {
                                    Console.Clear();
                                    printHeader();
                                    adminMenu(29, 11);
                                    //Console.WriteLine(complainantCount);

                                    if (complainantCount == 0)
                                    {
                                        Console.SetCursorPosition(79, 26);
                                        Console.Write("NO RECORD FOUND");
                                    }
                                    else
                                    {
                                        int loopVar = 0;

                                        Console.SetCursorPosition(29, 18);
                                        Console.Write("Here is the list of all the complainants that have signed up till now :");

                                        // displaying the list of all the complainants
                                        string NextToComps = complainantsAdmin(complainants, compPasswords, complainantCount);

                                        if (NextToComps != "0")
                                        {
                                            int index = 0;
                                            // checkForOff checks whether a string exists in an array or not
                                            bool existPass = checkForOff(NextToComps, compPasswords, complainantCount, ref index);
                                            if (!existPass)
                                            {
                                                Console.Clear();
                                                printHeader();
                                                adminMenu(29, 12);
                                                if (codes[index] == "" || codes[index] == null)
                                                {
                                                    Console.SetCursorPosition(51, 24);
                                                    Console.Write("No complaints have been filed yet by the complainant " + complainants[index]);
                                                }
                                                else
                                                {
                                                    Console.SetCursorPosition(29, 16);
                                                    Console.Write("Here is the list of complaints " + complainants[index] + " have filed till now.");

                                                    int m = 22, n = 19;
                                                    // listisng all the complaints of a complainant
                                                    string FurtherOpen = complaintsList(codes, subjects, dates, urgencyLevel, complaintCount, index, ref loopVar, m, n);

                                                    if (FurtherOpen != "0")
                                                    {
                                                        int codeIndex = codeCompare(FurtherOpen, codes, index);
                                                        if (codeIndex != -1)
                                                        {
                                                            // displaying the complaints details
                                                            Console.Clear();
                                                            printHeader();
                                                            adminMenu(29, 10);
                                                            Console.SetCursorPosition(25, 15);
                                                            Console.Write("COMPLAINT DETAILS: ");

                                                            int i = 30, j = 17;
                                                            generalDetails(codes, subjects, dates, urgencyLevel, codeIndex, index, i, j);
                                                            Console.SetCursorPosition(25, 23);
                                                            Console.Write("Personal Information: ");

                                                            int X = 23, Y = 25;
                                                            // displaying personal information
                                                            personalDetails(subjects, compNames, emails, contacts, address, cities, provinces, details, codes, codeIndex, index, X, Y);
                                                            string tasks = historyAdminMenu(task);

                                                            string[] newString = new string[500];
                                                            string requiredCode = compareIndex(codes[index], newString, codeIndex);

                                                            // Validation
                                                            while (tasks != "1" && tasks != "2" && tasks != "3" && tasks != "4" && tasks != "5")
                                                            {
                                                                Console.SetCursorPosition(37, 43);
                                                                Console.Write("                             Invalid Option");
                                                                Console.SetCursorPosition(37, 41);
                                                                Console.Write("                        Enter the required option:      ");
                                                                Console.SetCursorPosition(37, 41);
                                                                Console.Write("                        Enter the required option: ");
                                                                tasks = Console.ReadLine();
                                                            }
                                                            Console.SetCursorPosition(37, 43);
                                                            Console.Write("                                                         ");

                                                            // 1 : deleting the complaint
                                                            if (tasks == "1")
                                                            {
                                                                string[] NewString = new string[500];
                                                                string deletedCode = compareIndex(codes[index], NewString, codeIndex);

                                                                deleteComplaint(subjects, codeIndex, index);
                                                                deleteComplaint(compNames, codeIndex, index);
                                                                deleteComplaint(emails, codeIndex, index);
                                                                deleteComplaint(contacts, codeIndex, index);
                                                                deleteComplaint(address, codeIndex, index);
                                                                deleteComplaint(cities, codeIndex, index);
                                                                deleteComplaint(provinces, codeIndex, index);
                                                                deleteComplaint(details, codeIndex, index);
                                                                deleteComplaint(codes, codeIndex, index);
                                                                deleteComplaint(urgencyLevel, codeIndex, index);
                                                                deleteComplaint(dates, codeIndex, index);

                                                                int indexForAssigned = findIndex(deletedCode, assingedCompCodes, assignCount);
                                                                if (indexForAssigned != -1)
                                                                {
                                                                    assignedOffCode[indexForAssigned] = "";
                                                                    assingedCompCodes[indexForAssigned] = "";
                                                                    assignCount--;
                                                                }

                                                                // Storing Assinged Complainants data in the file.
                                                                storeAssignedComplainants(assingedCompCodes, assignedOffCode, ref assignCount, "AssignComplaints.txt");

                                                                complaintCount--;
                                                                codeIndex--;
                                                                complaints[index] = complaintCount;

                                                                // Storing Complaint Details in the file.
                                                                storeComplaintDetails(subjects, compNames, emails, contacts, address, cities, provinces, dates, urgencyLevel, details, codes, complaints, ref index, "ComplaintDetails.txt");

                                                                Console.SetCursorPosition(37, 43);
                                                                Console.Write("                             Record Deleted Successfully.");
                                                            }
                                                            // 2 : editing the complaints
                                                            else if (tasks == "2")
                                                            {
                                                                Console.Clear();
                                                                printHeader();
                                                                adminMenu(29, 10);

                                                                // displaying the edit menu
                                                                string editNum = editMenu();

                                                                string[] mainArr = new string[500];
                                                                string editedString = "";

                                                                // finding the string to edit
                                                                string mainString = findMainString(editNum, dates, urgencyLevel, subjects, compNames, emails, contacts, address, cities, provinces, details, codes, codeIndex, index, complaintCount, mainArr, ref editedString);
                                                                int position = editComplaint(mainArr, codeIndex, index);

                                                                string miniString;
                                                                if (editNum == "10")
                                                                {
                                                                    // editing the urgency level
                                                                    Console.SetCursorPosition(54, 34);
                                                                    Console.Write("------------------------------------------------------------------------");
                                                                    Console.SetCursorPosition(54, 35);
                                                                    Console.Write("|             1. High           2. Normal           3. Low             |");
                                                                    Console.SetCursorPosition(54, 36);
                                                                    Console.Write("------------------------------------------------------------------------");

                                                                    Console.SetCursorPosition(25, 38);
                                                                    Console.Write("Replace the " + editedString + " '" + mainString + "' with: ");
                                                                    Console.SetCursorPosition(60, 39);

                                                                    miniString = Console.ReadLine();
                                                                }
                                                                else
                                                                {
                                                                    Console.SetCursorPosition(25, 34);
                                                                    Console.Write("Replace the " + editedString + " '" + mainString + "' with: ");
                                                                    Console.SetCursorPosition(55, 35);

                                                                    miniString = Console.ReadLine();
                                                                }

                                                                StringBuilder mainA = new StringBuilder(mainArr[index]);
                                                                mainA.Insert(position, miniString);

                                                                mainArr[index] = mainA.ToString();
                                                                

                                                                // storing the edited things to the main array
                                                                storeInMain(editedString, mainArr, dates, urgencyLevel, subjects, compNames, emails, contacts, address, cities, provinces, details, codes, index);

                                                                // storing this data in the file
                                                                storeComplaintDetails(subjects, compNames, emails, contacts, address, cities, provinces, dates, urgencyLevel, details, codes, complaints, ref index, "ComplaintDetails.txt");
                                                            }   
                                                            // 3: status
                                                            else if (tasks == "3")
                                                            {
                                                                // changing or updating the status of the complaint
                                                                Console.Clear();
                                                                printHeader();
                                                                adminMenu(29, 10);

                                                                // findIndex function finds the index of a specific string in an array.
                                                                int indexForStatus = findIndex(requiredCode, codeStatus, statusCount);

                                                                // geting the status of complaint on the basis of the code (requiredCode)
                                                                string statusAdmin = statusAdminOptions(requiredCode);

                                                                
                                                                
                                                                if (statusAdmin != "nill")
                                                                {
                                                                    
                                                                    if (statusAdmin == "1")
                                                                    {
                                                                        status[indexForStatus] = "Pending";
                                                                    }
                                                                    else if (statusAdmin == "2")
                                                                    {
                                                                        status[indexForStatus] = "Invalid";
                                                                    }
                                                                    else if (statusAdmin == "3")
                                                                    {
                                                                        status[indexForStatus] = "Under Process";
                                                                    }
                                                                    else if (statusAdmin == "4")
                                                                    {
                                                                        status[indexForStatus] = "Accomplished";
                                                                    }

                                                                    
                                                                    Console.SetCursorPosition(41, 29);
                                                                    Console.Write("The status of the complaint under code " + requiredCode + " is set as " + status[indexForStatus] + ".");

                                                                    // Storing Status of Complaint in the file.
                                                                    storeStatus(status, codeStatus, ref statusCount, "Status.txt");
                                                                }
                                                                else
                                                                {
                                                                    Console.SetCursorPosition(41, 29);
                                                                    Console.Write("Kindly, give correct option.");
                                                                }
                                                                
                                                            }
                                                            // 4 : Assigning complaints to police officers
                                                            else if (tasks == "4")
                                                            {
                                                                // findIndex function finds the index of a specific string in an array.
                                                                int alreadyAssigned = findIndex(requiredCode, assingedCompCodes, assignCount);
                                                                if (alreadyAssigned != -1)
                                                                {
                                                                    Console.SetCursorPosition(37, 43);
                                                                    Console.Write("                             Complaint is already Assigned.");
                                                                }
                                                                else
                                                                {

                                                                    Console.Clear();
                                                                    printHeader();
                                                                    adminMenu(29, 10);

                                                                    Console.SetCursorPosition(29, 18);
                                                                    Console.Write("List of the officers that have signed up :");
                                                                    // listing the officers who have signed up as they can only be assigned the complaints
                                                                    int length = signedOfficersList(signedUpOff, officers, officerCodes, designations, signedoffCount, officerCount, 41, 20);

                                                                    if (signedoffCount != 0)
                                                                    {
                                                                        Console.SetCursorPosition(41, 27 + length);
                                                                        // geting the officer code who is assigned the complaint
                                                                        Console.Write("Assign the complaint to the officer with CODE : ");
                                                                        assignToCode = Console.ReadLine();

                                                                        // finding the index of code if it exixts in the array
                                                                        int codeInd = findIndex(assignToCode, signedOffCodes, signedoffCount);

                                                                        if (codeInd == -1)
                                                                        {
                                                                            Console.SetCursorPosition(80, 31 + length);
                                                                            Console.Write("NO CODE MATCHED");
                                                                        }
                                                                        else
                                                                        {
                                                                            // storing this data in arrays
                                                                            assingedCompCodes[assignCount] = requiredCode;
                                                                            assignedOffCode[assignCount] = assignToCode;

                                                                            // storing this data in file
                                                                            storeAssignedComplainants(assingedCompCodes, assignedOffCode, ref assignCount, "AssignComplaints.txt");
                                                                            assignCount++;

                                                                            Console.SetCursorPosition(41, 29 + length);

                                                                            Console.Write("The complaint under the code " + requiredCode + " is assigned to the " + designations[codeInd] + " " + officers[codeInd] + " with code " + assignToCode + ".");
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // incorrect code
                                                            Console.SetCursorPosition(73, y + 3 + loopVar + 14);
                                                            Console.Write("Code Not Matched.");
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // incorrect password
                                                Console.SetCursorPosition(73, y + 3 + loopVar + 14);
                                                Console.Write("No Password Matched");
                                            }
                                        }
                                    }
                                }
                                // 2 : Police Officer
                                else if (requirement == "2")
                                {
                                    Console.Clear();
                                    printHeader();
                                    adminMenu(29, 10);

                                    string codeToView;
                                    int length1;

                                    Console.SetCursorPosition(29, 16);
                                    Console.Write("List of all the officer :");

                                    // if no officer has signed up
                                    if (officerCount == 0)
                                    {
                                        Console.SetCursorPosition(69, 18);
                                        Console.Write("No Officer has signed up yet.");
                                        length1 = 0;
                                    }
                                    else
                                    {
                                        // displaying the list of all the officers in the system
                                        length1 = officersList(officers, officerCodes, designations, officerCount, 41, 18);
                                    }

                                    Console.SetCursorPosition(29, 24 + length1);
                                    // displaying the list of officers who have signed up
                                    Console.Write("List of the officers that have signed up :");
                                    int length2 = signedOfficersList(signedUpOff, officers, officerCodes, designations, signedoffCount, officerCount, 41, 26 + length1);

                                    // displaying the menu and get the option from the users
                                    string Option = functionsForOff(41, 31 + length1 + length2);

                                    // if option is not nill
                                    if (Option != "nill")
                                    {
                                        // 1 : viewing assinged complaints to police officers
                                        if (Option == "1")
                                        {
                                            if (length2 != 0)
                                            {
                                                Console.SetCursorPosition(41, 36 + length1 + length2);
                                                Console.Write("Enter the code of the police officer of which you want to view the assigned complaints: ");
                                                codeToView = Console.ReadLine();

                                                // finding the index of police officer through code
                                                int IfExist = findIndex(codeToView, signedOffCodes, signedoffCount);

                                                if (IfExist == -1)
                                                {
                                                    // officer code does not exist
                                                    Console.SetCursorPosition(79, 38 + length1 + length2);
                                                    Console.Write("Code Not Matched");
                                                }
                                                else
                                                {
                                                    int[] officersIndexes = new int[500];

                                                    int numberOfIndexes = findAllIndexes(codeToView, assignedOffCode, assignCount, officersIndexes);

                                                    if (numberOfIndexes == -1)
                                                    {
                                                        Console.SetCursorPosition(77, 38 + length1 + length2);
                                                        Console.Write("Not Assigned Any Complaint");
                                                    }
                                                    else
                                                    {

                                                        Console.Clear();
                                                        printHeader();
                                                        adminMenu(29, 10);

                                                        // get all the complaints code index and list them 
                                                        string codeOfComp = "";
                                                        int complainantIndex = 0;
                                                        int indexInBTW = 0;
                                                        int loopVar = 0;
                                                        int endingY = 0;
                                                        int j = 0;
                                                        int serial = 0;

                                                        complaintsListForAssign_Header();

                                                        for (int z = 0; z < numberOfIndexes; z++)
                                                        {
                                                            codeOfComp = assingedCompCodes[officersIndexes[z]];

                                                            for (int i = 0; i < complainantCount; i++)
                                                            {
                                                                string[] newString = new string[500];
                                                                

                                                                // get the index of the complain code   
                                                                indexInBTW = codeCompare(codeOfComp, codes, i);

                                                                //Console.WriteLine(indexInBTW);
                                                                
                                                                
                                                                if (indexInBTW != -1)
                                                                {
                                                                    
                                                                    // complain code not exists 

                                                                    complainantIndex = i;

                                                                    // display a list of complaints
                                                                    string AssignedList = complaintsListForAssign(codes, subjects, dates, urgencyLevel, indexInBTW, complainantIndex, numberOfIndexes, ref loopVar, 22, 19 + z, j, ref serial);

                                                                    endingY = 19 + z;

                                                                    break;
                                                                }
                                                            }
                                                        }

                                                        // Diplaying details of the assigned complaint
                                                        string detailsForAssign = openingCodeForCompDetail(loopVar, 22, endingY);

                                                        if (detailsForAssign != "0")
                                                        {
                                                            // The codeCompare function finds the index of the specific complaint on the basis of the provided code.
                                                            int codeIndex = codeCompare(detailsForAssign, codes, complainantIndex);
                                                            if (codeIndex != -1)
                                                            {
                                                                Console.Clear();
                                                                printHeader();
                                                                adminMenu(29, 10);
                                                                Console.SetCursorPosition(25, 15);
                                                                Console.Write("COMPLAINT DETAILS: ");

                                                                // Displaying General Details of an assigned complaint
                                                                int i = 30, l = 17;
                                                                generalDetails(codes, subjects, dates, urgencyLevel, codeIndex, complainantIndex, i, l);
                                                                Console.SetCursorPosition(25, 23);
                                                                Console.Write("Personal Information: ");

                                                                // Displaying personal details of the assigned complaint
                                                                int X = 23, Y = 25;
                                                                personalDetails(subjects, compNames, emails, contacts, address, cities, provinces, details, codes, codeIndex, complainantIndex, X, Y);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(65, 35 + length1 + length2);
                                                Console.Write("No officer is assigned any complaint yet.");
                                            }
                                        }
                                        // 2 : adding new police officer
                                        else if (Option == "2")
                                        {
                                            Console.Clear();
                                            printHeader();
                                            adminMenu(29, 10);

                                            // declaring variables to get information about the police officer
                                            string name, designation, code;

                                            // geting the input
                                            int o = 35, p = 20;
                                            Console.SetCursorPosition(o, p);
                                            Console.Write("In order to ADD new Police Officer, provide the following credentials: ");

                                            Console.SetCursorPosition(o + 23, p + 3);
                                            Console.Write("----------------------------------------------------------");
                                            Console.SetCursorPosition(o + 23, p + 5);
                                            Console.Write("      Police Officer's Name: ");

                                            name = Console.ReadLine();
                                            Console.SetCursorPosition(o + 23, p + 7);
                                            Console.Write("      Police Officer's Designation: ");
                                            designation = Console.ReadLine();
                                            Console.SetCursorPosition(o + 23, p + 9);
                                            Console.Write("      Police Offcier's Code: ");
                                            code = Console.ReadLine();

                                            Console.SetCursorPosition(o + 23, p + 11);
                                            Console.Write("----------------------------------------------------------");

                                            int checkingExistance = findIndex(code, officerCodes, officerCount);
                                            if (checkingExistance != -1)
                                            {
                                                Console.SetCursorPosition(o + 23, p + 14);
                                                Console.Write("          This code exists Already. ");
                                            }
                                            else
                                            {
                                            
                                                // storing the above information in arrays
                                                officers[officerCount] = name;
                                                designations[officerCount] = designation;
                                                officerCodes[officerCount] = code;
                                                officerCount++;

                                                // storing the above information in file
                                                storeOfficers(officers, officerCodes, designations, ref officerCount, "Officers.txt");



                                                Console.SetCursorPosition(o + 23, p + 14);
                                                Console.Write("                 Successfully Added.");
                                            }
                                        }
                                        // 3: delete police officers code
                                        else if (Option == "3")
                                        {
                                            Console.Clear();
                                            printHeader();
                                            adminMenu(29, 10);

                                            string code;

                                            //getting  input of police officer code to delete 
                                            int i = 35, j = 20;
                                            Console.SetCursorPosition(i, j);
                                            Console.Write("Write the code of the Police Officer which you want to delete : ");

                                            Console.SetCursorPosition(i + 23, j + 3);
                                            Console.Write("----------------------------------------------------------");
                                            Console.SetCursorPosition(i + 23, j + 5);
                                            Console.Write("            Police Offcier's Code: ");

                                            code = Console.ReadLine();
                                            Console.SetCursorPosition(i + 23, j + 7);
                                            Console.Write("----------------------------------------------------------");

                                            // finding index by code
                                            int findOfficerIndex = findIndex(code, officerCodes, officerCount);
                                            int findSignedOfficerIndex = findIndex(code, signedOffCodes, signedoffCount);
                                            if (findOfficerIndex != -1 && code != "PC-123" && code != "PC-456" && code != "PC-789")
                                            {
                                                // removing the officer
                                                for (int z = findOfficerIndex; z < officerCount; z++)
                                                {
                                                    if (z == officerCount - 1)
                                                    {
                                                        officers[z] = "";
                                                        officerCodes[z] = "";
                                                        designations[z] = "";
                                                    }
                                                    else
                                                    {
                                                        officers[z] = officers[z + 1];
                                                        officerCodes[z] = officerCodes[z + 1];
                                                        designations[z] = designations[z + 1];
                                                    }
                                                }

                                                officerCount--;
                                                storeOfficers(officers, officerCodes, designations, ref officerCount, "Officers.txt");


                                                if (findSignedOfficerIndex != -1)
                                                {
                                                    // removing the officer 1
                                                    for (int z = findSignedOfficerIndex; z < signedoffCount; z++)
                                                    {
                                                        if (z == signedoffCount - 1)
                                                        {
                                                            signedUpOff[z] = "";
                                                            signedOffCodes[z] = "";
                                                            signedUpOffPass[z] = "";
                                                        }
                                                        else
                                                        {
                                                            signedUpOff[z] = signedUpOff[z + 1];
                                                            signedOffCodes[z] = signedOffCodes[z + 1];
                                                            signedUpOffPass[z] = signedUpOffPass[z + 1];
                                                        }
                                                    }

                                                    storeSignedOfficers(signedUpOff, signedUpOffPass, signedOffCodes, ref signedoffCount, "SignedOfficers.txt");
                                                    signedoffCount--;
                                                }

                                                Console.SetCursorPosition(i + 23, j + 9);
                                                Console.Write("                  Record Deleted");
                                            }
                                            else if (findOfficerIndex == -1)
                                            {
                                                // officer does not exist
                                                Console.SetCursorPosition(i + 23, j + 9);
                                                Console.Write("                 Code Not Matched");
                                            }
                                            if (code == "PC-123" || code == "PC-456" || code == "PC-789")
                                            {
                                                Console.SetCursorPosition(i + 23, j + 9);
                                                Console.Write("                This Officer cannot be Deleted.");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                                // geting the option from main menu
                                Console.SetCursorPosition(60, 47);
                                Console.Write("Enter your required option from the above menu: ");
                                requirement = Console.ReadLine();

                                // Validation
                                while (requirement != "1" && requirement != "2" && requirement != "3")
                                {
                                    Console.SetCursorPosition(60, 49);
                                    Console.Write("         Choose the Correct Option ");
                                    Console.SetCursorPosition(60, 47);
                                    Console.Write("Enter your required option from the above menu:              ");
                                    Console.SetCursorPosition(60, 47);
                                    Console.Write("Enter your required option from the above menu: ");
                                    requirement = Console.ReadLine();

                                    Console.SetCursorPosition(60, 49);
                                    Console.Write("                                                       ");
                                }

                                Console.Clear();
                            }
                        }

                    }
                }
                // Option 2: Sign Up
                else if (option == "2")
                {
                    Console.Clear();
                    printHeader();

                    Console.SetCursorPosition(23, 15);
                    Console.Write("Provide the following requirements to SIGN UP : ");
                    Console.SetCursorPosition(60, 20);
                    Console.Write("---------------------------------------------------");

                    // geting username and password as input
                    int m = 73, n = 22;
                    Console.SetCursorPosition(m, n);
                    Console.Write("User Name: ");

                    var1 = Console.ReadLine();

                    // Validation For Username
                    while (string.IsNullOrEmpty(var1))
                    {
                        Console.SetCursorPosition(m, n + 1);
                        Console.Write("Invalid username.");
                        Console.SetCursorPosition(m, n);
                        Console.Write("User Name: ");
                        var1 = Console.ReadLine();
                    }

                    Console.SetCursorPosition(m, n + 1);
                    Console.Write("                   ");
                    Console.SetCursorPosition(m, n + 2);
                    Console.Write("Password: ");
                    var2 = Console.ReadLine();

                    // Validation For Password
                    while (var2.Length < 6)
                    {
                        Console.SetCursorPosition(m + 10, n + 2);
                        Console.Write("                                               ");
                        Console.SetCursorPosition(m, n + 3);
                        Console.Write("Invalid password (6 Characters)");
                        Console.SetCursorPosition(m, n + 2);
                        Console.Write("Password: ");
                        var2 = Console.ReadLine();
                    }
                    Console.SetCursorPosition(m, n + 3);
                    Console.Write("                                          ");

                    Console.SetCursorPosition(60, n + 4);
                    Console.Write("---------------------------------------------------");
                    Console.SetCursorPosition(60, n + 6);
                    Console.Write("---------------------------------------------------");

                    // asking the user his identity(role)
                    Console.SetCursorPosition(60, n + 5);
                    Console.Write("1. Administrator  2. Police Officer  3. Complainant");
                    Console.SetCursorPosition(m, n + 8);
                    Console.Write("Your Identity: ");
                    var3 = Console.ReadLine();

                    // Role : Police Officer
                    if (var3 == "2")
                    {
                        // geting the code from the user
                        string c;
                        Console.SetCursorPosition(m, n + 10);
                        Console.Write("Your Code: ");
                        c = Console.ReadLine();
                        Console.SetCursorPosition(60, 34);
                        Console.Write("---------------------------------------------------");

                        // checking if code exists
                        bool exist = existance(var1, officers, c, officerCodes, officerCount);
                        if (!exist)
                        {
                            Console.SetCursorPosition(71, 36);
                            Console.Write("Wrong Code or Name Entered.");
                            Console.SetCursorPosition(71, 38);
                            Console.Write("Press any key to continue ... ");
                            Console.ReadKey();
                        }
                        else
                        {
                            // storing this informtion in separate arrays for future use
                            int indexVar = 0;
                            bool check = checkForOff(var1, names, countUser, ref indexVar);
                            checking(check, names, var1, passwords, var2, roles, var3, countUser);

                            
                            if (check)
                            {
                               
                                signedUpOff[signedoffCount] = var1;
                                signedUpOffPass[signedoffCount] = var2;
                                signedOffCodes[signedoffCount] = c;
                                signedoffCount++;

                                // storing this informtion in file
                                storeSignedOfficers(signedUpOff, signedUpOffPass, signedOffCodes, ref signedoffCount, "SignedOfficers.txt");

                                
                            }

                        }
                    }
                    // Role : Administrator
                    else if (var3 == "1")
                    {
                        string c;
                        Console.SetCursorPosition(m, n + 10);
                        Console.Write("Your Code: ");
                        c = Console.ReadLine();
                        Console.SetCursorPosition(60, 34);
                        Console.Write("---------------------------------------------------");

                        // there is only admin with this particular code and name
                        if (var1 == admin && c == adminCode)
                        {
                            int indx = 0;
                            bool check = checkForOff(var1, names, countUser, ref indx);
                            checking(check, names, var1, passwords, var2, roles, var3, countUser);

                        }
                        else
                        {
                            Console.SetCursorPosition(71, 36);
                            Console.Write("Wrong Code or Name Entered.");
                            Console.SetCursorPosition(71, 38);
                            Console.Write("Press any key to continue ... ");
                            Console.ReadKey();
                        }
                    }
                    //Role : Complainant
                    else if (var3 == "3")
                    {
                        // there is no need of code in this case
                        Console.SetCursorPosition(60, 32);
                        Console.Write("---------------------------------------------------");

                        // signing-up the user 
                        bool check = signUp(var1, var2, names, passwords, countUser);

                        // checking if its a valid user 
                        checking(check, names, var1, passwords, var2, roles, var3, countUser);

                        // storing signed up user to complainants array
                        if (check)
                        {
                            if (var3 == "3")
                            {
                                complainants[complainantCount] = var1;
                                compPasswords[complainantCount] = var2;

                                // storing signed up user to complainants file
                                storeComplainants(complainants, compPasswords, ref complainantCount, "ComplainantsSignUp.txt");
                                complainantCount++;
                                Console.WriteLine(complainantCount);
                            }
                        }
                    }
                    else
                    {
                        while (var3 != "1" && var3 != "2" && var3 != "3")
                        {
                            Console.SetCursorPosition(70, 33);
                            Console.Write("Choose the correct option.");
                            Console.SetCursorPosition(m, n + 8);
                            Console.Write("Your Identity:             ");
                            Console.SetCursorPosition(m, n + 8);
                            Console.Write("Your Identity: ");
                            var3 = Console.ReadLine();
                        }

                    }

                    countUser++;
                }
                // Option 3: Exit the application
                else if (option == "3")
                {
                    Console.Clear();
                    break;
                }        
            }
        }

        static void storeAllUsers(string[] Names, string[] Passwords, string[] Roles, ref int CountUser, string fileName)
        {
            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path, true);


            if (Names[CountUser] != null)
            {
                file.WriteLine(Names[CountUser] + "/" + Passwords[CountUser] + "/" + Roles[CountUser]);
            }
            file.Flush();
            file.Close();
        }

        static void storeSignedOfficers(string[] SignedUpOff, string[] SignedUpOffPass, string[] signedUpOffCodes, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path);
            for (int x = 0; x < CountUser; x++)
            {
                if (SignedUpOff[x] != null)
                {
                    file.WriteLine(SignedUpOff[x] + "/" + SignedUpOffPass[x] + "/" + signedUpOffCodes[x]);
                }
            }
            file.Flush();
            file.Close();
        }

        static void storeComplainants(string[] Complainant, string[] CompPasswords, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path, true);
            if (Complainant[CountUser] != null)
            {
                file.WriteLine(Complainant[CountUser] + "/" + CompPasswords[CountUser]);
            }
            file.Flush();
            file.Close();
        }

        static void storeAssignedComplainants(string[] Complainant, string[] CompPasswords, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path);
            for (int x = 0; x < CountUser + 1; x++)
            {
                if (Complainant[x] != null)
                {
                    file.WriteLine(Complainant[x] + "/" + CompPasswords[x]);
                }
            }
            file.Flush();
            file.Close();
        }

        static void storeStatus(string[] Complainant, string[] CompPasswords, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path);
            for (int x = 0; x < CountUser + 1; x++)
            {
                if (Complainant[x] != null)
                {
                    file.WriteLine(Complainant[x] + "/" + CompPasswords[x]);
                }
            }
            file.Flush();
            file.Close();
        }

        static void storeComplaintDetails(string[] Subjects, string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Dates, string[] UrgencyLevel, string[] Details, string[] Codes, int[] Complaints, ref int K, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path);
            for (int x = 0; x < K + 1; x++)
            {
                if (Codes[x] != null)
                {
                    //int l = x + 1;
                    file.WriteLine(Subjects[x] + "/" + CompNames[x] + "/" + Emails[x] + "/" + Contacts[x] + "/" + Address[x] + "/" + Cities[x] + "/" + Provinces[x] + "/" + Dates[x] + "/" + UrgencyLevel[x] + "/" + Details[x] + "/" + Codes[x] + "/" + Complaints[x] + "/" + x);
                }
            }
            file.Flush();
            file.Close();
        }

        static void storeOfficers(string[] Officers, string[] OfficerCodes, string[] Designations, ref int OfficerCount, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            StreamWriter file = new StreamWriter(path);
            for (int x = 3; x <= OfficerCount; x++)
            {
                if (Officers[x] != null)
                {
                    file.WriteLine(Officers[x] + "/" + OfficerCodes[x] + "/" + Designations[x]);
                }
            }
            file.Flush();
            file.Close();
        }

        static void loadAllUsers(string[] Names, string[] Passwords, string[] Roles, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);


            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                string line;
                int indexing = 0;

                while ((line = file.ReadLine()) != null)
                {

                    Names[indexing] = parseData(line, 1);
                    Passwords[indexing] = parseData(line, 2);
                    Roles[indexing] = parseData(line, 3);
                    indexing++;
                }
                CountUser = indexing;

                file.Close();
            }
            else
            {
                Console.Write("Not Exists");
            }
        }

        static void loadSignedOfficers(string[] SignedUpOff, string[] SignedUpOffPass, string[] signedUpOffCodes, ref int userCount, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);


            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                string line;
                int indexing = 0;

                while ((line = file.ReadLine()) != null)
                {

                    SignedUpOff[indexing] = parseData(line, 1);
                    SignedUpOffPass[indexing] = parseData(line, 2);
                    signedUpOffCodes[indexing] = parseData(line, 3);
                    indexing++;
                }
                userCount = indexing;

                file.Close();
            }
        }

        static void loadOfficers(string[] Officers, string[] OfficerCodes, string[] Designations, ref int OfficerCount, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            string line = "";
            int indexing = 3;

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                while ((line = file.ReadLine()) != null)
                {

                    Officers[indexing] = parseData(line, 1);
                    OfficerCodes[indexing] = parseData(line, 2);
                    Designations[indexing] = parseData(line, 3);
                    indexing++;
                }
                OfficerCount = indexing - 1;

                file.Close();
            }
        }

        static void loadComplainants(string[] Complainant, string[] CompPasswords, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);


            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                string line;
                int indexing = 0;

                while ((line = file.ReadLine()) != null)
                {

                    Complainant[indexing] = parseData(line, 1);
                    CompPasswords[indexing] = parseData(line, 2);
                    indexing++;
                }
                CountUser = indexing;

                file.Close();
            }
        }

        static void loadAssignedComplainants(string[] Complainant, string[] CompPasswords, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);


            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                string line;
                int indexing = 0;

                while ((line = file.ReadLine()) != null)
                {

                    Complainant[indexing] = parseData(line, 1);
                    CompPasswords[indexing] = parseData(line, 2);
                    indexing++;
                }
                CountUser = indexing;

                file.Close();
            }
        }

        static void loadStatus(string[] Complainant, string[] CompPasswords, ref int CountUser, string fileName)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);


            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                string line;
                int indexing = 0;

                while ((line = file.ReadLine()) != null)
                {

                    Complainant[indexing] = parseData(line, 1);
                    CompPasswords[indexing] = parseData(line, 2);
                    indexing++;
                }
                CountUser = indexing;

                file.Close();
            }
        }
        static void loadComplaintDetails(string[] Subjects, string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Dates, string[] UrgencyLevel, string[] Details, string[] Codes, int[] Complaints, ref int K, string fileName, string[] NumberAsString, int[] numberAsInteger)
        {

            string path = Path.Combine("D:\\uniwork\\2nd-Semester\\OOP\\PD\\Business Application", fileName);
            string line = "";
            string ComplaintNum = "";
            int indexing;
            int justCheck = 0;
            int count = 0;

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);


                while ((line = file.ReadLine()) != null)
                {

                    indexing = stringToInt(numberAsInteger, NumberAsString, parseData(line, 13));
                    if (justCheck != indexing)
                    {
                        count++;
                    }
                    justCheck = indexing;
                    Subjects[indexing] = parseData(line, 1);
                    CompNames[indexing] = parseData(line, 2);
                    Emails[indexing] = parseData(line, 3);
                    Contacts[indexing] = parseData(line, 4);
                    Address[indexing] = parseData(line, 5);
                    Cities[indexing] = parseData(line, 6);
                    Provinces[indexing] = parseData(line, 7);
                    Dates[indexing] = parseData(line, 8);
                    UrgencyLevel[indexing] = parseData(line, 9);
                    Details[indexing] = parseData(line, 10);
                    Codes[indexing] = parseData(line, 11);
                    ComplaintNum = parseData(line, 12);
                    Complaints[indexing] = stringToInt(numberAsInteger, NumberAsString, ComplaintNum);
                }
                K = count;

                file.Close();
            }
        }

        static string parseData(string line, int field)
        {
            string word = "";
            int count = 1;

            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == '/')
                {
                    count++;
                }
                else if (count == field)
                {
                    word += line[x];
                }
            }
            return word;
        }

        static int stringToInt(int[] NumbersAsInteger, string[] NumberAsString, string number)
        {
            int required = 0;

            for (int x = 0; x < 10; x++)
            {
                if (number == NumberAsString[x])
                {
                    required = NumbersAsInteger[x];
                    break;
                }
            }
            return required;
        }



        static bool existance(string inputString1, string[] arr1, string inputString2, string[] arr2, int size)
        {
            int c = 0;
            for (int x = 0; x < size; x++)
            {
                if (inputString1 == arr1[x] && inputString2 == arr2[x])
                {
                    c++;
                    break;
                }
            }
            if (c > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string signIn(string[] Names, string[] Passwords, string[] Roles, string user, string pass, int CountUser)
        {
            int c = 0;
            int index = 0;
            for (int i = 0; i < CountUser; i++)
            {
                if (user == Names[i] && pass == Passwords[i])
                {
                    c++;
                    index = i;
                    break;
                }
            }
            if (c > 0)
            {
                return Roles[index];
            }
            else
            {
                return "nill";
            }
        }

        static bool checkForOff(string Var1, string[] Names, int CountUser, ref int indexVar)
        {
            int c = 0;
            for (int j = 0; j < CountUser; j++)
            {
                if (Var1 == Names[j])
                {
                    c++;
                    indexVar = j;
                    break;
                }
            }

            if (c > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void checking(bool check, string[] Names, string Var1, string[] Passwords, string Var2, string[] Roles, string Var3, int CountUser)
        {
            if (!check)
            {
                Console.SetCursorPosition(66, 36);
                Console.Write("Account already exists. Kindly, Re-Signup. ");
                Console.SetCursorPosition(71, 38);
                Console.Write("Press any key to continue ... ");
                Console.ReadKey();
            }
            else
            {
                Names[CountUser] = Var1;
                Passwords[CountUser] = Var2;
                Roles[CountUser] = Var3;

                storeAllUsers(Names, Passwords, Roles, ref CountUser, "AllUsers.txt");

                Console.SetCursorPosition(72, 36);
                Console.Write("You Signed Up Successfully.");
                Console.SetCursorPosition(71, 38);
                Console.Write("Press any key to continue ... ");
                Console.ReadKey();
            }
        }

        static bool signUp(string Var1, string Var2, string[] Names, string[] Passwords, int CountUser)
        {
            int c = 0;
            for (int j = 0; j < CountUser; j++)
            {
                if (Var1 == Names[j] && Var2 == Passwords[j])
                {
                    c++;
                }
            }

            if (c > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void printHeader()
        {
            Console.WriteLine();
            Console.Write("________________________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     ####### ###### ##    ## ##### #####     ###### ###### ####  #### ####### ##     ###### ## ###    ## ###### ######     ###### ###### #####  ###### ###### ##        ");
            Console.WriteLine("      ##  ## ##  ## ##    ## ##    ##        ##     ##  ## ####  ####  ##  ## ##     ##  ## ## ####   ##   ##   ##         ##  ## ##  ## ##  ##   ##   ##  ## ##        ");
            Console.WriteLine("      ##  ## ##  ## ##    ## ##    ##        ##     ##  ## ##  ##  ##  ##  ## ##     ##  ## ## ## ##  ##   ##   ##         ##  ## ##  ## ##  ##   ##   ##  ## ##        ");
            Console.WriteLine("      ###### ##  ## ##    ## ##    #####     ##     ##  ## ##      ##  ###### ##     ###### ## ##  ## ##   ##   ######     ###### ##  ## #####    ##   ###### ##        ");
            Console.WriteLine("      ##     ##  ## ##    ## ##    ##        ##     ##  ## ##      ##  ##     ##     ##  ## ## ##   ####   ##       ##     ##     ##  ## ##  ##   ##   ##  ## ##        ");
            Console.WriteLine("      ##     ###### ##### ## ##### #####     ###### ###### ##      ##  ##     ###### ##  ## ## ##    ###   ##   ######     ##     ###### ##  ##   ##   ##  ## ######    ");
            Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________");
        }

        static void printOath()
        {
            Console.SetCursorPosition(0, 13);
            Console.Write("-------------------------------------------------------WE SOLEMNLY, SINCERELY AND TRULY DECLARE AND AFFIRM THAT---------------------------------------------------------");
            Console.SetCursorPosition(0, 15);
            Console.Write("--------------------------WE WILL FAITHFULLY DISCHARGE THE DUTIES OF THE OFFICE WITH FAIRNESS, INTEGRITY, DILLIGENCE AND IMPARTIALITY, AND THAT-------------------------");
            Console.SetCursorPosition(0, 17);
            Console.Write("-----------------------------------WE WILL UPHOLD FUNDAMENTAL HUMAN RIGHTS AND ACCORD EQUAL RESPECT TO ALL PEOPLE, ACCORDING TO LAW.------------------------------------");
        }

        static void lines()
        {
            Console.SetCursorPosition(0, 41);
            Console.Write("________________________________________________________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(0, 42);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        static void complainant()
        {
            Console.Clear();
            printHeader();

            Console.SetCursorPosition(20, 17);
            Console.Write("WELCOME TO POLICE-COMPLAINTS PORTAL. We are here for providing you assistance in reporting your concerns and ensuring that");
            Console.SetCursorPosition(20, 18);
            Console.Write("your complaint is taken seriously and handled efficiently. If you have any questions or need any assistance, please do not");
            Console.SetCursorPosition(20, 19);
            Console.Write("hesitate to contact our support team. We're here to help you. We are committed to provide you clear, prompt, and empathetic");
            Console.SetCursorPosition(20, 20);
            Console.Write("assistance. Our comprehensive user guides are available to help you navigate the process with confidence. If you encounter");
            Console.SetCursorPosition(20, 21);
            Console.Write("challenges or uncertainties, please don't hesitate to reach out to us. Your concerns matter and it is our responsibilty to");
            Console.SetCursorPosition(20, 22);
            Console.Write("assist you in resolving them effectively and efficiently.");
        }

        static void compMenu(int x, int y)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, y + 1);
            Console.Write("|                                   1. User Guidance           2. My Complaints           3. File a Complaint           4. Log Out                                     |");
            Console.SetCursorPosition(0, y + 2);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        static void printMenu()
        {
            Console.SetCursorPosition(70, 22);
            Console.Write("-----------------------------");
            Console.SetCursorPosition(70, 24);
            Console.Write("         1. Sign In          ");
            Console.SetCursorPosition(70, 26);
            Console.Write("         2. Sign Up          ");
            Console.SetCursorPosition(70, 28);
            Console.Write("         3. Exit             ");
            Console.SetCursorPosition(70, 30);
            Console.Write("-----------------------------");
        }

        static void guidance()
        {
            int x = 22, y = 9;
            Console.SetCursorPosition(21, 7);
            Console.Write("||  USER GUIDANCE  ||");

            Console.SetCursorPosition(x, y);
            Console.Write("- Initiating a Complaint: ");
            Console.SetCursorPosition(x + 3, y + 1);
            Console.Write("Click on 'File a Complaint' in the menu to initiate the complaint process.");

            Console.SetCursorPosition(x, y + 3);
            Console.Write("- Complainant Information: ");
            Console.SetCursorPosition(x + 3, y + 4);
            Console.Write("Provide your personal information as accurately as possible.  This includes your full name,  contact number,  email address,");
            Console.SetCursorPosition(x + 3, y + 5);
            Console.Write("and any other required details. Rest assured, your information will be kept confidential.");

            Console.SetCursorPosition(x, y + 7);
            Console.Write("- Incident Details: ");
            Console.SetCursorPosition(x + 3, y + 8);
            Console.Write("Describe the incident or complaint in detail. Include relevant information such as date, time, location, and any individuals");
            Console.SetCursorPosition(x + 3, y + 9);
            Console.Write("involved. Be as clear and specific as possible to assist us in understanding your concern.");

            Console.SetCursorPosition(x, y + 11);
            Console.Write("- Confidentiality: ");
            Console.SetCursorPosition(x + 3, y + 12);
            Console.Write("Rest assured that your personal information and complaint details will be kept confidential, and only authorized personnel will");
            Console.SetCursorPosition(x + 3, y + 13);
            Console.Write("have access to them.");

            Console.SetCursorPosition(x, y + 15);
            Console.Write("- Review and Confirmation: ");
            Console.SetCursorPosition(x + 3, y + 16);
            Console.Write("review the information you've provided to ensure accuracy. Once you're satisfied,  submit your complaint. You will receive a");
            Console.SetCursorPosition(x + 3, y + 17);
            Console.Write("confirmation message or email with a unique reference number for your complaint.");

            Console.SetCursorPosition(x, y + 19);
            Console.Write("- Feedback and Follow-Up: ");
            Console.SetCursorPosition(x + 3, y + 20);
            Console.Write("If you have questions or need updates on your complaint's status, don't hesitate to reach out to our support team.");

            Console.SetCursorPosition(x, y + 22);
            Console.Write("- Patience: ");
            Console.SetCursorPosition(x + 3, y + 23);
            Console.Write("Investigations may take time, but we're committed to resolving your complaint thoroughly and fairly.");

            Console.SetCursorPosition(x, y + 25);
            Console.Write("By following these step-by-step instructions and guidance, you can file a complaint effectively and confidently using the Police");
            Console.SetCursorPosition(x, y + 26);
            Console.Write("Complaint Management System. Your cooperation and clear communication are essential in helping us address your concerns promptly");
            Console.SetCursorPosition(x, y + 27);
            Console.Write("and professionally");
        }

        static int compCompare(string user, string pass, string[] Complainants, string[] CompPasswords, int ComplainantCount)
        {
            int c = 0;
            int j = 0;

            while (j <= ComplainantCount)
            {
                if (user == Complainants[j] && pass == CompPasswords[j])
                {
                    c++;
                    break;
                }
                j++;
            }

            if (c > 0)
            {
                return j;
            }
            else
            {
                return -1;
            }
        }

        static int codeCompare(string code, string[] Codes, int compIndex)
        {
            int c = 0;

            int index = 0;
            string words;
            string[] newString = new string[500];
            //Console.WriteLine(Codes[compIndex]);
            //Console.WriteLine(compIndex);
            //Console.ReadKey();

            if (Codes[compIndex] != null)
            {
                
                for (int x = 0; x < Codes[compIndex].Length; x++)
                {
                    words = "";
                    while (Codes[compIndex][x] != '|' && x < Codes[compIndex].Length)
                    {
                        words += Codes[compIndex][x];
                        x++;
                    }
                    newString[index] = words;

                    if (code == newString[index])
                    {
                        c++;
                        break;
                    }
                    index++;
                }
            }

            if (c > 0)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        static int findIndex(string code, string[] Codes, int compIndex)
        {
            int c = 0;
            int index = 0;

            //if (Codes[compIndex] != null)
            //{
                for (int x = 0; x < compIndex; x++)
                {
                    if (code == Codes[x])
                    {
                        c++;
                        break;
                    }
                    index++;
                }
            //}

            if (c > 0)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        static string compareIndex(string inputString, string[] newString, int CodeCompare)
        {
            int index = 0;
            string words;
            string require = "";

            if (inputString != null)
            {

                if (inputString.Length >= 0)
                {
                    for (int x = 0; x < inputString.Length; x++)
                    {
                        words = "";
                        while (inputString[x] != '|' && x < inputString.Length)
                        {
                            words += inputString[x];
                            x++;
                        }
                        newString[index] = words;
                        if (index == CodeCompare)
                        {
                            require = newString[index];
                            break;
                        }
                        index++;
                    }
                }
            }
            return require;
        }

        static int separateWords(string inputString, string[] newString, int xForGoto, int y)
        {
            int index = 0;
            string words;
            int yForGoto;
            for (int x = 0; x < inputString.Length; x++)
            {
                words = "";
                while (inputString[x] != '|' && x < inputString.Length)
                {
                    words += inputString[x];
                    x++;
                }
                newString[index] = words;
                yForGoto = y + 3 + index;
                Console.SetCursorPosition(xForGoto, yForGoto);
                if (newString[index] == "1" || newString[index] == "2" || (newString[index] == "3"))
                {
                    if (newString[index] == "1")
                    {
                        Console.Write("|        "
                             + "High");
                    }
                    else if (newString[index] == "2")
                    {
                        Console.Write("|        "
                             + "Normal");
                    }
                    else
                    {
                        Console.Write("|        "
                             + "Low");
                    }
                }
                else
                {
                    Console.Write("|     " + newString[index]);
                }
                Console.SetCursorPosition(144, yForGoto);
                Console.Write("|");
                index++;
            }

            return index;
        }

        static string complaintsList(string[] Codes, string[] Subjects, string[] Dates, string[] UrgencyLevel, int ComplaintCount, int compIndex, ref int loopVar, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("| Serial No. |     Code     |                    Subject                       |        Date        |    Urgency Level    |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            int j = 0;
            string[] newString = new string[500];

            if (Codes != null && compIndex >= 0 && compIndex < Codes.Length && Codes[compIndex] != null)  
            {
                if (Codes[compIndex] != null)
                {
                    separateWords(Codes[compIndex], newString, x + 13, y);
                    separateWords(Subjects[compIndex], newString, x + 28, y);
                    int index = separateWords(Dates[compIndex], newString, x + 79, y);
                    separateWords(UrgencyLevel[compIndex], newString, x + 100, y);

                    while (j < index)
                    {
                        Console.SetCursorPosition(x, y + 3 + j);
                        int l = j + 1;
                        Console.Write("|      " + l);
                        j++;
                    }
                }
            }

            loopVar = j;

            Console.SetCursorPosition(x, y + 3 + j);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            string yesOrNo;
            Console.SetCursorPosition(x + 41, y + 3 + j + 3);
            Console.Write("Do you want to further open any complaint? ");
            Console.SetCursorPosition(x + 41, y + 3 + j + 5);
            Console.Write("         1. Yes         2. No");
            Console.SetCursorPosition(x + 47, y + 3 + j + 7);
            Console.Write("Enter your required option:  ");
            yesOrNo = Console.ReadLine();

            while (yesOrNo != "1" && yesOrNo != "2")
            {
                Console.SetCursorPosition(x + 47, y + 3 + j + 9);
                Console.Write("      Invalid Option");
                Console.SetCursorPosition(x + 47, y + 3 + j + 7);
                Console.Write("Enter your required option:   ");
                Console.SetCursorPosition(x + 47, y + 3 + j + 7);
                Console.Write("Enter your required option:  ");
                yesOrNo = Console.ReadLine();
            }
            Console.SetCursorPosition(x + 47, y + 3 + j + 9);
            Console.Write("                       ");

            string require = "";

            if (yesOrNo == "1")
            {
                string openingCode;
                Console.SetCursorPosition(x + 42, y + 3 + j + 9);
                Console.Write("Enter the code of that complaint: ");
                openingCode = Console.ReadLine();

                require = openingCode;
            }
            else if (yesOrNo == "2")
            {
                require = "0";
            }
            return require;
        }

        static string historyMenu(string tasks)
        {
            int x = 43, y = 36;
            Console.SetCursorPosition(x, y);
            Console.Write("--------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|       1. Delete Complaint       2. Check Status       3. Nothing       |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("--------------------------------------------------------------------------");

            Console.SetCursorPosition(x, y + 4);
            Console.Write("                        Enter the required option: ");
            tasks = Console.ReadLine();

            return tasks;
        }

        static int deleteComplaint(string[] mainString, int codeIndex, int compIndex)
        {
            string[] newString = new string[500];
            StringBuilder main = new StringBuilder(mainString[compIndex]);

            string MiniString = compareIndex(mainString[compIndex], newString, codeIndex);
            //Console.WriteLine(MiniString);

            int position = mainString[compIndex].IndexOf(MiniString);
            //Console.WriteLine(position);

            main.Remove(position, MiniString.Length + 1);

            mainString[compIndex] = main.ToString();

            return position;
        }

        static int editComplaint(string[] mainString, int codeIndex, int compIndex)
        {
            string[] newString = new string[500];
            StringBuilder main = new StringBuilder(mainString[compIndex]);

            string MiniString = compareIndex(mainString[compIndex], newString, codeIndex);

            int position = 0;

            if (mainString != null && compIndex >= 0 && mainString[compIndex] != null)
            {
                position = mainString[compIndex].IndexOf(MiniString);

                main.Remove(position, MiniString.Length);
            }

            mainString[compIndex] = main.ToString();

            return position;
        }

        static void copyElements(string[] firstArray, string[] secondArray, int size)
        {
            
            for (int i = 0; i <= size; i++)
            {
                secondArray[i] = firstArray[i];
            }
        }

        static string editMenu()
        {

            Console.SetCursorPosition(25, 17);
            Console.Write("What you want to edit? ");

            Console.SetCursorPosition(70, 18);
            Console.Write("-------------------------------------");
            Console.SetCursorPosition(70, 19);
            Console.Write("|          1. Subject               |");
            Console.SetCursorPosition(70, 20);
            Console.Write("|          2. Code                  |");
            Console.SetCursorPosition(70, 21);
            Console.Write("|          3. Name                  |");
            Console.SetCursorPosition(70, 22);
            Console.Write("|          4. Email Adress          |");
            Console.SetCursorPosition(70, 23);
            Console.Write("|          5. Contact Number        |");
            Console.SetCursorPosition(70, 24);
            Console.Write("|          6. Home Address          |");
            Console.SetCursorPosition(70, 25);
            Console.Write("|          7. City                  |");
            Console.SetCursorPosition(70, 26);
            Console.Write("|          8. Province              |");
            Console.SetCursorPosition(70, 27);
            Console.Write("|          9. Date                  |");
            Console.SetCursorPosition(70, 28);
            Console.Write("|          10. Urgency Level        |");
            Console.SetCursorPosition(70, 29);
            Console.Write("|          11. Incident Detail      |");
            Console.SetCursorPosition(70, 30);
            Console.Write("-------------------------------------");

            string editNo;
            Console.SetCursorPosition(70, 32);
            Console.Write("           Have to edit: ");
            editNo = Console.ReadLine();

            while (editNo != "1" && editNo != "2" && editNo != "3" && editNo != "4" && editNo != "5" && editNo != "6" && editNo != "7" && editNo != "8" && editNo != "9" && editNo != "10" && editNo != "11")
            {
                Console.SetCursorPosition(70, 32);
                Console.Write("           Have to edit:       ");
                Console.SetCursorPosition(70, 32);
                Console.Write("           Have to edit: ");
                editNo = Console.ReadLine();
            }

            return editNo;
        }

        static void storeInMain(string editedString, string[] mainArr, string[] Dates, string[] UrgencyLevel, string[] Subjects, string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Details, string[] Codes, int ComplaintCount)
        {
            if (editedString == "subject")
            {
                copyElements(mainArr, Subjects, ComplaintCount);
            }
            else if (editedString == "code")
            {
                copyElements(mainArr, Codes, ComplaintCount);
            }
            else if (editedString == "name")
            {
                copyElements(mainArr, CompNames, ComplaintCount);
            }
            else if (editedString == "email address")
            {
                copyElements(mainArr, Emails, ComplaintCount);
            }
            else if (editedString == "contact number")
            {
                copyElements(mainArr, Contacts, ComplaintCount);
            }
            else if (editedString == "home address")
            {
                copyElements(mainArr, Address, ComplaintCount);
            }
            else if (editedString == "city")
            {
                copyElements(mainArr, Cities, ComplaintCount);
            }
            else if (editedString == "province")
            {
                copyElements(mainArr, Provinces, ComplaintCount);
            }
            else if (editedString == "date")
            {
                copyElements(mainArr, Dates, ComplaintCount);
            }
            else if (editedString == "urgency level")
            {
                copyElements(mainArr, UrgencyLevel, ComplaintCount);
            }
            else if (editedString == "detail")
            {
                copyElements(mainArr, Details, ComplaintCount);
            }
        }

        static string findMainString(string number, string[] Dates, string[] UrgencyLevel, string[] Subjects, string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Details, string[] Codes, int codeIndex, int index, int ComplaintCount, string[] mainArr, ref string editedString)
        {
            string[] newString = new string[500];
            string mainString = "";
            if (number == "1")
            {
                mainString = compareIndex(Subjects[index], newString, codeIndex);
                copyElements(Subjects, mainArr, ComplaintCount);
                editedString = "subject";
                editedString = "subject";
            }
            else if (number == "2")
            {
                mainString = compareIndex(Codes[index], newString, codeIndex);
                copyElements(Codes, mainArr, ComplaintCount);
                editedString = "code";
            }
            else if (number == "3")
            {
                mainString = compareIndex(CompNames[index], newString, codeIndex);
                copyElements(CompNames, mainArr, ComplaintCount);
                editedString = "name";
            }
            else if (number == "4")
            {
                mainString = compareIndex(Emails[index], newString, codeIndex);
                copyElements(Emails, mainArr, ComplaintCount);
                editedString = "email address";
            }
            else if (number == "5")
            {
                mainString = compareIndex(Contacts[index], newString, codeIndex);
                copyElements(Contacts, mainArr, ComplaintCount);
                editedString = "contact number";
            }
            else if (number == "6")
            {
                mainString = compareIndex(Address[index], newString, codeIndex);
                ;
                copyElements(Address, mainArr, ComplaintCount);
                editedString = "home address";
            }
            else if (number == "7")
            {
                mainString = compareIndex(Cities[index], newString, codeIndex);
                copyElements(Cities, mainArr, ComplaintCount);
                editedString = "city";
            }
            else if (number == "8")
            {
                mainString = compareIndex(Provinces[index], newString, codeIndex);
                copyElements(Provinces, mainArr, ComplaintCount);
                editedString = "province";
            }
            else if (number == "9")
            {
                mainString = compareIndex(Dates[index], newString, codeIndex);
                copyElements(Dates, mainArr, ComplaintCount);
                editedString = "date";
            }
            else if (number == "10")
            {
                mainString = compareIndex(UrgencyLevel[index], newString, codeIndex);
                copyElements(UrgencyLevel, mainArr, ComplaintCount);
                editedString = "urgency level";
            }
            else if (number == "11")
            {
                mainString = compareIndex(Details[index], newString, codeIndex);
                copyElements(Details, mainArr, ComplaintCount);
                editedString = "details";
            }

            return mainString;
        }

        static void generalDetails(string[] Codes, string[] Subjects, string[] Dates, string[] UrgencyLevel, int codeIndex, int compIndex, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("--------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|     Code     |                    Subject                       |        Date        |    Urgency Level    |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("--------------------------------------------------------------------------------------------------------------");

            string[] newString = new string[500];
            Console.SetCursorPosition(x, y + 3);
            Console.Write("| " + compareIndex(Codes[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 15, y + 3);
            Console.Write("| " + compareIndex(Subjects[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 66, y + 3);
            Console.Write("| " + compareIndex(Dates[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 87, y + 3);
            Console.Write("| " + compareIndex(UrgencyLevel[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 109, y + 3);
            Console.Write("|");

            Console.SetCursorPosition(x, y + 4);
            Console.Write("--------------------------------------------------------------------------------------------------------------");
        }

        static void personalDetails(string[] Subjects, string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Details, string[] Codes, int codeIndex, int compIndex, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(x, y + 1);
            Console.Write("| Name");
            Console.SetCursorPosition(x + 19, y + 1);
            Console.Write("| Email Address");
            Console.SetCursorPosition(x + 47, y + 1);
            Console.Write("| Contact Number");
            Console.SetCursorPosition(x + 70, y + 1);
            Console.Write("| Home Address");
            Console.SetCursorPosition(x + 96, y + 1);
            Console.Write("| City");
            Console.SetCursorPosition(x + 109, y + 1);
            Console.Write("| Province   |");

            Console.SetCursorPosition(x, y + 2);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            string[] newString = new string[500];
            Console.SetCursorPosition(x, y + 3);
            Console.Write("| " + compareIndex(CompNames[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 19, y + 3);
            Console.Write("| " + compareIndex(Emails[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 47, y + 3);
            Console.Write("| " + compareIndex(Contacts[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 70, y + 3);
            Console.Write("| " + compareIndex(Address[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 96, y + 3);
            Console.Write("| " + compareIndex(Cities[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 109, y + 3);
            Console.Write("| " + compareIndex(Provinces[compIndex], newString, codeIndex));
            Console.SetCursorPosition(x + 122, y + 3);
            Console.Write("|");

            Console.SetCursorPosition(x, y + 4);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(x + 3, y + 6);
            Console.Write("Detail of the incident: ");
            Console.SetCursorPosition(x + 3, y + 8);
            Console.Write(compareIndex(Details[compIndex], newString, codeIndex));
        }

        static void complaint(string[] Subjects, string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Dates, string[] UrgencyLevel, string[] Details, string[] Codes, int K, string[] CodeStatus
                    , string[] Status, int StatusCount)
        {
            int x = 23, y = 18;
            Console.SetCursorPosition(70, 7);
            Console.Write("POILICE COMPLAINT FORM");
            Console.SetCursorPosition(21, 8);
            Console.Write("___________________________________________________________________________________________________________________________");

            Console.SetCursorPosition(55, 11);
            Console.Write("Provide the following requirements to file your complaint.");

            string name, email, contact, addr, city, province, date, sub, code, detail, urgent;
            int[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Console.SetCursorPosition(x, y - 4);
            Console.Write("Your Compalaint's Subject: ");

            sub = Console.ReadLine();

            // Validation
            while (string.IsNullOrEmpty(sub))
            {
                Console.SetCursorPosition(x, y - 2);
                Console.Write("Invalid Input");
                Console.SetCursorPosition(x, y - 4);
                Console.Write("Your Compalaint's Subject: ");
                sub = Console.ReadLine();
            }

            Console.SetCursorPosition(x, y - 2);
            Console.Write("                       ");

            int checkSub = 0;
            for (int idx = 0; idx < sub.Length; idx++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (sub[idx] == nums[i])
                    {
                        checkSub++;
                    }
                }
            }

            while (checkSub > 0)
            {
                checkSub = 0;
                for (int idx = 0; idx < sub.Length; idx++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (sub[idx] == nums[i])
                        {
                            checkSub++;
                        }
                    }
                }

                if (checkSub > 0)
                {
                    Console.SetCursorPosition(x, y - 2);
                    Console.Write("Invalid Input");
                    Console.SetCursorPosition(x, y - 4);
                    Console.Write("Your Compalaint's Subject:                                              ");
                    Console.SetCursorPosition(x, y - 4);
                    Console.Write("Your Compalaint's Subject: ");
                    sub = Console.ReadLine();

                    Console.SetCursorPosition(x, y - 2);
                    Console.Write("                       ");
                }
            }


            Console.SetCursorPosition(x, y - 2);
            Console.Write("Enter a four-digit code: ");
            code = Console.ReadLine();

            // Validation
            while (true)
            {
                while (code.Length != 4)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("Code should consist of Four Digits.");
                    Console.SetCursorPosition(x, y - 2);
                    Console.Write("Enter a four-digit code:          ");
                    Console.SetCursorPosition(x, y - 2);
                    Console.Write("Enter a four-digit code: ");
                    code = Console.ReadLine();
                    Console.SetCursorPosition(x, y);
                    Console.Write("                                             ");
                }

                int check = 0;
                for (int idx = 0; idx < 4; idx++)
                {
                    check = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        if (code[idx] == nums[i])
                        {
                            check++;
                        }
                    }
                    if (check == 0)
                    {
                        break;
                    }

                }

                while (code.Length == 4 && check == 0)
                {
                    for (int idx = 0; idx < 4; idx++)
                    {
                        check = 0;

                        for (int i = 0; i < 10; i++)
                        {
                            if (code[idx] == nums[i])
                            {
                                check++;
                            }
                        }
                        if (check == 0)
                        {
                            break;
                        }
                    }

                    if (check == 0)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("Invalid Code");
                        Console.SetCursorPosition(x, y - 2);
                        Console.Write("Enter a four-digit code:          ");
                        Console.SetCursorPosition(x, y - 2);
                        Console.Write("Enter a four-digit code: ");
                        code = Console.ReadLine();

                        Console.SetCursorPosition(x, y);
                        Console.Write("                     ");
                    }
                }
                if (code.Length == 4 && check > 0)
                {
                    break;
                }
            }


            int indexCheck = codeCompare(code, Codes, K);
            while (indexCheck != -1)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("                                  This Code is already taken. ");
                Console.SetCursorPosition(x, y - 2);
                Console.Write("Enter a four-digit code:                ");
                Console.SetCursorPosition(x, y - 2);
                Console.Write("Enter a four-digit code: ");
                code = Console.ReadLine();
                Console.SetCursorPosition(x, y);
                Console.Write("                                                              ");
                indexCheck = codeCompare(code, Codes, K);
            }

            Console.SetCursorPosition(x, y);
            Console.Write("Enter Your Name: ");

            name = Console.ReadLine();

            // Validation
            while (string.IsNullOrEmpty(name))
            {
                Console.SetCursorPosition(x, y + 2);
                Console.Write("Invalid Input.");
                Console.SetCursorPosition(x, y);
                Console.Write("Enter Your Name: ");
                name = Console.ReadLine();
            }

            Console.SetCursorPosition(x, y + 2);
            Console.Write("                       ");

            int checkName = 0;
            for (int idx = 0; idx < name.Length; idx++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (name[idx] == nums[i])
                    {
                        checkName++;
                    }
                }
            }

            while (checkName > 0)
            {
                checkName = 0;
                for (int idx = 0; idx < name.Length; idx++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (name[idx] == nums[i])
                        {
                            checkName++;
                        }
                    }
                }

                if (checkName > 0)
                {
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("Invalid Input.");
                    Console.SetCursorPosition(x, y);
                    Console.Write("Enter Your Name:                                       ");
                    Console.SetCursorPosition(x, y);
                    Console.Write("Enter Your Name: ");
                    name = Console.ReadLine();

                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("                       ");
                }
            }

            Console.SetCursorPosition(x, y + 2);
            Console.Write("Enter Your Email Adress: ");
            email = Console.ReadLine();

            // Validation
            int checkEmail = 0;
            char eml = '@';
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == eml)
                {
                    checkEmail++;
                }
            }

            while (checkEmail == 0)
            {
                checkEmail = 0;
                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == eml)
                    {
                        checkEmail++;
                    }
                }
                if (checkEmail == 0)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("Invalid Input.");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("Enter Your Email Adress:                                            ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("Enter Your Email Adress: ");
                    email = Console.ReadLine();
                }

                Console.SetCursorPosition(x, y + 4);
                Console.Write("                                ");
            }



            Console.SetCursorPosition(x, y + 4);
            Console.Write("Enter Your Contact Number: ");
            contact = Console.ReadLine();

            // Validation
            if (contact.Length == 11)
            {
                for (int idx = 0; idx < 11; idx++)
                {
                    int check = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        if (contact[idx] == nums[i])
                        {
                            check++;
                        }
                    }
                    if (check == 0)
                    {
                        Console.SetCursorPosition(x, y + 6);
                        Console.Write("Invalid Phone Number");
                        Console.SetCursorPosition(x, y + 4);
                        Console.Write("Enter Your Contact Number:                                    ");
                        Console.SetCursorPosition(x, y + 4);
                        Console.Write("Enter Your Contact Number: ");
                        contact = Console.ReadLine();
                        Console.SetCursorPosition(x, y + 6);
                        Console.Write("                          ");
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(x, y + 6);
                Console.Write("Phone Number should consist of Eleven Digits.");
                Console.SetCursorPosition(x, y + 4);
                Console.Write("Enter Your Contact Number:                                    ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write("Enter Your Contact Number: ");
                contact = Console.ReadLine();
                Console.SetCursorPosition(x, y + 6);
                Console.Write("                                                          ");
            }

            Console.SetCursorPosition(x, y + 6);
            Console.Write("Enter Your Home Address: ");
            addr = Console.ReadLine();

            // Validation
            while (string.IsNullOrEmpty(addr))
            {
                Console.SetCursorPosition(x, y + 8);
                Console.Write("Invalid Input.");
                Console.SetCursorPosition(x, y + 6);
                Console.Write("Enter Your Home Address: ");
                addr = Console.ReadLine();
            }

            Console.SetCursorPosition(x, y + 8);
            Console.Write("                        ");

            Console.SetCursorPosition(x, y + 8);
            Console.Write("Enter Your City: ");
            city = Console.ReadLine();

            // Validation
            while (string.IsNullOrEmpty(city))
            {
                Console.SetCursorPosition(x, y + 10);
                Console.Write("Invalid Input.");
                Console.SetCursorPosition(x, y + 8);
                Console.Write("Enter Your City: ");
                city = Console.ReadLine();
            }

            Console.SetCursorPosition(x, y + 10);
            Console.Write("                           ");

            int checkCity = 0;
            for (int idx = 0; idx < city.Length; idx++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (city[idx] == nums[i])
                    {
                        checkCity++;
                    }
                }
            }

            while (checkCity > 0)
            {
                checkCity = 0;
                for (int idx = 0; idx < city.Length; idx++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (city[idx] == nums[i])
                        {
                            checkCity++;
                        }
                    }
                }

                if (checkCity > 0)
                {
                    Console.SetCursorPosition(x, y + 10);
                    Console.Write("Invalid Input.");
                    Console.SetCursorPosition(x, y + 8);
                    Console.Write("Enter Your City:                                  ");
                    Console.SetCursorPosition(x, y + 8);
                    Console.Write("Enter Your City: ");
                    city = Console.ReadLine();

                    Console.SetCursorPosition(x, y + 19);
                    Console.Write("                       ");
                }
            }

            Console.SetCursorPosition(x, y + 10);
            Console.Write("Enter Your Province: ");
            province = Console.ReadLine();

            // Validation
            while (string.IsNullOrEmpty(province))
            {
                Console.SetCursorPosition(x, y + 12);
                Console.Write("Invalid Input.");
                Console.SetCursorPosition(x, y + 10);
                Console.Write("Enter Your Province: ");
                province = Console.ReadLine();
            }

            Console.SetCursorPosition(x, y + 12);
            Console.Write("                           ");

            int checkProvince = 0;
            for (int idx = 0; idx < province.Length; idx++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (province[idx] == nums[i])
                    {
                        checkProvince++;
                    }
                }
            }

            while (checkProvince > 0)
            {
                checkProvince = 0;
                for (int idx = 0; idx < province.Length; idx++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (province[idx] == nums[i])
                        {
                            checkProvince++;
                        }
                    }
                }

                if (checkProvince > 0)
                {
                    Console.SetCursorPosition(x, y + 12);
                    Console.Write("Invalid Input.");
                    Console.SetCursorPosition(x, y + 10);
                    Console.Write("Enter Your Province:                                            ");
                    Console.SetCursorPosition(x, y + 10);
                    Console.Write("Enter Your Province: ");
                    province = Console.ReadLine();

                    Console.SetCursorPosition(x, y + 12);
                    Console.Write("                       ");
                }
            }


            Console.SetCursorPosition(x, y + 12);
            Console.Write("Enter the Date: ");
            date = Console.ReadLine();

            // Validation
            while (true)
            {
                while (string.IsNullOrEmpty(date) || date.Length == 1)
                {
                    Console.SetCursorPosition(x, y + 14);
                    Console.Write("Invalid Input.");
                    Console.SetCursorPosition(x, y + 12);
                    Console.Write("Enter the Date:                           ");
                    Console.SetCursorPosition(x, y + 12);
                    Console.Write("Enter the Date: ");
                    date = Console.ReadLine();
                }

                Console.SetCursorPosition(x, y + 14);
                Console.Write("                           ");


                int checkDate = 0;
                for (int idx = 0; idx < date.Length; idx++)
                {
                    checkDate = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        if (date[idx] == nums[i])
                        {
                            checkDate++;
                        }
                    }
                    if (checkDate == 0)
                    {
                        break;
                    }
                }

                while (checkDate == 0)
                {
                    for (int idx = 0; idx < date.Length; idx++)
                    {
                        checkDate = 0;

                        for (int i = 0; i < 10; i++)
                        {
                            if (date[idx] == nums[i])
                            {
                                checkDate++;
                            }
                        }
                        if (checkDate == 0)
                        {
                            break;
                        }
                    }

                    if (checkDate == 0)
                    {
                        Console.SetCursorPosition(x, y + 14);
                        Console.Write("Invalid date");
                        Console.SetCursorPosition(x, y + 12);
                        Console.Write("Enter the Date:                              ");
                        Console.SetCursorPosition(x, y + 12);
                        Console.Write("Enter the Date: ");
                        date = Console.ReadLine();
                        Console.SetCursorPosition(x, y + 14);
                        Console.Write("                     ");
                    }
                }
                if (date.Length != 1 && !(string.IsNullOrEmpty(date)) && checkDate > 0)
                {
                    break;
                }
            }


            Console.SetCursorPosition(x + 27, y + 13);
            Console.Write("------------------------------------------------------------------------");
            Console.SetCursorPosition(x + 27, y + 14);
            Console.Write("|             1. High           2. Normal           3. Low             |");
            Console.SetCursorPosition(x + 27, y + 15);
            Console.Write("------------------------------------------------------------------------");

            Console.SetCursorPosition(x, y + 17);
            Console.Write("Enter Your Complaint's Urgency Level: ");
            urgent = Console.ReadLine();

            if (urgent != "1" && urgent != "2" && urgent != "3")
            {
                while (urgent != "1" && urgent != "2" && urgent != "3")
                {
                    Console.SetCursorPosition(x, y + 19);
                    Console.Write("                                  Choose the Correct Option ");
                    Console.SetCursorPosition(x, y + 17);
                    Console.Write("Enter Your Complaint's Urgency Level:           ");
                    Console.SetCursorPosition(x, y + 17);
                    Console.Write("Enter Your Complaint's Urgency Level: ");
                    urgent = Console.ReadLine();
                }
            }

            Console.SetCursorPosition(x, y + 19);
            Console.Write("Enter the Incident Details Such As When and What happened: ");
            Console.SetCursorPosition(x + 4, y + 21);

            detail = Console.ReadLine();

            // Validation
            while (string.IsNullOrEmpty(detail))
            {
                Console.SetCursorPosition(x, y + 21);
                Console.Write("Kindly, provide some relevant details.");
                Console.SetCursorPosition(x, y + 19);
                Console.Write("Enter the Incident Details Such As When and What happened: ");
                Console.SetCursorPosition(x, y + 21);
                Console.Write("                                                ");
                Console.SetCursorPosition(x + 4, y + 21);
                detail = Console.ReadLine();
            }

            CodeStatus[StatusCount] = code;
            Status[StatusCount] = "Pending";
            storeStatus(Status, CodeStatus, ref StatusCount, "Status.txt");

            Subjects[K] += sub + "|";
            Codes[K] += code + "|";
            CompNames[K] += name + "|";
            Emails[K] += email + "|";
            Contacts[K] += contact + "|";
            Address[K] += addr + "|";
            Cities[K] += city + "|";
            Provinces[K] += province + "|";
            Dates[K] += date + "|";
            UrgencyLevel[K] += urgent + "|";
            Details[K] += detail + "|";

            Console.SetCursorPosition(x, y + 24);
            Console.Write("Your complaint has been filed successfully. Proper Action will be taken and you will be informed of the progress soon.");
        }

        static void adminMenu(int x, int y)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, y + 1);
            Console.Write("|                                              1. Complainants                2. Police Officers                3. Log Out                                             |");
            Console.SetCursorPosition(0, y + 2);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        static string historyAdminMenu(string tasks)
        {
            int x = 37, y = 37;
            Console.SetCursorPosition(x, y);
            Console.Write("------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|     1. Delete Complaint     2. Edit Complaint     3. Status     4. Assign     5. Nothing     |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(x, y + 4);
            Console.Write("                             Enter the required option: ");
            tasks = Console.ReadLine();

            return tasks;
        }

        static string complainantsAdmin(string[] Complainants, string[] CompPasswords, int ComplainantCount)
        {
            int x = 41, y = 20;
            Console.SetCursorPosition(x, y);
            Console.Write("-----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|      Serial Number      |          Complainant's Name          |          Password          |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("-----------------------------------------------------------------------------------------------");

            int i = 0;

            while (i < ComplainantCount)
            {
                Console.SetCursorPosition(41, 23 + i);
                int l = i + 1;
                Console.Write("|            " + l);
                Console.SetCursorPosition(67, 23 + i);
                Console.Write("|       " + Complainants[i]);
                Console.SetCursorPosition(106, 23 + i);
                Console.Write("|      " + CompPasswords[i]);
                Console.SetCursorPosition(135, 23 + i);
                Console.Write("|");

                i++;
            }

            Console.SetCursorPosition(41, 23 + i);
            Console.Write("-----------------------------------------------------------------------------------------------");

            string yesOrNo;
            Console.SetCursorPosition(63, 23 + i + 3);
            Console.Write("Do you want to further open any complaint? ");
            Console.SetCursorPosition(63, 23 + i + 5);
            Console.Write("         1. Yes         2. No");
            Console.SetCursorPosition(68, 23 + i + 7);
            Console.Write("Enter your required option:  ");
            yesOrNo = Console.ReadLine();

            while (yesOrNo != "1" && yesOrNo != "2")
            {
                Console.SetCursorPosition(68, 23 + i + 9);
                Console.Write("      Invalid Option");
                Console.SetCursorPosition(68, 23 + i + 7);
                Console.Write("Enter your required option:     ");
                Console.SetCursorPosition(68, 23 + i + 7);
                Console.Write("Enter your required option:  ");
                yesOrNo = Console.ReadLine();
            }
            Console.SetCursorPosition(68, 23 + i + 9);
            Console.Write("                       ");

            if (yesOrNo == "1")
            {
                string openingpass;
                Console.SetCursorPosition(64, 23 + i + 9);
                Console.Write("Enter the password of that complainant: ");
                openingpass = Console.ReadLine();

                return openingpass;
            }
            else
            {
                return "0";
            }
        }

        static string statusAdminOptions(string code)
        {
            int x = 41, y = 22;
            Console.SetCursorPosition(x, y);
            Console.Write("-----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|         1. Pending        2. Invalid        3. Under Process        4. Accomplished         |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("-----------------------------------------------------------------------------------------------");

            string Status;
            Console.SetCursorPosition(41, y + 5);
            Console.Write("Set the Status of the complaint with code " + code + " to : ");
            Status = Console.ReadLine();

            while (Status != "1" && Status != "2" && Status != "3" && Status != "4")
            {
                Console.SetCursorPosition(41, y + 5);
                Console.Write("Set the Status of the complaint with code " + code + " to :                   ");
                Console.SetCursorPosition(41, y + 5);
                Console.Write("Set the Status of the complaint with code " + code + " to : ");
                Status = Console.ReadLine();
            }

            if (Status == "1" || Status == "2" || Status == "3" || Status == "4")
            {
                return Status;
            }
            else
            {
                return "nill";
            }
        }

        static int officersList(string[] Officers, string[] OfficerCodes, string[] Designations, int OfficerCount, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("-----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("| Serial Number |          Officer's Name          |          Designation          |   Code   |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("-----------------------------------------------------------------------------------------------");

            int i = 0;

            while (i < OfficerCount)
            {
                Console.SetCursorPosition(41, y + 3 + i);
                int l = i + 1;
                Console.Write("|       " + l);
                Console.SetCursorPosition(57, y + 3 + i);
                Console.Write("|     " + Officers[i]);
                Console.SetCursorPosition(92, y + 3 + i);
                Console.Write("|     " + Designations[i]);
                Console.SetCursorPosition(124, y + 3 + i);
                Console.Write("|  " + OfficerCodes[i]);
                Console.SetCursorPosition(135, y + 3 + i);
                Console.Write("|");

                i++;
            }

            Console.SetCursorPosition(41, y + 3 + i);
            Console.Write("-----------------------------------------------------------------------------------------------");

            int length = i;
            return length;
        }

        static int signedOfficersList(string[] signedOfficers, string[] Officers, string[] OfficerCodes, string[] Designations, int signedOfficerCount, int OfficerCount, int x, int y)
        {
            if (signedOfficerCount == 0)
            {
                Console.SetCursorPosition(x + 28, y);
                Console.Write("No Officer has signed up yet.");
                return 0;
            }
            else
            {
                Console.SetCursorPosition(x, y);
                Console.Write("-----------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("| Serial Number |          Officer's Name          |          Designation          |   Code   |");
                Console.SetCursorPosition(x, y + 2);
                Console.Write("-----------------------------------------------------------------------------------------------");

                int i = 0;

                while (i <= signedOfficerCount && signedOfficers[i] != null)
                {

                    int index = findIndex(signedOfficers[i], Officers, OfficerCount);
                    
                    Console.SetCursorPosition(41, y + 3 + i);
                    int l = i + 1;
                    Console.Write("|       " + l);
                    Console.SetCursorPosition(57, y + 3 + i);
                    Console.Write("|     " + signedOfficers[i]);
                    Console.SetCursorPosition(92, y + 3 + i);
                    Console.Write("|     " + Designations[index]);
                    Console.SetCursorPosition(124, y + 3 + i);
                    Console.Write("|  " + OfficerCodes[index]);
                    Console.SetCursorPosition(135, y + 3 + i);
                    Console.Write("|");

                    i++;
                }

                Console.SetCursorPosition(41, y + 3 + i);
                Console.Write("-----------------------------------------------------------------------------------------------");

                int length = i;
                return length;
            }
        }

        static string functionsForOff(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|      1. View Assigned Complaint     2. Add Officer     3. Delete Officer     4. Nothing      |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("------------------------------------------------------------------------------------------------");

            string Option = "";
            Console.SetCursorPosition(x, y + 4);
            Console.Write("                                Enter the required option: ");
            Option = Console.ReadLine();

            while (Option != "1" && Option != "2" && Option != "3" && Option != "4")
            {
                Console.SetCursorPosition(x, y + 6);
                Console.Write("                                     Invalid Option");
                Console.SetCursorPosition(x, y + 4);
                Console.Write("                                Enter the required option:      ");
                Console.SetCursorPosition(x, y + 4);
                Console.Write("                                Enter the required option: ");
                Option = Console.ReadLine();
            }
            Console.SetCursorPosition(x, y + 6);
            Console.Write("                                                                ");

            if (Option == "1" || Option == "2" || Option == "3" || Option == "4")
            {
                return Option;
            }
            else
            {
                Console.SetCursorPosition(x, y + 6);
                Console.Write("                              Kindly, choose the correct option.");
                return "nill";
            }
        }

        static int findAllIndexes(string code, string[] Codes, int compIndex, int[] indexes)
        {
            int c = 0;
            int index = 0;
            for (int x = 0; x < compIndex; x++)
            {
                if (code == Codes[x])
                {
                    indexes[c] = x;
                    c++;
                }
                index++;
            }

            if (c > 0)
            {
                return c;
            }
            else
            {
                return -1;
            }
        }

        static void officerMenu(int x, int y)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(0, y + 1);
            Console.Write("|                                                1. Complainants Assigned                2. Me                3. Log Out                                                |");
            Console.SetCursorPosition(0, y + 2);
            Console.Write("------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        static void me(string user, string[] Officers, string[] OfficerCodes, string[] Designations, int OfficerCount)
        {
            int indexForMe = findIndex(user, Officers, OfficerCount);

            int x = 35, y = 20;
            Console.SetCursorPosition(x + 23, y + 3);
            Console.Write("----------------------------------------------------------");
            Console.SetCursorPosition(x + 23, y + 5);
            Console.Write("               My Name: " + user);
            Console.SetCursorPosition(x + 23, y + 7);
            Console.Write("               My Designation: " + Designations[indexForMe]);
            Console.SetCursorPosition(x + 23, y + 9);
            Console.Write("               My Code: " + OfficerCodes[indexForMe]);
            Console.SetCursorPosition(x + 23, y + 11);
            Console.Write("----------------------------------------------------------");
        }
        static void officer(string[] CompNames, string[] Emails, string[] Contacts, string[] Address, string[] Cities, string[] Provinces, string[] Details, int index)
        {
            int y = 22;
            Console.SetCursorPosition(25, 13);
            Console.Write("Welcome Officer! ");

            Console.SetCursorPosition(25, 17);
            Console.Write("Personal Information of the Complainant:");

            Console.SetCursorPosition(22, 19);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(22, 20);
            Console.Write("| Name");
            Console.SetCursorPosition(41, 20);
            Console.Write("| Email Address");
            Console.SetCursorPosition(69, 20);
            Console.Write("| Contact Number");
            Console.SetCursorPosition(92, 20);
            Console.Write("| Home Address");
            Console.SetCursorPosition(118, 20);
            Console.Write("| City");

            Console.SetCursorPosition(131, 20);
            Console.Write("| Province   |");

            Console.SetCursorPosition(22, 21);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
            for (int x = 0; x < index; x++)
            {
                Console.SetCursorPosition(22, 22 + x);
                Console.Write("| " + CompNames[x]);
                Console.SetCursorPosition(41, 22 + x);
                Console.Write("| " + Emails[x]);
                Console.SetCursorPosition(69, 22 + x);
                Console.Write("| " + Contacts[x]);
                Console.SetCursorPosition(92, 22 + x);
                Console.Write("| " + Address[x]);
                Console.SetCursorPosition(118, 22 + x);
                Console.Write("| " + Cities[x]);
                Console.SetCursorPosition(131, 22 + x);
                Console.Write("| " + Provinces[x]);
                Console.SetCursorPosition(144, 22 + x);
                Console.Write("|");

                if (index > 0)
                {

                    Console.SetCursorPosition(34, 15);
                    Console.Write("Following are the details of the complaints that are assigned to you. Take proper actions in this regard.");

                    Console.SetCursorPosition(25, 27);
                    int l = x + 1;
                    Console.Write("Details of the Incident of the Complaint " + l + ": ");
                    Console.SetCursorPosition(25, 28);
                    Console.Write(Details[x]);
                }
                else
                {
                    Console.SetCursorPosition(62, 30);
                    Console.Write("You have not assigned any complaints yet.");
                    Console.SetCursorPosition(42, 31);
                    Console.Write("For any other information, contact the administrator through the contact number 03120044419.");
                }
            }

            Console.SetCursorPosition(22, y + 3);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
        }

        static void policeCar()
        {
            int x = 20, y = 37;
            Console.SetCursorPosition(x, y);
            Console.Write("          __               ");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("       __|__|__            ");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("      /    --  \\          ");
            Console.SetCursorPosition(x, y + 3);
            Console.Write(" ____/    |__|  \\________ ");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("{     ooo     ooo        C}");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("{____o . o __o . o_______C}");
            Console.SetCursorPosition(x, y + 6);
            Console.Write("      ooo     ooo          ");
        }
        static int separateWordsForAssign(int complainCount, string inputString, string[] newString, int xForGoto, int y)
        {
            int index = 0;
            string words;
            int yForGoto;

            int count = 0;
            int x = 0;
            while (x < inputString.Length)
            {
                words = "";
                while (inputString[x] != '|' && x < inputString.Length)
                {
                    words += inputString[x];
                    x++;
                }
                newString[index] = words;

                if (index == complainCount)
                {
                    yForGoto = y + 3 + count;
                    Console.SetCursorPosition(xForGoto, yForGoto);
                    if (newString[index] == "1" || newString[index] == "2" || (newString[index] == "3"))
                    {
                        if (newString[index] == "1")
                        {
                            Console.Write("|        "
                                 + "High");
                        }
                        else if (newString[index] == "2")
                        {
                            Console.Write("|        "
                                 + "Normal");
                        }
                        else
                        {
                            Console.Write("|        "
                                 + "Low");
                        }
                    }
                    else
                    {
                        Console.Write("|     " + newString[index]);
                        count++;

                        Console.SetCursorPosition(144, yForGoto);
                        Console.Write("|");
                    }
                }
                index++;
                x++;
            }

            return count;
        }

        static string complaintsListForAssign(string[] Codes, string[] Subjects, string[] Dates, string[] UrgencyLevel, int ComplaintCount, int compIndex, int numberOfIndexes, ref int loopVar, int x, int y, int j, ref int serial)
        {
            string[] newString = new string[500];
            
            if (Codes[compIndex] != null)
            {
                separateWordsForAssign(ComplaintCount, Codes[compIndex], newString, x + 13, y);
                separateWordsForAssign(ComplaintCount, Subjects[compIndex], newString, x + 28, y);
                int index = separateWordsForAssign(ComplaintCount, Dates[compIndex], newString, x + 79, y);
                separateWordsForAssign(ComplaintCount, UrgencyLevel[compIndex], newString, x + 100, y);

                Console.SetCursorPosition(x, y + 3 + j);
                int s = serial + 1;
                Console.Write("|      " + s);
                serial++;
                j++;
            }

            loopVar = j;
            return "oh";
        }

        static void complaintsListForAssign_Header()
        {
            int x = 22, y = 19;
            Console.SetCursorPosition(x, y);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("| Serial No. |     Code     |                    Subject                       |        Date        |    Urgency Level    |");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
        }


        static string openingCodeForCompDetail(int loopVar, int x, int y)
        {
            Console.SetCursorPosition(x, y + 3 + loopVar);
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            string yesOrNo;
            Console.SetCursorPosition(x + 41, y + 3 + loopVar + 3);
            Console.Write("Do you want to further open any complaint? ");
            Console.SetCursorPosition(x + 41, y + 3 + loopVar + 5);
            Console.Write("         1. Yes         2. No");
            Console.SetCursorPosition(x + 47, y + 3 + loopVar + 7);
            Console.Write("Enter your required option:  ");
            yesOrNo = Console.ReadLine();

            while (yesOrNo != "1" && yesOrNo != "2")
            {
                Console.SetCursorPosition(x + 47, y + 3 + loopVar + 9);
                Console.Write("      Invalid Option");
                Console.SetCursorPosition(x + 47, y + 3 + loopVar + 7);
                Console.Write("Enter your required option:           ");
                Console.SetCursorPosition(x + 47, y + 3 + loopVar + 7);
                Console.Write("Enter your required option:  ");
                yesOrNo = Console.ReadLine();
            }
            Console.SetCursorPosition(x + 47, y + 3 + loopVar + 9);
            Console.Write("                       ");

            if (yesOrNo == "1")
            {
                string openingCode;
                Console.SetCursorPosition(x + 42, y + 3 + loopVar + 9);
                Console.Write("Enter the code of that complaint: ");
                openingCode = Console.ReadLine();

                return openingCode;
            }
            else
            {
                return "0";
            }
        }

    }
}
