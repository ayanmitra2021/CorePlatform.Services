namespace CorePlatform.Services.RuleOrchestrator
{
    public class MemberRequest
    {
        public const string Route = "/RuleOrchestrator/MemberRule/{memberId:int}";

        public int MemberId { get; set; }
    }
}
