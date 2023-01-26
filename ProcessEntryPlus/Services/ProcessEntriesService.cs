using ProcessEntryPlus.Models;
using ProcessEntryPlus.Repositories;

namespace ProcessEntryPlus.Services
{
    public class ProcessEntriesService
    {
        private readonly ProcessEntriesRepository _repo;
        public ProcessEntriesService(ProcessEntriesRepository repo)
        {
            _repo = repo;
        }
        internal List<ProcessEntry> GetAll()
        {
            return _repo.GetAll();
        }
        internal ProcessEntry Get(int id)
        {
            ProcessEntry found = _repo.Get(id);
            if (found == null) 
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
        internal ProcessEntry Create(ProcessEntry processEntryData)
        {
            return _repo.Create(processEntryData);
        }
        internal ProcessEntry Edit(ProcessEntry processEntryData)
        {
            ProcessEntry original = Get(processEntryData.Id);

            original.CaseNum = processEntryData.CaseNum ?? original.CaseNum;
            original.CourtId = processEntryData.CourtId ?? original.CourtId;
            original.Status = processEntryData.Status ?? original.Status;
            original.Priority = processEntryData.Priority ?? original.Priority;
            original.ExpireDateTime = processEntryData.ExpireDateTime ?? original.ExpireDateTime;
            original.PlaintiffTypeId = processEntryData.PlaintiffTypeId ?? original.PlaintiffTypeId;
            original.Plaintiff = processEntryData.Plaintiff ?? original.Plaintiff;
            original.DefendantTypeId = processEntryData.DefendantTypeId ?? original.DefendantTypeId;
            original.Defendant = processEntryData.Defendant ?? original.Defendant;
            original.CompanyId = processEntryData.CompanyId ?? original.CompanyId;
            original.ContactId = processEntryData.ContactId ?? original.ContactId;
            original.ReceivedDateTime = processEntryData.ReceivedDateTime ?? original.ReceivedDateTime;
            original.DocumentId = processEntryData.DocumentId ?? original.DocumentId;
            original.SsId = processEntryData.SsId ?? original.SsId;
            original.ServeToAddrId1 = processEntryData.ServeToAddrId1 ?? original.ServeToAddrId1;
            original.ServeToAddrId2 = processEntryData.ServeToAddrId2 ?? original.ServeToAddrId2;
            original.InstructionId = processEntryData.InstructionId ?? original.InstructionId;
            original.ServerId = processEntryData.ServerId ?? original.ServerId;
            original.ClientRef = processEntryData.ClientRef ?? original.ClientRef;
            original.ServedDateTime = processEntryData.ServedDateTime ?? original.ServedDateTime;
            original.MethodId = processEntryData.MethodId ?? original.MethodId;
            original.SubServed = processEntryData.SubServed ?? original.SubServed;
            original.CapacityId = processEntryData.CapacityId ?? original.CapacityId;
            original.ServedAddrId = processEntryData.ServedAddrId ?? original.ServedAddrId;
            original.Comments = processEntryData.Comments ?? original.Comments;
            original.AffidavitTypeId = processEntryData.AffidavitTypeId ?? original.AffidavitTypeId;
            original.DueDiligence = processEntryData.DueDiligence ?? original.DueDiligence;
            original.ServiceAttempts = processEntryData.ServiceAttempts ?? original.ServiceAttempts;
            original.PhysDesc = processEntryData.PhysDesc ?? original.PhysDesc;
            original.AffidavitFee = processEntryData.AffidavitFee ?? original.AffidavitFee;
            original.ServiceFee = processEntryData.ServiceFee ?? original.ServiceFee;

            _repo.Edit(original);
            return original;
        }
        internal ProcessEntry Delete(int id)
        {
            ProcessEntry original = Get(id);
            if (original == null) 
            {
                throw new Exception("Delete failed. Invalid Id");
            }
            _repo.Delete(id);
            return original;
        }
    }
}

