namespace XUnit3Example3
{
    public class UnitTest3
    {
        [Fact(Skip = "Skipped in attribute")]
        public void Ignored1()
        {
        }
        
        [Fact]
        public void Ignored2()
        {
            Assert.Skip("Skipped in test");
        }
    }
}
