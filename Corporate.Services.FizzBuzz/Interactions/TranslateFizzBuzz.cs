namespace Corporate.Services.FizzBuzz.Interactions
{
    using System.Threading.Tasks;
    using Interfaces;
    using Enums;
    using MediatR;
    using Models;
    using System.Threading;

    public class TranslateFizzBuzz : IRequestHandler<TranslateFizzBuzz.Query, string>
    {
        public class Query : IRequest<string>
        {
            public int Value { get; set; }
        }

        private readonly IModService modService;
        private readonly ITranslationService translationService;

        public TranslateFizzBuzz(
            IModService modService, 
            ITranslationService translationService)
        {
            this.modService = modService;
            this.translationService = translationService;
        }

        public async Task<string> Handle(Query request, CancellationToken cancellationToken)
        {
            Mods mods = modService.GetMods(request.Value);

            if (mods.Three && mods.Five)
                return translationService.Translate(TranslationKey.Both);
            if (mods.Three)
                return translationService.Translate(TranslationKey.Three);
            if (mods.Five)
                return translationService.Translate(TranslationKey.Five);

            return request.Value.ToString();
        }
    }
}
