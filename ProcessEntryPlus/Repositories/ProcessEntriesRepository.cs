using MySqlConnector;
using ProcessEntryPlus.Models;
using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ProcessEntryPlus.Repositories
{
    public class ProcessEntriesRepository
    {
        private readonly MySqlConnection _db;

        public ProcessEntriesRepository(MySqlConnection db)
        {
            _db = db;
        }

        internal List<ProcessEntry> GetAll()
        {
            string sql = @"
            SELECT
            p.*,
            a.*
            FROM processEntries p
            JOIN serviecSubjects ss ON ss.id = p.ssId
            ";
            return _db.Query<ProcessEntry, ServiceSubject, Instruction, ProcessEntry>(sql, (processEntry, serviceSubject, instruction) =>
            {
                processEntry.ServiceSubject= serviceSubject;
                processEntry.Instruction= instruction;
                return processEntry;
            }).ToList();
        }

        internal ProcessEntry Get(int id)
        {
            string sql = @"
            SELECT
            p.*,
            crt.*,
            pt.*,
            dt.*,
            co.*,
            cnt.*,
            d.*,
            ss.*,
            stadd1.*,
            stadd2.*,
            i.*,
            s.*,
            m.*,
            c.*,
            srvad.*,
            at.*
            FROM processEntries p
            LEFT JOIN courts crt ON crt.id = courtId
            LEFT JOIN litigantTypes pt ON pt.id = plaintiffTypeId
            LEFT JOIN litigantTypes dt ON dt.id = defendantTypeId
            LEFT JOIN companies co ON co.id = companyId
            LEFT JOIN contacts cnt ON cnt.id = contactId
            LEFT JOIN documents d ON d.id = documentId
            LEFT JOIN serviceSubjects ss ON ss.id = p.ssId
            LEFT JOIN addresses stadd1 ON stadd1.id = ServeToAddrId1
            LEFT JOIN addresses stadd2 ON stadd2.id = ServeToAddrId2
            LEFT JOIN instructions i ON i.id = p.instructionId
            LEFT JOIN servers s ON s.id = p.serverId
            LEFT JOIN methods m ON m.id = methodId
            LEFT JOIN capacities c ON c.id = capacityId
            LEFT JOIN addresses srvad ON srvad.id = servedAddrId
            LEFT JOIN affidavitTypes at ON at.id = affidavitTypeId
            WHERE p.id = @id
            ";
            return _db.Query<ProcessEntry>(sql,
                new[]
                { 
                    typeof(ProcessEntry),
                    typeof(Court),
                    typeof(LitigantType),
                    typeof(LitigantType),
                    typeof(Company),
                    typeof(Contact),
                    typeof(Document),
                    typeof(ServiceSubject),
                    typeof(Address),
                    typeof(Address),
                    typeof(Instruction),
                    typeof(Server),
                    typeof(Method),
                    typeof(Capacity),
                    typeof(Address),
                    typeof(AffidavitType)
                },
                objects =>
                {
                    ProcessEntry? processEntry = objects[0] as ProcessEntry;
                    Court? court = objects[1] as Court;
                    LitigantType? plaintiffType = objects[2] as LitigantType;
                    LitigantType? defendantType = objects[3] as LitigantType;
                    Company? company = objects[4] as Company;
                    Contact? contact = objects[5] as Contact;
                    Document? document = objects[6] as Document;
                    ServiceSubject? serviceSubject = objects[7] as ServiceSubject;
                    Address? serveToAddr1 = objects[8] as Address;
                    Address? serveToAddr2 = objects[9] as Address;
                    Instruction? instruction = objects[10] as Instruction;
                    Server? server = objects[11] as Server;
                    Method? method = objects[12] as Method;
                    Capacity? capacity = objects[13] as Capacity;
                    Address? servedAddr = objects[14] as Address;
                    AffidavitType? affidavitType = objects[15] as AffidavitType;


                    processEntry.Court = court;
                    processEntry.PlaintiffType = plaintiffType;
                    processEntry.DefendantType = defendantType;
                    processEntry.Company = company;
                    processEntry.Contact = contact;
                    processEntry.Document = document;
                    processEntry.ServiceSubject = serviceSubject;
                    processEntry.ServeToAddr1 = serveToAddr1;
                    processEntry.ServeToAddr2 = serveToAddr2;
                    processEntry.Instruction = instruction;
                    processEntry.Server= server;
                    processEntry.Method= method;
                    processEntry.Capacity = capacity;
                    processEntry.ServedAddr = servedAddr;
                    processEntry.AffidavitType = affidavitType;

                    return processEntry;

                }, new { id }).Single();
        }

        internal ProcessEntry Create(ProcessEntry processEntryData)
        {
            string sql = @"
            INSERT INTO processEntries
            (caseNum, courtId, status, priority, expireDateTime, plaintiffTypeId, plaintiff, defendantTypeId, defendant, companyId, contactId, receivedDateTime, documentId, ssId, serveToAddrId1, serveToAddrId2, instructionId, serverId, clientRef, servedDateTime, methodId, subServed, capacityId, servedAddrId, comments, affidavitTypeId, dueDiligence, serviceAttempts, physDesc, affidavitFee, serviceFee)
            VALUES
            (@CaseNum, @CourtId, @Status, @Priority, @expireDateTime, @PlaintiffTypeId, @Plaintiff, @DefendantTypeId, @Defendant, @CompanyId, @ContactId, @ReceivedDateTime, @DocumentId, @SsId, @ServeToAddrId1, @ServeToAddrId2, @InstructionId, @ServerId, @ClientRef, @ServedDateTime, @MethodId, @SubServed, @CapacityId, @ServedAddrId, @Comments, @AffidavitTypeId, @DueDiligence, @ServiceAttempts, @PhysDesc, @AffidavitFee, @ServiceFee);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, processEntryData);
            processEntryData.Id = id;
            return processEntryData;
        }

        internal void Edit(ProcessEntry original)
        {
            string sql = @"
            UPDATE processEntries
            SET
            caseNum = @CaseNum,
            courtId = @CourtId,
            status = @Status,
            priority = @Priority,
            expireDateTime = @ExpireDateTime,
            plaintiffTypeId = @PlaintiffTypeId,
            plaintiff = @Plaintiff,
            defendantTypeId = @DefendantTypeId,
            defendant = @Defendant,
            companyId = @CompanyId,
            contactId = @ContactId,
            receivedDateTime = @ReceivedDateTime,
            documentId = @DocumentId,
            ssid = @SsId,
            serveToAddrId1 = @ServeToAddrId1,
            serveToAddrId2 = @ServeToAddrId2,
            instructionId = @InstructionId,
            serverId = @ServerId,
            clientRef = @ClientRef,
            servedDateTime = @ServedDateTime,
            methodId = @MethodId,
            subServed = @SubServed,
            capacityId = @CapacityId,
            servedAddrId = @ServedAddrId,
            comments = @Comments,
            affidavitTypeId = @AffidavitTypeId,
            dueDiligence = @DueDiligence,
            serviceAttempts = @ServiceAttempts,
            physDesc = @PhysDesc,
            affidavitFee = @AffidavitFee,
            serviceFee = @ServiceFee
            WHERE id = @Id
            ";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM processEntries WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }   
}
