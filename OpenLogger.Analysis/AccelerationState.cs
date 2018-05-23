using System.ComponentModel.DataAnnotations;

namespace OpenLogger.Analysis
{
    public enum AccelerationState
    {
        [Display(Name="Hard braking")]
        HardBraking,
        [Display(Name = "Medium braking")]
        MediumBraking,
        [Display(Name = "Light braking")]
        LightBraking,
        [Display(Name = "Coasting")]
        Coasting,
        [Display(Name = "Light acceleration")]
        LightAcceleration,
        [Display(Name = "Medium acceleration")]
        MediumAcceleration,
        [Display(Name = "Hard acceleration")]
        HardAcceleration
    }
}
