using System.ComponentModel.DataAnnotations;

namespace RegularExpressionTest;

public class ArtifactType
{
    [Required]
    [StringLength(20, MinimumLength = 2)]
    [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "The name field may only contain alpha-numeric characters as well as dashes and underscores.")]
    public string ArtifactTypeCode { get; set; } = string.Empty;
}
