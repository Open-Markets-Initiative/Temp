using SRFixBase;

namespace Eurex.EtiDerivatives.v130
{
    /// <summary>
    ///  Inquire Enrichment Rule Id List Response Message Methods
    /// </summary>

    public partial class InquireEnrichmentRuleIdListResponse
    {
        /// <summary>
        ///  Eti Identifier for Inquire Enrichment Rule Id List Response
        /// </summary>
        public const string Identifier = "10041";

        /// <summary>
        ///  Encode Inquire Enrichment Rule Id List Response Message
        /// </summary>
        public static unsafe void Encode(FixMessage message, byte* pointer, int offset, int length, out int current)
        {
            current = offset;

            // --- encode message header ---

            BodyLen.Encode(pointer, current, 0, out current);

            TemplateId.Encode(pointer, current, TemplateId.InquireEnrichmentRuleIdListResponse, out current);

            // --- encode inquire enrichment rule id list response message ---

            Pad2.Encode(pointer, current, out current);

            var requestTime = message.GetULong(RequestTime.FixTag);
            RequestTime.Encode(pointer, current, requestTime, out current);

            var sendingTime = (ulong)message.sendingTime.Ticks;
            SendingTime.Encode(pointer, current, sendingTime, out current);

            var msgSeqNum = (uint)message.msgSeqNum;
            MsgSeqNum.Encode(pointer, current, msgSeqNum, out current);

            Pad4.Encode(pointer, current, out current);

            var lastEntityProcessed = message.GetData(LastEntityProcessed.FixTag);
            LastEntityProcessed.Encode(pointer, current, lastEntityProcessed, out current);

            var isEnrichmentRulesGrpComp = message.TryGetGroup(NoEnrichmentRules.FixTag, out var enrichmentRulesGrpComp) && enrichmentRulesGrpComp.sectionList.Count > 0;
            if (isEnrichmentRulesGrpComp)
            {
                var noEnrichmentRules = (ushort)enrichmentRulesGrpComp.sectionList.Count;
                NoEnrichmentRules.Encode(pointer, current, noEnrichmentRules, out current);
            }
            else
            {
                NoEnrichmentRules.Zero(pointer, current, out current);
            }

            Pad6.Encode(pointer, current, out current);

            if (isEnrichmentRulesGrpComp)
            {
                EnrichmentRulesGrpComp.Encode(pointer, current, enrichmentRulesGrpComp, out current);
            }

            // --- complete header ---

            BodyLen.Encode(pointer, offset, (uint)(current - offset));
        }

        /// <summary>
        ///  Decode Inquire Enrichment Rule Id List Response Message
        /// </summary>
        public static unsafe FixErrorCode Decode(ref FixMessage message, byte* pointer, int offset, out int current)
        {
            current = offset;

            message.Reset();

            message.msgType = InquireEnrichmentRuleIdListResponse.Identifier;

            // --- decode inquire enrichment rule id list response message ---

            current += Pad2.Length;

            var requestTime = RequestTime.Decode(pointer, current, out current);
            message.AppendULong(RequestTime.FixTag, requestTime);

            var sendingTime = SendingTime.Decode(pointer, current, out current);
            message.sendingTime = new System.DateTime((long)sendingTime);

            var msgSeqNum = MsgSeqNum.Decode(pointer, current, out current);
            message.msgSeqNum = (int)msgSeqNum;

            current += Pad4.Length;

            var lastEntityProcessed = LastEntityProcessed.Decode(pointer, current, out current);
            message.AppendData(LastEntityProcessed.FixTag, lastEntityProcessed);

            var noEnrichmentRules = (int)NoEnrichmentRules.Decode(pointer, current, out current);

            current += Pad6.Length;

            EnrichmentRulesGrpComp.Decode(ref message, pointer, current, noEnrichmentRules, out current);

            return FixErrorCode.None;
        }
    }
}