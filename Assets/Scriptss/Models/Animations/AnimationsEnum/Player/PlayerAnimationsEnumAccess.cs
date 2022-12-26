using Assets.Scriptss.Models.Particles.ParticlesEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scriptss.Models.Animations.AnimationsEnum.Player
{
    public static partial class PlayerAnimationsEnumAccess
    {
        public static string ToStringFast(this PlayerAnimationsEnum value)
        => value switch
        {
            PlayerAnimationsEnum.IsMoving => nameof(PlayerAnimationsEnum.IsMoving),
            PlayerAnimationsEnum.Jump => nameof(PlayerAnimationsEnum.Jump),
            _ => value.ToString(),
        };
    }
}
