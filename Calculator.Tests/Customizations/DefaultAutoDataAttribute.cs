using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Calculator.Tests
{
    public class DefaultAutoDataAttribute : AutoDataAttribute
    {
        public DefaultAutoDataAttribute()
            : base(() => new Fixture()
                .Customize(new AutoNSubstituteCustomization { ConfigureMembers = true }))
        {
        }

        public DefaultAutoDataAttribute(params ICustomization[] customizations)
            : base(() =>
            new Fixture()
                .Customize(new AutoNSubstituteCustomization { ConfigureMembers = true })
                .Customize(new CompositeCustomization(customizations)))
        {
        }
    }
}