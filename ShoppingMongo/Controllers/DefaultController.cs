using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using ShoppingMongo.Models;
using ShoppingMongo.Services.ProductServices;

using System.Xml.Linq;
using MailKit.Security;

namespace ShoppingMongo.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;
        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DetailComponent(string id)
        {
            return ViewComponent("_UIProductDetailComponentPartial", new { id = id });
        }
        [HttpGet]
        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult _FooterPartial(AdminMailViewModel model)
        {
            // Başlık ve kupon bilgisi
            model.Subject = "Coza Store | Haber Bülteni Aboneliğiniz Onaylandı";
            var discountCoupon = "COZA30";
            model.DiscountCoupon = discountCoupon;

            // Mesaj içeriği
            model.Message = $@"
Selam!

Coza Store ailesine hoş geldiniz 🎉  
Artık seni yeni sezon ürünlerinden, özel kampanyalardan ve sürpriz fırsatlardan ilk sen haberdar edeceğiz.

🎁 Bu özel anı kutlamak için sana harika bir hediye hazırladık!

🔓 Kupon Kodu: {model.DiscountCoupon}  
💸 İndirim: %30  
🛍️ Geçerlilik: Tüm ürünlerde, üstelik hiçbir koşul olmadan!

Kuponunu hemen kullanmak için tıkla: https://www.cozastore.com  
Sana en çok yakışacak parçaları kaçırma!

Her zaman buradayız.  
Sevgilerle,  
Coza Store Ekibi 💛
";

            // MIME mesajı oluştur
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Coza Store", "meerve.ylz@gmail.com")); // Gönderen
            mimeMessage.To.Add(new MailboxAddress("Kullanıcı", model.ReceiverMail));             // Alıcı
            mimeMessage.Subject = model.Subject;

            // Mesajın gövdesi
            var builder = new BodyBuilder
            {
                TextBody = model.Message
            };
            mimeMessage.Body = builder.ToMessageBody();

			// SMTP üzerinden e-posta gönderme
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
			client.Authenticate("meerve.ylz@gmail.com", "zobx kwgw wjrg mjlt");
			client.Send(mimeMessage);
			client.Disconnect(true);

			//using (var client = new MailKit.Net.Smtp.SmtpClient())
			//{
			//    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

			//    // !!! BURADA UYGULAMA ŞİFRESİ KULLANMALISIN !!!
			//    client.Authenticate("meerve.ylz@gmail.com", "uygulama-şifresi");

			//    client.Send(mimeMessage);
			//    client.Disconnect(true);
			//}

			return RedirectToAction("Index");
        }
    }
}

