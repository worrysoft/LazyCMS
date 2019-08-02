using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace LazyCMS.Pages
{
    public class Index_Tests : LazyCMSWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
