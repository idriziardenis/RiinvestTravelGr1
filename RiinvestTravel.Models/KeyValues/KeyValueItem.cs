namespace RiinvestTravel.Models.KeyValues
{
    public class KeyValueItem
    {
        public int Key { get; set; }
        public string? SKey { get; set; }
        public bool BKey { get; set; }
        public string Value { get; set; } = null!;
    }
}
