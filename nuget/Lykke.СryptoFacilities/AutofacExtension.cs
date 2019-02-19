using System;
using Autofac;
using JetBrains.Annotations;
using Lykke.Common.Log;
using Lykke.HttpClientGenerator;

namespace Lykke.СryptoFacilities
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class AutofacExtension
    {
        public static void RegisterCryptoFacilitiesClient(
            [NotNull] this ContainerBuilder builder,
            [NotNull] CryptoFacilitiesApiSettings settings)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(settings.ApiPath))
                throw new ArgumentException("Value cannot be null or whitespace.",
                    nameof(settings.ApiPath));

            if (string.IsNullOrWhiteSpace(settings.ApiPrivateKey))
                throw new ArgumentException("Value cannot be null or whitespace.",
                    nameof(settings.ApiPrivateKey));

            if (string.IsNullOrWhiteSpace(settings.ApiPublicKey))
                throw new ArgumentException("Value cannot be null or whitespace.",
                    nameof(settings.ApiPublicKey));
            
            builder.Register(ctx => new СryptoFacilitiesApiV3(
                    settings.ApiPath,
                    settings.ApiPublicKey,
                    settings.ApiPrivateKey,
                    settings.CheckCertificate,
                    ctx.Resolve<ILogFactory>()))
                .As<IСryptoFacilitiesApiV3>()
                .SingleInstance();
        }
    }
}
