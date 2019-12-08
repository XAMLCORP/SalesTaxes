using System;

namespace SalesTaxes.Repositories
{
    public static class Ids
    {
        public static readonly Guid DomesticProductId = Guid.Parse("d0aa3112-8f16-4284-b352-a0e7393f4928");
        public static readonly Guid ImportedProductId = Guid.Parse("44abcd3d-7089-4f04-b945-c3d2a2ba6a73");
        public static readonly Guid ExemptDomesticProductId = Guid.Parse("fbf872be-77b4-47f4-801a-8a5241d13dc3");
        public static readonly Guid ExemptImportedProductId = Guid.Parse("c97b89d6-462b-423d-9636-8a4e72ba265e");
        public static readonly Guid ShoppingCartId = Guid.Parse("cab81611-bec6-41ed-a25a-2ab49a43f0c9");
    }
}
