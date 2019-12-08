using QRCode.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace QRCode.Models.Helper
{
    public partial class ContextExt : qrcodeContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
