namespace SqlToGraphitePlugin_PerfSentryWmi.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class With_NameParser
    {
        [Test]
        public void Should_split_names_to_get_tail()
        {
            string name = "LONBTI-ESX01p::lonE01-SQL02v.0";
            var nameparser = new NameParser("::", name);

            Assert.That(nameparser.Host, Is.EqualTo("LONBTI-ESX01p"));
            Assert.That(nameparser.Metric, Is.EqualTo("lonE01-SQL02v.0"));
        }

        [Test]
        public void Should_split_names_to_get_tail_only()
        {
            string name = "LONBTI-ESX01p::lonE01-SQL02v.0::fred";
            var nameparser = new NameParser("::", name);

            Assert.That(nameparser.Host, Is.EqualTo("LONBTI-ESX01p"));
            Assert.That(nameparser.Metric, Is.EqualTo("lonE01-SQL02v.0"));
        }

        [Test]
        public void Should_not_split()
        {
            string name = "lonE01-SQL02v.0";
            var nameparser = new NameParser("::", name);

            Assert.That(nameparser.Host, Is.EqualTo(""));
            Assert.That(nameparser.Metric, Is.EqualTo("lonE01-SQL02v.0"));
        }
    }
}
