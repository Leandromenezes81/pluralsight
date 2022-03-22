using AutoFixture;
using System.Net.Mail;
using Xunit;

namespace DemoCode.Tests
{
    public class EmailAddressDemo
    {
        [Fact]
        public void Email()
        {
            var fixture = new Fixture();

            //string localPart = fixture.Create<EmailAddressLocalPart>().LocalPart;
            //string domain = fixture.Create<DomainName>().Domain;
            //string fullAddress = $"{localPart}@{domain}";

            MailAddress email = fixture.Create<MailAddress>();

            var sut = new EmailMessage(email.Address,
                                       fixture.Create<string>(),
                                       fixture.Create<bool>());
        }
    }
}
