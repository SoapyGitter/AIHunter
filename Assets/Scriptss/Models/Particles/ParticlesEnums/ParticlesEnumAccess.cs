namespace Assets.Scriptss.Models.Particles.ParticlesEnums
{
    public static partial class ParticlesEnumAccess
    {
        public static string ToStringFast(this ParticlesEnum value)
        => value switch
        {
            ParticlesEnum.PlayerDustMoving => nameof(ParticlesEnum.PlayerDustMoving),
            ParticlesEnum.PlayerDustJump => nameof(ParticlesEnum.PlayerDustJump),
            _ => value.ToString(),
        };
    }
}
