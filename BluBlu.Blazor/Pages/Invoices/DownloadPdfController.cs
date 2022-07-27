using Microsoft.AspNetCore.Mvc;

namespace BluBlu.Blazor.Pages.Invoices;

/// <summary>
/// In order to download the invoice, file stream is used. API call must be made.
/// </summary>
[Route("api/[controller]")]
public class DownloadPdfController : ControllerBase
{
    [HttpGet("{invoiceNumber}")]
    public IActionResult DownloadInvoiceFile([FromRoute] string invoiceNumber)
    {
        var fileStream = new FileStream($"./{invoiceNumber}.pdf", FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose);
        return File(fileStream, System.Net.Mime.MediaTypeNames.Application.Octet,            $"{invoiceNumber}.pdf");
    }
}