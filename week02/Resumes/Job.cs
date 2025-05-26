public class Job
{
    // Member variables
    private String _jobTitle;
    private String _companyName;
    private String _location;
    private double _salary;
    private String _jobDescription;
    private String _employmentType;

    public void DisplayJobDetails()
    {
        Console.WriteLine("Job Title: " + _jobTitle);
        Console.WriteLine("Company Name: " + _companyName);
        Console.WriteLine("Location: " + _location);
        Console.WriteLine("Salary: $" + _salary);
        Console.WriteLine("Job Description: " + _jobDescription);
        Console.WriteLine("Employment Type: " + _employmentType);
        Console.WriteLine();  
    }
}