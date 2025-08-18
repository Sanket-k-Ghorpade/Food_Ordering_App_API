using Food_Ordering_App_API.DTOs.Discount_Rule_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "ADMIN")]
public class DiscountRulesController : ControllerBase
{
    private readonly IDiscountRuleService _discountRuleService;

    public DiscountRulesController(IDiscountRuleService discountRuleService)
    {
        _discountRuleService = discountRuleService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DiscountRuleDto>> GetAll()
    {
        return Ok(_discountRuleService.GetAllRules());
    }

    // A dedicated route for the active rule, accessible by any authenticated user.
    [HttpGet("active")]
    [Authorize]
    public ActionResult<DiscountRuleDto> GetActiveRule()
    {
        var rule = _discountRuleService.GetActiveRule();
        if (rule == null) return NotFound("No active discount rule found.");
        return Ok(rule);
    }

    [HttpGet("{id}")]
    public ActionResult<DiscountRuleDto> GetById(int id)
    {
        var rule = _discountRuleService.GetRuleById(id);
        if (rule == null) return NotFound();
        return Ok(rule);
    }

    [HttpPost]
    public ActionResult<DiscountRuleDto> Add([FromBody] DiscountRuleCreateDto ruleDto)
    {
        var newRule = _discountRuleService.AddRule(ruleDto);
        return CreatedAtAction(nameof(GetById), new { id = newRule.DiscountRuleId }, newRule);
    }

    [HttpPut("{id}")]
    public ActionResult<DiscountRuleDto> Update(int id, [FromBody] DiscountRuleUpdateDto ruleDto)
    {
        var updatedRule = _discountRuleService.UpdateRule(id, ruleDto);
        if (updatedRule == null) return NotFound();
        return Ok(updatedRule);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_discountRuleService.DeleteRule(id)) return NotFound();
        return NoContent();
    }
}