namespace Corporate.Services.FizzBuzz.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Enums;
    using Interactions;
    using Interfaces;
    using Models;
    using Moq;
    using NUnit.Framework;
    using Shouldly;

    public class FizzBuzzTests
    {
        private IModService modService;
        private ITranslationService translationService;

        [SetUp]
        public void Setup()
        {
            var modServiceMock = new Mock<IModService>();
            modServiceMock.Setup(ms => ms.GetMods(It.IsAny<int>())).Returns((int value) => new Mods()
            {
                Three = value % 3 == 0,
                Five = value % 5 == 0
            });
            modService = modServiceMock.Object;

            var translationServiceMock = new Mock<ITranslationService>();
            translationServiceMock.Setup(
                ts => ts.Translate(It.IsAny<TranslationKey>())).Returns(
                (TranslationKey key) =>
                {
                    return key switch
                    {
                        TranslationKey.Three => "Fizz",
                        TranslationKey.Five => "Buzz",
                        TranslationKey.Both => "FizzBuzz",
                        _ => "WTF",
                    };
                });

            translationService = translationServiceMock.Object;
        }

        [TestCase(3)]
        [TestCase(9)]
        public async Task Dividable_by_3_but_not_by_5_returns_fizz(int value)
        {
            // arrange
            var fizzBuzz = new TranslateFizzBuzz(modService, translationService);
            var query = new TranslateFizzBuzz.Query {Value = value};
            // act
            string result = await fizzBuzz.Handle(query, CancellationToken.None);
            // assert
            result.ShouldBe("Fizz");
        }

        [TestCase(5)]
        [TestCase(20)]
        public async Task Dividable_by_5_but_not_by_3_returns_buzz(int value)
        {
            // arrange
            var fizzBuzz = new TranslateFizzBuzz(modService, translationService);
            var query = new TranslateFizzBuzz.Query { Value = value };
            // act
            string result = await fizzBuzz.Handle(query, CancellationToken.None);
            // assert
            result.ShouldBe("Buzz");
        }

        [TestCase(15)]
        [TestCase(75)]
        public async Task Dividable_by_5_and_3_returns_fizzbuzz(int value)
        {
            // arrange
            var fizzBuzz = new TranslateFizzBuzz(modService, translationService);
            var query = new TranslateFizzBuzz.Query { Value = value };
            // act
            string result = await fizzBuzz.Handle(query, CancellationToken.None);
            // assert
            result.ShouldBe("FizzBuzz");
        }

        [TestCase(2)]
        [TestCase(8)]
        public async Task Not_dividable_by_5_or_3_returns_value(int value)
        {
            // arrange
            var fizzBuzz = new TranslateFizzBuzz(modService, translationService);
            var query = new TranslateFizzBuzz.Query { Value = value };
            // act
            string result = await fizzBuzz.Handle(query, CancellationToken.None);
            // assert
            result.ShouldBe(value.ToString());
        }
    }
}