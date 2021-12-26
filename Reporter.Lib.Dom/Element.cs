namespace Reporter.Lib.Dom
{
    public record Element
    {
        public string Key { get; init; }
        public string Value { get; init; }

        public void Deconstruct(out string elementKey, out string elementValue) =>
            (elementKey, elementValue) = (Key, Value);
    }
}