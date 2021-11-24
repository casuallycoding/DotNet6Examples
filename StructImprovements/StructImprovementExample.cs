namespace DotNet6Examples.StructImprovements
{

    public struct Address
    {
        public Address()
        {
            City = "<unknown>"; // Previously we had to create a constructor just to set a defaul value
        }
        public string City { get; init; }

    }


    public struct UpdatedAddress
    {
        public string City { get; init; } = "<unknown>"; //We can now set a default value on the property
    }


    public record AddressRecord
    {
        public string City { get; init; } = "<unknown>";
    }

    public class StructImprovementExample : IExampleInterface
    {
        public void Run()
        {
            var address1 = new Address();
            var address2 = new UpdatedAddress();

            var address3 = new Address() { City = "London" };
            var address4 = new UpdatedAddress() { City = "London" };
            var address5 = new AddressRecord() { City = "London" };

            Console.WriteLine($"Cities are: {address1.City} {address2.City} {address3.City} {address4.City} {address5.City}");


        }
    }
}