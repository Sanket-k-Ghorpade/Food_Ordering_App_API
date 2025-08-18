using Food_Ordering_App_API.DTOs.Delivery_Partner_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "ADMIN")]
public class DeliveryPartnersController : ControllerBase
{
    private readonly IDeliveryPartnerService _deliveryPartnerService;

    public DeliveryPartnersController(IDeliveryPartnerService deliveryPartnerService)
    {
        _deliveryPartnerService = deliveryPartnerService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DeliveryPartnerDto>> GetAllPartners()
    {
        return Ok(_deliveryPartnerService.GetAllPartners());
    }

    [HttpGet("{id}")]
    public ActionResult<DeliveryPartnerDto> GetPartner(int id)
    {
        var partner = _deliveryPartnerService.GetPartnerById(id);
        if (partner == null) return NotFound();
        return Ok(partner);
    }

    [HttpPost]
    public ActionResult<DeliveryPartnerDto> AddPartner([FromBody] DeliveryPartnerCreateDto partnerDto)
    {
        var newPartner = _deliveryPartnerService.AddPartner(partnerDto);
        return CreatedAtAction(nameof(GetPartner), new { id = newPartner.DeliveryPartnerId }, newPartner);
    }



    [HttpPut("{id}")]
    public ActionResult<DeliveryPartnerDto> UpdatePartner(int id, [FromBody] DeliveryPartnerUpdateDto partnerDto)
    {
        var updatedPartner = _deliveryPartnerService.UpdatePartner(id, partnerDto);
        if (updatedPartner == null) return NotFound();
        return Ok(updatedPartner);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePartner(int id)
    {
        if (!_deliveryPartnerService.DeletePartner(id)) return NotFound();
        return NoContent();
    }
}