namespace Demo.Server.Data
{
    public partial class City
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public int Elevation { get; set; }
    }
}
